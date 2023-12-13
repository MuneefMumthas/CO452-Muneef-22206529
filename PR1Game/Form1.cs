using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR1Game
{
    /// <author>
    /// Muneef Mumthas - 22206529
    /// Game Name: Ariel Assault
    /// </author>

    public partial class Form1 : Form
    {
        ///<summary>
        /// Booleans, Constants & Variables 
        ///</summary>

        bool GoLeft, GoRight, Shoot, isGameOver, GamePaused;
        int score;
        int ammo = 10;
        int playerSpeed;
        int playerHealth = 100;
        int enemySpeed;
        int bulletSpeed;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            GameStart();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AmmoLable = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.HealthLable = new System.Windows.Forms.Label();
            this.HealthBar = new System.Windows.Forms.ProgressBar();
            this.Enemy3 = new System.Windows.Forms.PictureBox();
            this.Bullet = new System.Windows.Forms.PictureBox();
            this.Player = new System.Windows.Forms.PictureBox();
            this.Enemy2 = new System.Windows.Forms.PictureBox();
            this.Enemy1 = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.GameFinishedLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy1)).BeginInit();
            this.SuspendLayout();
            // 
            // AmmoLable
            // 
            this.AmmoLable.AutoSize = true;
            this.AmmoLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmmoLable.ForeColor = System.Drawing.Color.Black;
            this.AmmoLable.Location = new System.Drawing.Point(12, 9);
            this.AmmoLable.Name = "AmmoLable";
            this.AmmoLable.Size = new System.Drawing.Size(79, 20);
            this.AmmoLable.TabIndex = 0;
            this.AmmoLable.Text = "Ammo: 0";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.ForeColor = System.Drawing.Color.Black;
            this.ScoreLabel.Location = new System.Drawing.Point(289, 9);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(76, 20);
            this.ScoreLabel.TabIndex = 0;
            this.ScoreLabel.Text = "Score: 0";
            // 
            // HealthLable
            // 
            this.HealthLable.AutoSize = true;
            this.HealthLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HealthLable.ForeColor = System.Drawing.Color.Black;
            this.HealthLable.Location = new System.Drawing.Point(490, 9);
            this.HealthLable.Name = "HealthLable";
            this.HealthLable.Size = new System.Drawing.Size(67, 20);
            this.HealthLable.TabIndex = 0;
            this.HealthLable.Text = "Health:";
            // 
            // HealthBar
            // 
            this.HealthBar.Location = new System.Drawing.Point(558, 9);
            this.HealthBar.Name = "HealthBar";
            this.HealthBar.Size = new System.Drawing.Size(224, 23);
            this.HealthBar.TabIndex = 1;
            // 
            // Enemy3
            // 
            this.Enemy3.Image = ((System.Drawing.Image)(resources.GetObject("Enemy3.Image")));
            this.Enemy3.Location = new System.Drawing.Point(615, 99);
            this.Enemy3.Name = "Enemy3";
            this.Enemy3.Size = new System.Drawing.Size(110, 98);
            this.Enemy3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Enemy3.TabIndex = 2;
            this.Enemy3.TabStop = false;
            // 
            // Bullet
            // 
            this.Bullet.Image = global::PR1Game.Properties.Resources.Bullet_Image;
            this.Bullet.Location = new System.Drawing.Point(407, 535);
            this.Bullet.Name = "Bullet";
            this.Bullet.Size = new System.Drawing.Size(7, 27);
            this.Bullet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Bullet.TabIndex = 2;
            this.Bullet.TabStop = false;
            // 
            // Player
            // 
            this.Player.Image = global::PR1Game.Properties.Resources.Player_Image;
            this.Player.Location = new System.Drawing.Point(355, 641);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(110, 98);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Player.TabIndex = 2;
            this.Player.TabStop = false;
            // 
            // Enemy2
            // 
            this.Enemy2.Image = ((System.Drawing.Image)(resources.GetObject("Enemy2.Image")));
            this.Enemy2.Location = new System.Drawing.Point(355, 99);
            this.Enemy2.Name = "Enemy2";
            this.Enemy2.Size = new System.Drawing.Size(110, 98);
            this.Enemy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Enemy2.TabIndex = 2;
            this.Enemy2.TabStop = false;
            // 
            // Enemy1
            // 
            this.Enemy1.Image = ((System.Drawing.Image)(resources.GetObject("Enemy1.Image")));
            this.Enemy1.Location = new System.Drawing.Point(63, 99);
            this.Enemy1.Name = "Enemy1";
            this.Enemy1.Size = new System.Drawing.Size(110, 98);
            this.Enemy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Enemy1.TabIndex = 2;
            this.Enemy1.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 20;
            this.GameTimer.Tick += new System.EventHandler(this.MainGameTimerEvent);
            // 
            // GameFinishedLable
            // 
            this.GameFinishedLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameFinishedLable.Location = new System.Drawing.Point(1, 282);
            this.GameFinishedLable.Name = "GameFinishedLable";
            this.GameFinishedLable.Size = new System.Drawing.Size(804, 280);
            this.GameFinishedLable.TabIndex = 3;
            this.GameFinishedLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(804, 751);
            this.Controls.Add(this.HealthBar);
            this.Controls.Add(this.HealthLable);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.AmmoLable);
            this.Controls.Add(this.GameFinishedLable);
            this.Controls.Add(this.Bullet);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.Enemy2);
            this.Controls.Add(this.Enemy3);
            this.Controls.Add(this.Enemy1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(820, 790);
            this.MinimumSize = new System.Drawing.Size(820, 790);
            this.Name = "Form1";
            this.Text = "Aerial Assault";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.Enemy3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// This method is called only at the start
        /// and used to initialise options when the application loads. 
        /// </summary>
        private void GameStart()
        {
            isGameOver = true;
            GamePaused = true;
            
            GameTimer.Stop();

            Enemy1.Hide();
            Enemy2.Hide();
            Enemy3.Hide();
            Player.Hide();
            Bullet.Hide();

            AmmoLable.Hide();
            ScoreLabel.Hide();
            HealthLable.Hide();
            HealthBar.Hide();

            GameFinishedLable.Show();
            GameFinishedLable.Text = "Aerial Assault" + Environment.NewLine + "=======================" + Environment.NewLine + "Press Enter to Start the game" + Environment.NewLine + "================================" + Environment.NewLine + "←/→ - Move | Space - Shoot | Esc - Pause"; 
            GameFinishedLable.Location = new Point(ClientSize.Width / 2 - GameFinishedLable.Width / 2, ClientSize.Height / 2 - GameFinishedLable.Height / 2);
        }

        /// <summary>
        /// Tick event handler for the Game Timer
        /// </summary>
        private void MainGameTimerEvent(object sender, EventArgs e)
        {
           
            /// <summary>
            /// Connecting health bar value to player health
            /// and ending the game if the player health goes below 1
            /// </summary>
            if (playerHealth > 0)
            {
                HealthBar.Value = playerHealth;
            }
            else
            {
                GameOver();
                HealthBar.Value = 0;
            }

            /// Updating the Ammo lable and Score lable as the game progress
            AmmoLable.Text = "Ammo: " + ammo;
            ScoreLabel.Text = "Score: " + score;

            /// <summary>
            /// Movement mechanic and boundries for enemy movement
            /// when enemy ships go below the form, the game ends.
            /// </summary>
            Enemy1.Top += enemySpeed;
            Enemy2.Top += enemySpeed;
            Enemy3.Top += enemySpeed;

            /// Increasing speed variables to add difficulty
            if (score >= 10)
            {
                enemySpeed = 10;
                playerSpeed = 18;
            }
            if (score >= 20)
            {
                enemySpeed = 12;
                playerSpeed = 20;
            }
            if (score >= 30)
            {
                enemySpeed = 15;
                playerSpeed = 20;
            }

            if (Enemy1.Top > 815 || Enemy2.Top > 815 || Enemy3.Top > 815)
            {
                GameOver();
            }

            /// <summary>
            /// Movement mechanic and boundries for player movement
            /// </summary>
            if (GoLeft == true && Player.Left > 0)
            {
                Player.Left -= playerSpeed;
            }

            if (GoRight == true && Player.Left < 694)
            {
                Player.Left += playerSpeed;
            }

            
            /// Shooting mechanic
            if (Shoot == true)
            {
                bulletSpeed = 40;
                Bullet.Top -= bulletSpeed;

            }
            else
            {
                Bullet.Left = -300;
                bulletSpeed = 0;
            }

            if(Bullet.Top < 30)
            {
                Shoot = false;
            }

            /// <summary>
            /// Collision detection between Bullet and Enemy Ships
            /// when they collide, the score is increased by 1 and,
            /// the position  of the enemy is changed to keep them coming.
            /// </summary>
            if (Bullet.Bounds.IntersectsWith(Enemy1.Bounds))
            {
                score += 1;
                Enemy1.Top = -300;
                Enemy1.Left = rnd.Next(20, 600);
                Shoot = false;
            }
            if (Bullet.Bounds.IntersectsWith(Enemy2.Bounds))
            {
                score += 1;
                Enemy2.Top = -600;
                Enemy2.Left = rnd.Next(20, 600);
                Shoot = false;
            }
            if (Bullet.Bounds.IntersectsWith(Enemy3.Bounds))
            {
                score += 1;
                Enemy3.Top = -900;
                Enemy3.Left = rnd.Next(20, 600);
                Shoot = false;
            }

            /// colllision between player and enemy
            if (Player.Bounds.IntersectsWith(Enemy1.Bounds))
            {
                Enemy1.Top = -300;
                Enemy1.Left = rnd.Next(20, 600);
                playerHealth -= 10;
            }
            if (Player.Bounds.IntersectsWith(Enemy2.Bounds))
            {
                Enemy2.Top = -600;
                Enemy2.Left = rnd.Next(20, 600);
                playerHealth -= 10;
            }
            if (Player.Bounds.IntersectsWith(Enemy3.Bounds))
            {
                Enemy3.Top = -900;
                Enemy3.Left = rnd.Next(20, 600);
                playerHealth -= 10;
            }

            /// <summary>
            /// collision detection between enemies to prevent overlapping/bugs
            /// when they collide, one of the enemy is placed in a different position.
            /// </summary>
            if (Enemy1.Bounds.IntersectsWith(Enemy2.Bounds))
            {
                Enemy1.Top = -300;
                Enemy1.Left = rnd.Next(20, 600);
            }
            if (Enemy2.Bounds.IntersectsWith(Enemy3.Bounds))
            {
                Enemy2.Top = -600;
                Enemy2.Left = rnd.Next(20, 600);
            }
            if (Enemy3.Bounds.IntersectsWith(Enemy1.Bounds))
            {
                Enemy3.Top = -900;
                Enemy3.Left = rnd.Next(20, 600);
            }

            /// <summary>
            /// Collision detection between Player and Ammo drops
            /// when they collide the ammo count increases to 5 and
            /// ammo image is disposed
            /// </summary>
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5;
                    }
                }
            }
        }

        ///<summary>
        /// KeyDown event handler.
        /// When Left & Right keys are pressed,
        /// the direction booleans are set to true accordingly.
        ///</summary>
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                GoLeft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
               GoRight = true;
            }
        }

        ///<summary>
        /// KeyUp event handler.
        /// when Left & Right keys are released,
        /// the direction booleans are set to false accordingly.
        ///</summary>
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                GoLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                GoRight = false;
            }

            ///<summary>
            /// When Space key is released while the conditions are true,
            /// the ammo count is reduced by 1 and Shoot boolean is set to true. 
            /// when ammo count reaches 0, the DropAmmo method is called.
            /// </summary>
            if(e.KeyCode == Keys.Space && Shoot == false && ammo > 0 && isGameOver == false && GamePaused == false)
            {
                ammo--;
                Shoot = true;
                Bullet.Top = Player.Top - 30;
                Bullet.Left = Player.Left + (Player.Width/2);

                if(ammo < 1)
                {
                    DropAmmo();
                }
            }

            /// Restarts the game when Enter key is released and conditions are true
            if(e.KeyCode == Keys.Enter && isGameOver == true)
            {
                ResetGame();
            }
            else if (e.KeyCode == Keys.Enter && GamePaused == true && isGameOver == false)
            {
                ResetGame();
            }

            if (e.KeyCode == Keys.Escape && GamePaused == false && isGameOver == false)
            {
                GameTimer.Stop();
                GamePaused = true;

                Enemy1.Hide();
                Enemy2.Hide();
                Enemy3.Hide();
                Player.Hide();
                Bullet.Hide();

                GameFinishedLable.Show();
                GameFinishedLable.Text = "Game Paused !" + Environment.NewLine +"======================"+ Environment.NewLine + "Press Enter to Restart" + Environment.NewLine + "======================" + Environment.NewLine + "Press Escape to Resume";
                GameFinishedLable.Location = new Point(ClientSize.Width / 2 - GameFinishedLable.Width / 2, ClientSize.Height / 2 - GameFinishedLable.Height / 2);


            }
            else if(e.KeyCode == Keys.Escape && GamePaused == true && isGameOver == false)
            {
                GamePaused = false;
                GameTimer.Start();

                Enemy1.Show();
                Enemy2.Show();
                Enemy3.Show();
                Player.Show();
                Bullet.Show();

                GameFinishedLable.Hide();
            }
        }


        /// <summary>
        /// This method creates a picture box to spawn ammo within the range,
        /// which can be collected by the player
        /// </summary>
        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.Ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.StretchImage;
            ammo.Size = new Size(60, 60);
            ammo.Left = rnd.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = 665;
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);

            ammo.BringToFront();
            Player.BringToFront();
        }


        ///<summary>
        /// Method to Reset the game
        /// </summary>
        private void ResetGame()
        {
            GameTimer.Start();

            /// Reseting positions for enemy ships
            Enemy1.Top = -300;
            Enemy2.Top = -600;
            Enemy3.Top = -900;

            Enemy1.Left = rnd.Next(20, 600);
            Enemy2.Left = rnd.Next(20, 600);
            Enemy3.Left = rnd.Next(20, 600);

            /// Reseting player position
            Player.Top = 641;
            Player.Left = 355;

            /// Reseting the variables
            score = 0;
            enemySpeed = 7;
            playerSpeed = 15;
            bulletSpeed = 0;
            Bullet.Left = -300;
            ammo = 10;
            playerHealth = 100;
            Shoot = false;
            isGameOver = false;
            GamePaused = false;

            Enemy1.Show();
            Enemy2.Show();
            Enemy3.Show();
            Player.Show();
            Bullet.Show();

            AmmoLable.Show();
            ScoreLabel.Show();
            HealthLable.Show();
            HealthBar.Show();

            GameFinishedLable.Hide();

            /// removing any ammo image at the start
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    this.Controls.Remove(x);
                }
            }

        }

        /// <summary>
        /// This method ends the game when called.
        /// it stops the game timer, hides the enemy ships & bullet.
        /// and shows a text with score and guidance to restart the game.
        /// </summary>
        private void GameOver()
        {
            isGameOver = true;
            GameTimer.Stop();

            Enemy1.Hide();
            Enemy2.Hide();
            Enemy3.Hide();
            Player.Hide();
            Bullet.Hide();

            AmmoLable.Hide();
            ScoreLabel.Hide();
            HealthLable.Hide();
            HealthBar.Hide();

            GameFinishedLable.Show();
            GameFinishedLable.Text = "Game Over !" + Environment.NewLine + "======================" +Environment.NewLine + "Your Score is "+ score + Environment.NewLine + "======================" + Environment.NewLine + "Press Enter to Try Again";
            GameFinishedLable.Location = new Point(ClientSize.Width / 2 - GameFinishedLable.Width / 2, ClientSize.Height / 2 - GameFinishedLable.Height / 2);
        }
    }
}
