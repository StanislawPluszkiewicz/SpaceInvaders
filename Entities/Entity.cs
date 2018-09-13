using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Components;

namespace SpaceInvaders.Entities
{
    abstract class Entity
    {
    #region Components
        private Dictionary<string, Component> components = null;


        public Entity()
        {
            components = new Dictionary<string, Component>();
        }
        public void AddComponent(Component component)
        {
            components.Add(component.GetType().Name, component);
        }

        public void RemoveComponent(Type componentClass)
        {
            components.Remove(componentClass.Name);
        }

        public Component GetComponent(Type componentClass)
        {
            try
            {
                return components[componentClass.Name];
            } catch (KeyNotFoundException e)
            {
                // L'entite peut ne pas avoir un type de Component
                return null;
            }
        }
        #endregion Components


    }
}
