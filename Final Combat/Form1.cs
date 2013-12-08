using RougeMap.MapStuff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Combat
{
    
    public partial class Form1 : Form
    {
        Combats FIGHT; //instantiating the combat method, player, an enemy, and the dungeon
        Warrior player;
        EWarrior enemy1;
        Dungeon dungeon; 
        public Form1()
        {
            KeyDown += KeyPressed;
            InitializeComponent();
            dungeon = new Dungeon(map);
            dungeon.RenderDungeon(0, 0);
            EInput userInput;
            FIGHT = new Combats();
            player = new Warrior(25, 25, 100, 10, 10, 10, 10, 0);
            enemy1 = new EWarrior(0, 0);
            FIGHT.Combat = true;
            playerStats.Text = player.ToString();
            CombatVisCheck(); //to set up the GUI
            combatText.Text += "You have entered combat! What do you do?";
        }

        /// <summary>
        /// Check to see if combat continues.
        /// </summary>
        private void CombatVisCheck() 
        {
            if (player.Health > 0 && enemy1.Health > 0) //if both are alive
                CombatVisibility(true);
            else
            {
                CombatVisibility(false);
                if (player.Health > 0) //player wins
                    MessageBox.Show("You have won the combat!", "Victory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else //player loses
                    MessageBox.Show("You have died!", "Defeat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sets visibility to the combat bool.
        /// </summary>
        /// <param name="combat"></param>
        private void CombatVisibility(bool combat) 
        {
            attackButton.Visible = combat;
            defendButton.Visible = combat;
            magicButton.Visible = combat;
            potionButton.Visible = combat;
            combatText.Visible = combat;
            enemyStats.Visible = combat;
            enemyStatsLabel.Visible = combat;
            attackButton.Enabled = combat;
            defendButton.Enabled = combat;
            magicButton.Enabled = combat;
            potionButton.Enabled = combat;
            combatText.Enabled = combat;
            enemyStats.Enabled = combat;
            enemyStats.Text = enemy1.ToString(); //loads enemy stats

        }

        /// <summary>
        /// Calls the attack action for the player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void attackButton_Click(object sender, EventArgs e) 
        {
            EInput userInput = EInput.Attack;
            string output = FIGHT.Battle(userInput, enemy1.WCombatAI(enemy1.Health), player, enemy1);
            combatText.Text = combatText.Text + output;
            playerStats.Text = player.ToString(); //update stats
            enemyStats.Text = enemy1.ToString();
            CombatVisCheck();
        }

        /// <summary>
        /// Calls the defend action for the player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defendButton_Click(object sender, EventArgs e) 
        {
            EInput userInput = EInput.Defend;
            string output = FIGHT.Battle(userInput, enemy1.WCombatAI(enemy1.Health), player, enemy1);
            combatText.Text = combatText.Text + output;
            playerStats.Text = player.ToString(); //update stats
            enemyStats.Text = enemy1.ToString();
            CombatVisCheck();
        }
         
        /// <summary>
        /// Calls the magic action for the player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void magicButton_Click(object sender, EventArgs e) 
        {
            EInput userInput = EInput.Magic;
            string output = FIGHT.Battle(userInput, enemy1.WCombatAI(enemy1.Health), player, enemy1);
            combatText.Text = combatText.Text + output;
            playerStats.Text = player.ToString(); //updates
            enemyStats.Text = enemy1.ToString();
            CombatVisCheck();
        }

        /// <summary>
        /// Calls the potion action for the player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void potionButton_Click(object sender, EventArgs e) 
        {
            EInput userInput = EInput.Potion;
            string output = FIGHT.Battle(userInput, enemy1.WCombatAI(enemy1.Health), player, enemy1);
            combatText.Text = combatText.Text + output;
            playerStats.Text = player.ToString(); //updates
            enemyStats.Text = enemy1.ToString();
            CombatVisCheck();
        }

        private void combatText_TextChanged(object sender, EventArgs e) //empty methods
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e) //empty methods
        {

        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            Console.WriteLine("ajdlbgladfjbgvajl");
            switch(e.KeyCode) {
                case Keys.W:
                    player.VelocityY = - 1;
                    break;
                case Keys.D:
                    player.VelocityX = +1;
                    break;
                case Keys.A:
                    player.VelocityX = -1;
                    break;
                case Keys.S:
                    player.VelocityY = +1;
                    break;
            }
            player.Update();
            dungeon.RenderDungeon((int)player.PositionX - Floor.VIEW_AREA_WIDTH / 2, (int)player.PositionY - Floor.viewAreaHeight / 2);

        }
    }
}
