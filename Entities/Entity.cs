using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Components = new Dictionary<Type, Component>();
            AddComponent(new TransformComponent(this));
        }

    #region Components
        public Dictionary<Type, Component> Components = null;

        public void AddComponent(Component component)
        {
            Components.Add(component.GetType(), component);
        }

        public void RemoveComponent(Type componentClass)
        {
            Components.Remove(componentClass);
        }

        [Obsolete("GetComponent is deprecated, please use a direct access to the Components dictionnary instead (for debugging purposes).")]
        public Component GetComponent(Type componentClass)
        {
            try
            {
                return Components[componentClass];
            }
            catch (KeyNotFoundException e)
            {
                //L'entite peut ne pas avoir un type de Component
                throw e;
            }
        }
        #endregion Components


    }
}
