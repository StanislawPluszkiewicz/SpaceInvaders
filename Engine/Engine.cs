using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpaceInvaders.Entities;
using SpaceInvaders.Systems;
using SpaceInvaders.Systems.Move;
using SpaceInvaders.Systems.MoveEnnemi;
using SpaceInvaders.Utils;

namespace SpaceInvaders
{
    class Engine
    {
        /// <summary>
        /// State of the keyboard
        /// </summary>
        public HashSet<Keys> keyPressed;

        public static Engine instance = null;

        private List<ISystem> systems;

        private List<Entity> entities;

        // Nodes
        private Dictionary<Entity, List<Node>> nodesByEntity;
        public Dictionary<Type, List<Node>> nodesByType;
        private IEnumerable<Type> nodeTypes;

        private Engine()
        {
            keyPressed = new HashSet<Keys>();
            systems = new List<ISystem>();
            entities = new List<Entity>();
            nodesByEntity = new Dictionary<Entity, List<Node>>();
            nodesByType = new Dictionary<Type, List<Node>>();

            // Get all child classes of a class
            // https://stackoverflow.com/questions/2742951/get-child-classes-from-base-class/11840189
            nodeTypes = typeof(Systems.Node)
                .Assembly
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Node)));
            
            foreach(Type type in nodeTypes)
            {
                nodesByType[type] = new List<Node>();
            }
            
            AddSystem(new MoveSystem());
            AddSystem(new MoveEnnemiSystem());

        }

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

        private void AddSystem(ISystem system)
        {
            systems.Add(system);
        }

        private void RemoveSystem(ISystem system)
        {
            try
            {
                systems.Remove(system);
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("SystemManager has no system " + system.GetType().Name);
                throw new KeyNotFoundException(e.Message);
            }
        }

        public void Update(double deltaTime)
        {
            foreach (ISystem system in systems)
            {
                system.Update(deltaTime);
            }
        }

        public void Render(Graphics g)
        {
            foreach(Entity e in entities)
            {
                ((Renderable)e).Render(g);
            }
        }
    }
}
