using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.Entities;
using SpaceInvaders.Systems;
using SpaceInvaders.Utils;

namespace SpaceInvaders
{
    class Engine
    {
        public List<Entity> entities;
        public SystemManager systemManager;

        // Nodes
        public Dictionary<Entity, List<Node>> nodesByEntity;
        public Dictionary<Type, List<Node>> nodesByType;
        private IEnumerable<Type> nodeTypes;

        public Engine()
        {
            entities = new List<Entity>();
            systemManager = new SystemManager();
            nodesByEntity = new Dictionary<Entity, List<Node>>();
            nodesByType = new Dictionary<Type, List<Node>>();

            // Get all child classes of a class
            // https://stackoverflow.com/questions/2742951/get-child-classes-from-base-class/11840189
            nodeTypes = typeof(Systems.Node)
                .Assembly
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Node)));
            
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
                    Node node = (Node) NodeType.GetConstructor(constructorParameterTypes).Invoke(currentEntityList);
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

        private void AddSystem(Systems.ISystem system)
        {
            systemManager.AddSystem(system);
        }

        private void RemoveSystem(Systems.ISystem system)
        {
            systemManager.RemoveSystem(system);
        }




    }
}
