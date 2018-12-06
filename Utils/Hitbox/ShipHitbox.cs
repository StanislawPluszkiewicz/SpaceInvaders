using SpaceInvaders.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Utils.Hitbox
{
    public class ShipHitbox : Hitbox
    {
        public enum HitboxState { NOT_COLLIDING, COLLIDING }
        public HitboxState State { get; set; }
        public List<CollisionComponent> CollidingWith { get; set; }

        public Vector2 origin;
        public enum HitSource { NONE, HEAD, BODY, WEAPONS };
        public IHitbox ApproximativeHitbox;
        public List<IHitbox> Weapons { get; set; }
        public IHitbox Body { get; set; }
        public IHitbox Head { get; set; }

        private bool hasHead;
        private bool hasWeapons;

        public ShipHitbox(IHitbox approximativeHitbox, IHitbox body, IHitbox head = null, params IHitbox[] weapons)
        {
            origin = approximativeHitbox.Position;
            ApproximativeHitbox = approximativeHitbox;
            Body = body;
            hasHead = head != null;
            hasWeapons = weapons != null && weapons.Count() > 0;
            if (hasHead)
            {
                Head = head;
            }
            Weapons = new List<IHitbox>();
            if (weapons != null && weapons.Count() > 0)
            {
                foreach(IHitbox weapon in weapons)
                {
                    Weapons.Add(weapon);
                }
            }
            State = HitboxState.NOT_COLLIDING;
        }

        public bool MayBeColliding(ShipHitbox other)
        {
            return ApproximativeHitbox.Collides(other.ApproximativeHitbox);
        }

        public Collision GetCollision(CollisionComponent collisionComponent) // call only after MayBeColliding for performances
        {
            Console.Write("GetCollision()");
            ShipHitbox other = collisionComponent.Hitbox;
            HitSource OriginHitSource = HitSource.NONE;
            HitSource DestHitSource = HitSource.NONE;
            Collision collision = null;
            if (Body.Collides(other.Body))
            {
                OriginHitSource = HitSource.BODY;
                DestHitSource = HitSource.BODY;
                collision = Body.DetailedCollision(other.Body);
            }
            else if (other.hasHead && Body.Collides(other.Head))
            {
                OriginHitSource = HitSource.BODY;
                DestHitSource = HitSource.HEAD;
                collision = Body.DetailedCollision(other.Head);
            }
            else if (other.hasWeapons)
            {
                foreach (IHitbox weapon in other.Weapons)
                {
                    if (Body.Collides(other.Body))
                    {
                        OriginHitSource = HitSource.HEAD;
                        DestHitSource = HitSource.WEAPONS;
                        collision = Body.DetailedCollision(weapon);
                    }
                }
            }
            if (this.hasHead)
            {
                if (Head.Collides(other.Body))
                {
                    OriginHitSource = HitSource.HEAD;
                    DestHitSource = HitSource.BODY;
                    collision = Head.DetailedCollision(other.Body);
                }
                else if (other.hasHead && Head.Collides(other.Head))
                {
                    OriginHitSource = HitSource.HEAD;
                    DestHitSource = HitSource.HEAD;
                    collision = Head.DetailedCollision(other.Head);
                }
                else
                {
                    foreach (IHitbox weapon in other.Weapons)
                    {
                        if (Head.Collides(weapon))
                        {
                            OriginHitSource = HitSource.HEAD;
                            DestHitSource = HitSource.WEAPONS;
                            collision = Head.DetailedCollision(weapon);
                        }
                    }
                }
            }
            else if (this.hasWeapons)
            {
                foreach (IHitbox weapon in this.Weapons)
                {
                    if (weapon.Collides(other.Body))
                    {
                        OriginHitSource = HitSource.WEAPONS;
                        DestHitSource = HitSource.BODY;
                    }
                    else if (other.hasHead && weapon.Collides(other.Head))
                    {
                        OriginHitSource = HitSource.WEAPONS;
                        DestHitSource = HitSource.HEAD;
                    }
                    else
                    {
                        foreach (IHitbox otherWeapon in other.Weapons)
                        {
                            if (weapon.Collides(otherWeapon))
                            {
                                OriginHitSource = HitSource.WEAPONS;
                                DestHitSource = HitSource.WEAPONS;
                            }
                        }
                    }
                }
            }
            collision.UpdateHitSources(OriginHitSource, DestHitSource, collisionComponent);
            return collision;
        }

        public void Update(Vector2 newPosition)
        {
            Vector2 movement = new Vector2(newPosition.x - origin.x, newPosition.y - origin.y);
            ApproximativeHitbox.Position += movement;
            Body.Position += movement;
            if (hasHead)
            {
                Head.Position += movement;
            }
            if (hasWeapons)
            {
                foreach(IHitbox weapon in Weapons)
                {
                    weapon.Position += movement;
                }
            }

        }
    }


}
