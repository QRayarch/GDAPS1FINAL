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
            this.characterCreation = new System.Windows.Forms.Panel();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.textBoxStatExplain = new System.Windows.Forms.TextBox();
            this.textBoxWAdd = new System.Windows.Forms.TextBox();
            this.textBoxDAdd = new System.Windows.Forms.TextBox();
            this.textBoxCAdd = new System.Windows.Forms.TextBox();
            this.textBoxSAdd = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelW = new System.Windows.Forms.Label();
            this.labelD = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.labelS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.characterCreation.SuspendLayout();
            this.SuspendLayout();
            // 
            // combatText
            // 
            this.combatText.Enabled = false;
            this.combatText.Location = new System.Drawing.Point(574, 353);
            this.combatText.Name = "combatText";
            this.combatText.ReadOnly = true;
            this.combatText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
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
            // characterCreation
            // 
            this.characterCreation.BackColor = System.Drawing.SystemColors.Window;
            this.characterCreation.Controls.Add(this.buttonSubmit);
            this.characterCreation.Controls.Add(this.textBoxStatExplain);
            this.characterCreation.Controls.Add(this.textBoxWAdd);
            this.characterCreation.Controls.Add(this.textBoxDAdd);
            this.characterCreation.Controls.Add(this.textBoxCAdd);
            this.characterCreation.Controls.Add(this.textBoxSAdd);
            this.characterCreation.Controls.Add(this.textBox1);
            this.characterCreation.Controls.Add(this.labelW);
            this.characterCreation.Controls.Add(this.labelD);
            this.characterCreation.Controls.Add(this.labelC);
            this.characterCreation.Controls.Add(this.labelS);
            this.characterCreation.Location = new System.Drawing.Point(13, 10);
            this.characterCreation.Name = "characterCreation";
            this.characterCreation.Size = new System.Drawing.Size(554, 446);
            this.characterCreation.TabIndex = 10;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.Location = new System.Drawing.Point(239, 343);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(139, 59);
            this.buttonSubmit.TabIndex = 14;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // textBoxStatExplain
            // 
            this.textBoxStatExplain.Location = new System.Drawing.Point(203, 65);
            this.textBoxStatExplain.Name = "textBoxStatExplain";
            this.textBoxStatExplain.ReadOnly = true;
            this.textBoxStatExplain.Size = new System.Drawing.Size(125, 20);
            this.textBoxStatExplain.TabIndex = 13;
            this.textBoxStatExplain.Text = "Enter values totalling 12";
            // 
            // textBoxWAdd
            // 
            this.textBoxWAdd.Location = new System.Drawing.Point(239, 274);
            this.textBoxWAdd.Name = "textBoxWAdd";
            this.textBoxWAdd.Size = new System.Drawing.Size(50, 20);
            this.textBoxWAdd.TabIndex = 8;
            this.textBoxWAdd.Text = "0";
            // 
            // textBoxDAdd
            // 
            this.textBoxDAdd.Location = new System.Drawing.Point(239, 215);
            this.textBoxDAdd.Name = "textBoxDAdd";
            this.textBoxDAdd.Size = new System.Drawing.Size(50, 20);
            this.textBoxDAdd.TabIndex = 7;
            this.textBoxDAdd.Text = "0";
            // 
            // textBoxCAdd
            // 
            this.textBoxCAdd.Location = new System.Drawing.Point(239, 155);
            this.textBoxCAdd.Name = "textBoxCAdd";
            this.textBoxCAdd.Size = new System.Drawing.Size(50, 20);
            this.textBoxCAdd.TabIndex = 6;
            this.textBoxCAdd.Text = "0";
            // 
            // textBoxSAdd
            // 
            this.textBoxSAdd.Location = new System.Drawing.Point(239, 91);
            this.textBoxSAdd.Name = "textBoxSAdd";
            this.textBoxSAdd.Size = new System.Drawing.Size(50, 20);
            this.textBoxSAdd.TabIndex = 5;
            this.textBoxSAdd.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(188, 91);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(33, 210);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "4 + \r\n\r\n\r\n4 +\r\n\r\n\r\n4 +\r\n\r\n\r\n4 +";
            // 
            // labelW
            // 
            this.labelW.AutoSize = true;
            this.labelW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelW.Location = new System.Drawing.Point(64, 274);
            this.labelW.Name = "labelW";
            this.labelW.Size = new System.Drawing.Size(66, 20);
            this.labelW.TabIndex = 3;
            this.labelW.Text = "Wisdom";
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelD.Location = new System.Drawing.Point(64, 215);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(71, 20);
            this.labelD.TabIndex = 2;
            this.labelD.Text = "Dexterity";
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelC.Location = new System.Drawing.Point(64, 155);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(94, 20);
            this.labelC.TabIndex = 1;
            this.labelC.Text = "Constitution";
            // 
            // labelS
            // 
            this.labelS.AutoSize = true;
            this.labelS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelS.Location = new System.Drawing.Point(64, 91);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(71, 20);
            this.labelS.TabIndex = 0;
            this.labelS.Text = "Strength";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(759, 561);
            this.Controls.Add(this.characterCreation);
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
            this.characterCreation.ResumeLayout(false);
            this.characterCreation.PerformLayout();
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
        private System.Windows.Forms.Panel characterCreation;
        private System.Windows.Forms.TextBox textBoxWAdd;
        private System.Windows.Forms.TextBox textBoxDAdd;
        private System.Windows.Forms.TextBox textBoxCAdd;
        private System.Windows.Forms.TextBox textBoxSAdd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelW;
        private System.Windows.Forms.Label labelD;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.Label labelS;
        private System.Windows.Forms.TextBox textBoxStatExplain;
        private System.Windows.Forms.Button buttonSubmit;
    }
}

