using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Entities;
using SpaceInvaders.Components;

namespace SpaceInvaders.Systems
{
    abstract class Node
    {
        private Dictionary<string, Component> components;

        public Node()
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
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("Node has no component of type " + componentClass.Name);
                throw new KeyNotFoundException(e.Message);
            }
        }

        // create this method in children
        // can't create static virtual 
        // neither can create interface with static method 
        public static bool HasToBeCreated(Entity entity)
        {
            throw new NotImplementedException("Should call the child method!");
        }
    }
}
