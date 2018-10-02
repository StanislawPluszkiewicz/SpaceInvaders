﻿

using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Scenes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.Timer;

namespace SpaceInvaders.Utils
{
    class RenderForm : Form
    {
        /// <summary>
        /// Instance of the game
        /// </summary>
        public Game game;

        public static Brush BLACK_BRUSH = null;
        public static Font FONT = null;
        public static Pen PEN = null;


        public static RenderForm instance = null;
        public static RenderForm CreateRenderForm()
        {
            if (instance == null)
            {
                instance = new RenderForm();
                new Scene_02_Game();
            }
            return instance;
        }

        private RenderForm()
        {
            BLACK_BRUSH = new SolidBrush(Color.Black);
            FONT = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel);
            PEN = new Pen(Color.Black);
            InitializeComponent();
            game = Game.CreateGame(this.ClientSize);
            watch.Start();
            WorldClock.Start();
        }


        internal bool ObjectIsOnScreen(RenderComponent renderComponent)
        {
            Vecteur2D topLeftCorner = new Vecteur2D(renderComponent.View.x, renderComponent.View.y);
            Vecteur2D bottomRightCorner = new Vecteur2D(renderComponent.View.x + renderComponent.Image.Width, renderComponent.View.y + renderComponent.Image.Height);

            return (bottomRightCorner.x > 0 && topLeftCorner.x < this.Width) && (bottomRightCorner.y > 0 && topLeftCorner.y < this.Height);
        }



        // form event tick 
        long lastTime = 0;
        private void WorldClock_Tick(object sender, EventArgs e)
        {
            
            // get time with millisecond precision
            long nt = watch.ElapsedMilliseconds;
            // compute ellapsed time since last call to update
            double deltaT = (nt - lastTime);

            for (; deltaT >= maxDelta; deltaT -= maxDelta)
                Engine.instance.Update(maxDelta / 1000.0); // update systems 

            // remember the time of this update
            lastTime = nt;

            Invalidate();

        }

        /// <summary>
        /// Paint event of the form, see msdn for help => paint game with double buffering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            BufferedGraphics bg = BufferedGraphicsManager.Current.Allocate(e.Graphics, e.ClipRectangle);
            bg.Graphics.Clear(Color.White);

            Engine.instance.Render(bg.Graphics);

            bg.Render();
            bg.Dispose(); // important pour l'utilisation de mémoire 
        }


        #region generated by microsoft
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer WorldClock;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {

            this.components = new System.ComponentModel.Container();
            this.WorldClock = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // WorldClock
            // 
            this.WorldClock.Interval = 30;
            this.WorldClock.Tick += new System.EventHandler(this.WorldClock_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 745);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.Text = "Space Invaders.";

            this.Load += new System.EventHandler(this.GameForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyUp);
            this.ResumeLayout(false);

        }
        /// <summary>
        /// Tick event => update game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        #endregion
        #region time management
        /// <summary>
        /// Game watch
        /// </summary>
        Stopwatch watch = new Stopwatch();

        /// <summary>
        /// Last update time
        /// </summary>

        // lets do 5 ms update to avoid quantum effects
        int maxDelta = 5;
        #endregion
        #region keyevents
        /// <summary>
        /// Key down event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            Engine.instance.keyPressed.Add(e.KeyCode);
        }
        /// <summary>
        /// Key up event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            Engine.instance.keyPressed.Remove(e.KeyCode);
        }
        private void GameForm_Load(object sender, EventArgs e)
        {

        }
        #endregion
        #region other events

        private void RenderForm_Load(object sender, EventArgs e)
        {

        }


        #endregion

    }
}
