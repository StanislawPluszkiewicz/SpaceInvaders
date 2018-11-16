using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities
{
    abstract class Entity
    {
        protected Entity()
        {
            components = new Dictionary<Type, Component>();
            AddComponent(new TransformComponent(this));
        }

    #region Components
        private Dictionary<Type, Component> components = null;

        public void AddComponent(Component component)
        {
            components.Add(component.GetType(), component);
        }

        public void RemoveComponent(Type componentClass)
        {
            components.Remove(componentClass);
        }

        public Component GetComponent(Type componentClass)
        {
            try
            {
                return components[componentClass];
            } catch (KeyNotFoundException e)
            {
                // L'entite peut ne pas avoir un type de Component
                throw e;
            }
        }
        #endregion Components


    }
}
