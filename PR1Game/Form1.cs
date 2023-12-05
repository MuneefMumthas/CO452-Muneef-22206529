﻿using System;
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
    public partial class Form1 : Form
    {

        bool GoLeft, GoRight, Shoot, isGameOver;
        int score;
        int ammo = 10;
        int playerSpeed = 15;
        int playerHealth = 100;
        int enemySpeed;
        int bulletSpeed;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            ResetGame();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AmmoLable = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HealthBar = new System.Windows.Forms.ProgressBar();
            this.Enemy3 = new System.Windows.Forms.PictureBox();
            this.Bullet = new System.Windows.Forms.PictureBox();
            this.Player = new System.Windows.Forms.PictureBox();
            this.Enemy2 = new System.Windows.Forms.PictureBox();
            this.Enemy1 = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(490, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Health: ";
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
            // Form1
            // 
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(804, 751);
            this.Controls.Add(this.HealthBar);
            this.Controls.Add(this.AmmoLable);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Bullet);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.Enemy2);
            this.Controls.Add(this.Enemy3);
            this.Controls.Add(this.Enemy1);
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

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
           
            if (playerHealth > 1)
            {
                HealthBar.Value = playerHealth;
            }
            else
            {
                isGameOver = true;
            }

            AmmoLable.Text = "Ammo: " + ammo;
            ScoreLabel.Text = "Score: " + score;

            Enemy1.Top += enemySpeed;
            Enemy2.Top += enemySpeed;
            Enemy3.Top += enemySpeed;

            if (GoLeft == true && Player.Left > 0)
            {
                Player.Left -= playerSpeed;
            }

            if (GoRight == true && Player.Left < 694)
            {
                Player.Left += playerSpeed;
            }

        }

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
        }

        private void ResetGame()
        {
            GameTimer.Start();
        }

        private void GameOver()
        {

        }
    }
}
