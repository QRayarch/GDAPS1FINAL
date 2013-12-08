namespace Final_Combat
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.combatText = new System.Windows.Forms.RichTextBox();
            this.attackButton = new System.Windows.Forms.Button();
            this.defendButton = new System.Windows.Forms.Button();
            this.magicButton = new System.Windows.Forms.Button();
            this.potionButton = new System.Windows.Forms.Button();
            this.map = new System.Windows.Forms.PictureBox();
            this.enemyStats = new System.Windows.Forms.RichTextBox();
            this.playerStats = new System.Windows.Forms.RichTextBox();
            this.playerStatsLabel = new System.Windows.Forms.Label();
            this.enemyStatsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.SuspendLayout();
            // 
            // combatText
            // 
            this.combatText.Enabled = false;
            this.combatText.Location = new System.Drawing.Point(574, 353);
            this.combatText.Name = "combatText";
            this.combatText.ReadOnly = true;
            this.combatText.Size = new System.Drawing.Size(175, 204);
            this.combatText.TabIndex = 0;
            this.combatText.Text = "";
            this.combatText.Visible = false;
            this.combatText.TextChanged += new System.EventHandler(this.combatText_TextChanged);
            // 
            // attackButton
            // 
            this.attackButton.Enabled = false;
            this.attackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.attackButton.Location = new System.Drawing.Point(13, 462);
            this.attackButton.Name = "attackButton";
            this.attackButton.Size = new System.Drawing.Size(134, 95);
            this.attackButton.TabIndex = 1;
            this.attackButton.Text = "Attack";
            this.attackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.attackButton.UseVisualStyleBackColor = true;
            this.attackButton.Visible = false;
            this.attackButton.Click += new System.EventHandler(this.attackButton_Click);
            // 
            // defendButton
            // 
            this.defendButton.Enabled = false;
            this.defendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.defendButton.Location = new System.Drawing.Point(153, 462);
            this.defendButton.Name = "defendButton";
            this.defendButton.Size = new System.Drawing.Size(134, 95);
            this.defendButton.TabIndex = 2;
            this.defendButton.Text = "Defend";
            this.defendButton.UseVisualStyleBackColor = true;
            this.defendButton.Visible = false;
            this.defendButton.Click += new System.EventHandler(this.defendButton_Click);
            // 
            // magicButton
            // 
            this.magicButton.Enabled = false;
            this.magicButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.magicButton.Location = new System.Drawing.Point(293, 462);
            this.magicButton.Name = "magicButton";
            this.magicButton.Size = new System.Drawing.Size(134, 95);
            this.magicButton.TabIndex = 3;
            this.magicButton.Text = "Magic";
            this.magicButton.UseVisualStyleBackColor = true;
            this.magicButton.Visible = false;
            this.magicButton.Click += new System.EventHandler(this.magicButton_Click);
            // 
            // potionButton
            // 
            this.potionButton.Enabled = false;
            this.potionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.potionButton.Location = new System.Drawing.Point(433, 462);
            this.potionButton.Name = "potionButton";
            this.potionButton.Size = new System.Drawing.Size(134, 95);
            this.potionButton.TabIndex = 4;
            this.potionButton.Text = "Potion";
            this.potionButton.UseVisualStyleBackColor = true;
            this.potionButton.Visible = false;
            this.potionButton.Click += new System.EventHandler(this.potionButton_Click);
            // 
            // map
            // 
            this.map.Location = new System.Drawing.Point(13, 10);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(554, 446);
            this.map.TabIndex = 5;
            this.map.TabStop = false;
            this.map.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // enemyStats
            // 
            this.enemyStats.Enabled = false;
            this.enemyStats.Location = new System.Drawing.Point(574, 234);
            this.enemyStats.Name = "enemyStats";
            this.enemyStats.ReadOnly = true;
            this.enemyStats.Size = new System.Drawing.Size(175, 116);
            this.enemyStats.TabIndex = 6;
            this.enemyStats.Text = "";
            this.enemyStats.Visible = false;
            // 
            // playerStats
            // 
            this.playerStats.Enabled = false;
            this.playerStats.Location = new System.Drawing.Point(574, 38);
            this.playerStats.Name = "playerStats";
            this.playerStats.Size = new System.Drawing.Size(175, 170);
            this.playerStats.TabIndex = 7;
            this.playerStats.Text = "";
            // 
            // playerStatsLabel
            // 
            this.playerStatsLabel.AutoSize = true;
            this.playerStatsLabel.Location = new System.Drawing.Point(574, 10);
            this.playerStatsLabel.Name = "playerStatsLabel";
            this.playerStatsLabel.Size = new System.Drawing.Size(56, 13);
            this.playerStatsLabel.TabIndex = 8;
            this.playerStatsLabel.Text = "Your Stats";
            // 
            // enemyStatsLabel
            // 
            this.enemyStatsLabel.AutoSize = true;
            this.enemyStatsLabel.Location = new System.Drawing.Point(574, 215);
            this.enemyStatsLabel.Name = "enemyStatsLabel";
            this.enemyStatsLabel.Size = new System.Drawing.Size(66, 13);
            this.enemyStatsLabel.TabIndex = 9;
            this.enemyStatsLabel.Text = "Enemy Stats";
            this.enemyStatsLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(759, 561);
            this.Controls.Add(this.enemyStatsLabel);
            this.Controls.Add(this.playerStatsLabel);
            this.Controls.Add(this.playerStats);
            this.Controls.Add(this.enemyStats);
            this.Controls.Add(this.map);
            this.Controls.Add(this.potionButton);
            this.Controls.Add(this.magicButton);
            this.Controls.Add(this.defendButton);
            this.Controls.Add(this.attackButton);
            this.Controls.Add(this.combatText);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.map)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox combatText;
        private System.Windows.Forms.Button attackButton;
        private System.Windows.Forms.Button defendButton;
        private System.Windows.Forms.Button magicButton;
        private System.Windows.Forms.Button potionButton;
        private System.Windows.Forms.PictureBox map;
        private System.Windows.Forms.RichTextBox enemyStats;
        private System.Windows.Forms.RichTextBox playerStats;
        private System.Windows.Forms.Label playerStatsLabel;
        private System.Windows.Forms.Label enemyStatsLabel;
    }
}

