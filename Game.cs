using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using SpaceInvaders.Entities;
using SpaceInvaders.Components;
using SpaceInvaders.Scenes;

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
        public static Game instance { get; private set; }

        #region constructors (singleton)
        /// <summary>
        /// Singleton constructor
        /// </summary>
        /// <param name="gameSize">Size of the game area</param>
        /// 
        /// <returns></returns>
        public static Game CreateGame(Size gameSize)
        {
            if (instance == null)
                instance = new Game(gameSize);
            return instance;
        }

        /// <summary>
        /// Private constructor
        /// </summary>
        /// <param name="gameSize">Size of the game area</param>
        private Game(Size gameSize)
        {
            this.gameSize = gameSize;
            Engine.CreateEngine();
        }

        #endregion
        public void Update(double deltaTime)
        {
            Engine.instance.Update(deltaTime);
        }

    }
}
