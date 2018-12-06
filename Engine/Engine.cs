using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Systems;
using SpaceInvaders.Systems.Collision;
using SpaceInvaders.Systems.Move;
using SpaceInvaders.Systems.Move.MoveEnnemiLine;
using SpaceInvaders.Systems.Move.MoveKynematicObject;
using SpaceInvaders.Systems.OffScreenColider;
using SpaceInvaders.Systems.Shoot;
using SpaceInvaders.Utils;
using SpaceInvaders.Utils.Hitbox;

namespace SpaceInvaders
{
    class Engine
    {
        public HashSet<Keys> keyPressed;
        public static Engine instance = null;
        public bool Pause = false;
        public Dictionary<Type, List<Node>> nodesByType;
        
        private List<ISystem> gameSystems;
        private List<ISystem> applicationSystems;
        private List<Entity> entities;
        private Dictionary<Entity, List<Node>> nodesByEntity;
        private IEnumerable<Type> nodeTypes;

        private Engine()
        {
            keyPressed = new HashSet<Keys>();
            gameSystems = new List<ISystem>();
            applicationSystems = new List<ISystem>();
            entities = new List<Entity>();
            nodesByEntity = new Dictionary<Entity, List<Node>>();
            nodesByType = new Dictionary<Type, List<Node>>();

            // Get all child classes of a class
            // https://stackoverflow.com/questions/2742951/get-child-classes-from-base-class/11840189
            nodeTypes = typeof(Node)
                .Assembly
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Node)));
            
            foreach(Type type in nodeTypes)
            {
                nodesByType[type] = new List<Node>();
            }

            AddAllSystems();
        }

        private void AddAllSystems()
        {
            //AddGameSystem(new MoveKynematicSystem());
            //AddGameSystem(new MoveDynamicSystem());
            //AddGameSystem(new MoveEnnemiBlocSystem());
            //AddGameSystem(new OffScreenColiderSystem());
            //AddGameSystem(new ShootSystem());
            //AddGameSystem(new CollisionSystem());
            //AddApplicationSystem(new MenuShortcutsSystem());
        }

        #region internal
        public static Engine CreateEngine()
        {
            if (instance == null)
            {
                instance = new Engine();
            }
            return instance;
        }

        public void AddEntity(Entity entity)
        {
            // Made with a lot of help from stack overflow

            entities.Add(entity);
            nodesByEntity[entity] = new List<Node>();
            foreach(Type NodeType in nodeTypes)
            {
                Entity[] currentEntityList = { entity };
                if ((bool) NodeType.GetMethod("HasToBeCreated").Invoke(null, currentEntityList))
                {
                    Type[] constructorParameterTypes = { typeof(Entity) };
                    Node node = NodeType.GetConstructor(constructorParameterTypes).Invoke(currentEntityList) as Node;
                    nodesByEntity[entity].Add(node);
                    nodesByType[NodeType].Add(node);
                }
            }
        }

        public void RemoveEntity(Entity entity)
        {
            if (entities.Contains(entity))
            {
                entities.Remove(entity);
                foreach (Node node in nodesByEntity[entity])
                {
                    nodesByType[node.GetType()].Remove(node);
                }
                nodesByEntity.Remove(entity);
            }
        }

        internal Entity GetEntityByNode(Node n)
        {
            foreach (KeyValuePair<Entity, List<Node>> keyValuePair in nodesByEntity)
            {
                foreach (Node node in keyValuePair.Value)
                {
                    if (n == node)
                    {
                        return keyValuePair.Key;
                    }
                }
            }
            throw new Exception("Couldn't get the entity associated to a node");
        }

        private void AddGameSystem(ISystem system)
        {
            gameSystems.Add(system);
        }

        private void RemoveGameSystem(ISystem system)
        {
            try
            {
                gameSystems.Remove(system);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("SystemManager has no system " + system.GetType().Name);
                throw new KeyNotFoundException(e.Message);
            }
        }

        private void AddApplicationSystem(ISystem system)
        {
            applicationSystems.Add(system);
        }

        private void RemoveApplicationSystem(ISystem system)
        {
            try
            {
                applicationSystems.Remove(system);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("SystemManager has no system " + system.GetType().Name);
                throw new KeyNotFoundException(e.Message);
            }
        }
        #endregion internal

        public void Update(double deltaTime)
        {
            if (!Pause)
            {
                foreach (ISystem system in gameSystems)
                {
                    system.Update(deltaTime);
                }

            }

            foreach (ISystem system in applicationSystems)
            {
                system.Update(deltaTime);
            }
        }

        private void DebugRender(Graphics g, Entity entity)
        {
            bool DrawHitboxes = true;
            bool DrawEntitesBorders = false;
            if (DrawHitboxes)
            {
                if (entity.Components[typeof(CollisionComponent)] is CollisionComponent collisionComponent)
                {
                    CollisionComponent c = collisionComponent;
                    if (collisionComponent.Hitbox.ApproximativeHitbox is HitboxAABB hitbox)
                    {
                        Rectangle hitboxRect = new Rectangle((int)hitbox.box.x, (int)hitbox.box.y, (int)hitbox.box.Width, (int)hitbox.box.Height);
                        Pen redPen = new Pen(Color.Red)
                        {
                            Alignment = PenAlignment.Inset
                        };
                        g.DrawRectangle(redPen, hitboxRect);
                    }
                }
            }
            if (DrawEntitesBorders)
            {
                if (entity.Components[typeof(RenderComponent)] is RenderComponent renderComponent)
                {
                    Rectangle imageRect = new Rectangle((int)renderComponent.View.x, (int)renderComponent.View.y, renderComponent.Images.Size.Width, renderComponent.Images.Size.Height);

                    Pen greenPen = new Pen(Color.Green)
                    {
                        Alignment = PenAlignment.Inset
                    };
                    g.DrawRectangle(greenPen, imageRect);
                }
            }
        }
        public void Render(Graphics g)
        {
            foreach(Entity e in entities)
            {
                if (e is Renderable entity)
                {
                    entity.Render(g);
                    DebugRender(g, entity);

                }

            }
        }
    }
}
