using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using SpaceInvaders.Entities;

namespace SpaceInvaders
{
    class Game
    {

        #region game technical elements
        /// <summary>
        /// Size of the game area
        /// </summary>
        public Size gameSize;

        /// <summary>
        /// State of the keyboard
        /// </summary>
        public HashSet<Keys> keyPressed = new HashSet<Keys>();

        #endregion
        
        /// <summary>
        /// Singleton for easy access
        /// </summary>
        public static Game game { get; private set; }
        public static Engine Engine { get; private set; }

        #region constructors (singleton)
        /// <summary>
        /// Singleton constructor
        /// </summary>
        /// <param name="gameSize">Size of the game area</param>
        /// 
        /// <returns></returns>
        public static Game CreateGame(Size gameSize)
        {
            if (game == null)
                game = new Game(gameSize);
            return game;
        }

        /// <summary>
        /// Private constructor
        /// </summary>
        /// <param name="gameSize">Size of the game area</param>
        private Game(Size gameSize)
        {

            this.gameSize = gameSize;
            Engine = new Engine();
            Entity joueur = new Joueur(Image.FromFile("../../Resources/ship1.png"));

            Engine.AddEntity(joueur);

        }

        #endregion

        #region methods

        /// <summary>
        /// Force a given key to be ignored in following updates until the user
        /// explicitily retype it or the system autofires it again.
        /// </summary>
        /// <param name="key">key to ignore</param>
        public void ReleaseKey(Keys key)
        {
            keyPressed.Remove(key);
        }


        ///// <summary>
        ///// Update game
        ///// </summary>
        //public void Update(double deltaT)
        //{
        //    // add new game objects
        //    gameObjects.UnionWith(pendingNewGameObjects);
        //    pendingNewGameObjects.Clear();

        //    // remove dead objects
        //    gameObjects.RemoveWhere(gameObject => !gameObject.IsAlive());
        //}
        #endregion
    }
}
