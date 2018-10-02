using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpaceInvaders.Entities;
using SpaceInvaders.Systems;
using SpaceInvaders.Systems.Move;
using SpaceInvaders.Systems.Move.MoveEnnemiLine;
using SpaceInvaders.Systems.Move.MoveKynematicObject;
using SpaceInvaders.Systems.OffScreenColider;
using SpaceInvaders.Systems.Shoot;
using SpaceInvaders.Utils;

namespace SpaceInvaders
{
    class Engine
    {
        /// <summary>
        /// State of the keyboard
        /// </summary>
        public HashSet<Keys> keyPressed;

        /// <summary>
        /// Unique engine instance (singleton)
        /// </summary>
        public static Engine instance = null;

        /// <summary>
        /// List of all systems
        /// </summary>
        private List<ISystem> systems;

        private List<GameObject> entities;

        // Nodes
        private Dictionary<GameObject, List<Node>> nodesByEntity;
        public Dictionary<Type, List<Node>> nodesByType;
        private IEnumerable<Type> nodeTypes;

        private Engine()
        {
            keyPressed = new HashSet<Keys>();
            systems = new List<ISystem>();
            entities = new List<GameObject>();
            nodesByEntity = new Dictionary<GameObject, List<Node>>();
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

            AddSystem(new MoveKynematicSystem());
            AddSystem(new MoveDynamicSystem());
            AddSystem(new MoveEnnemiLineSystem());
            AddSystem(new OffScreenColiderSystem());
            AddSystem(new ShootSystem());

        }

        public static Engine CreateEngine()
        {
            if (instance == null)
            {
                instance = new Engine();
            }
            return instance;
        }

        public void AddEntity(GameObject entity)
        {
            // Made with a lot of help from stack overflow

            entities.Add(entity);
            nodesByEntity[entity] = new List<Node>();
            foreach(Type NodeType in nodeTypes)
            {
                GameObject[] currentEntityList = { entity };
                if ((bool) NodeType.GetMethod("HasToBeCreated").Invoke(null, currentEntityList))
                {
                    Type[] constructorParameterTypes = { typeof(GameObject) };
                    Node node = NodeType.GetConstructor(constructorParameterTypes).Invoke(currentEntityList) as Node;
                    nodesByEntity[entity].Add(node);
                    nodesByType[NodeType].Add(node);
                }
            }
        }

        public void RemoveEntity(GameObject entity)
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

        internal GameObject GetEntityByNode(Node n)
        {
            foreach (KeyValuePair<GameObject, List<Node>> keyValuePair in nodesByEntity)
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
            foreach(GameObject e in entities)
            {
                var entity = e as Renderable;
                if (entity != null)
                    ((Renderable)e).Render(g);
            }
        }
    }
}
