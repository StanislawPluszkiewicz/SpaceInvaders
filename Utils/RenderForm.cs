using SpaceInvaders.Systems.Render;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders.Utils
{
    class RenderForm : Form
    {
        /// <summary>
        /// Instance of the game
        /// </summary>
        private Game game;

        public Brush BLACK_BRUSH = null;
        public Font FONT = null;
        public Pen PEN = null;
        public BufferedGraphics BUFFERED_GRAPHICS { get; set; }
        public Rectangle CLIP_RECTANGLE { get; set; } 
        
        
        public static RenderForm instance = null;
        public static RenderForm CreateRenderForm()
        {
            if (RenderForm.instance == null)
            {
                RenderForm.instance = new RenderForm();
            }
            return RenderForm.instance;
        }
        
        public RenderForm()
        {
            BLACK_BRUSH = new SolidBrush(Color.Black);
            FONT = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel);
            PEN = new Pen(Color.Black);
            InitializeComponent();
            BUFFERED_GRAPHICS = null;
            CLIP_RECTANGLE = this.ClientRectangle;
            game = Game.CreateGame(this.ClientSize);
        }

        public void Render(RenderNode target)
        {
            BufferedGraphics bg = BufferedGraphicsManager.Current.Allocate(BUFFERED_GRAPHICS.Graphics, CLIP_RECTANGLE);
            bg.Graphics.Clear(Color.White);

            bg.Graphics.DrawImage(target.Render.Image, (float)target.Render.View.x, (float)target.Render.View.y);
            
            bg.Render();
            bg.Dispose();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 605);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RenderForm";
            this.Text = "Space Invaders -ecs";
            this.Load += new System.EventHandler(this.RenderForm_Load);
            this.ResumeLayout(false);

        }


        #region time management
        /// <summary>
        /// Game watch
        /// </summary>
        Stopwatch watch = new Stopwatch();

        /// <summary>
        /// Last update time
        /// </summary>
        long lastTime = 0;
        #endregion

        #region events
        /// <summary>
        /// Paint event of the form, see msdn for help => paint game with double buffering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            BufferedGraphics bg = BufferedGraphicsManager.Current.Allocate(e.Graphics, e.ClipRectangle);
            Graphics g = bg.Graphics;
            g.Clear(Color.White);

            // g.Draw();

            bg.Render();
            bg.Dispose();
        }

        /// <summary>
        /// Tick event => update game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        

        /// <summary>
        /// Key down event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            game.keyPressed.Add(e.KeyCode);
        }

        /// <summary>
        /// Key up event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            game.keyPressed.Remove(e.KeyCode);
        }

        #endregion

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void RenderForm_Load(object sender, EventArgs e)
        {

        }
    }
}
