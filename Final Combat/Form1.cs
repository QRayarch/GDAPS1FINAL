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
        Combats FIGHT;
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
            playerStats.Text = player.ToString();
            enemyStats.Text = enemy1.ToString();
            combatText.Text += "What do?";
      
        }

        // Connects the attack button to the Attack method 
        //Also prints out result of using the method
        private void attackButton_Click(object sender, EventArgs e)
        {
            EInput userInput = EInput.Attack;
            string output = FIGHT.Battle(userInput, enemy1.WCombatAI(enemy1.Health), player, enemy1);
            combatText.Text = combatText.Text + output;
            playerStats.Text = player.ToString();
            enemyStats.Text = enemy1.ToString();
        }
        //connects the defend button to the Defend method
        //Also prints out result of using the method
        private void defendButton_Click(object sender, EventArgs e)
        {
            EInput userInput = EInput.Defend;
            string output = FIGHT.Battle(userInput, enemy1.WCombatAI(enemy1.Health), player, enemy1);
            combatText.Text = combatText.Text + output;
            playerStats.Text = player.ToString();
            enemyStats.Text = enemy1.ToString();
        }
        //connects the Magic button to the Magic method
        //Also prints out result of using the method
        private void magicButton_Click(object sender, EventArgs e)
        {
            EInput userInput = EInput.Magic;
            string output = FIGHT.Battle(userInput, enemy1.WCombatAI(enemy1.Health), player, enemy1);
            combatText.Text = combatText.Text + output;
            playerStats.Text = player.ToString();
            enemyStats.Text = enemy1.ToString();
        }
        //connects potion button to Potion method
        //Also prints out result of using the method
        private void potionButton_Click(object sender, EventArgs e)
        {
            EInput userInput = EInput.Potion;
            string output = FIGHT.Battle(userInput, enemy1.WCombatAI(enemy1.Health), player, enemy1);
            combatText.Text = combatText.Text + output;
            playerStats.Text = player.ToString();
            enemyStats.Text = enemy1.ToString();
        }

        private void combatText_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //changes player's location on the map by changing their corrdinates
        //depending on which button is pressed
        private void KeyPressed(object sender, KeyEventArgs e)
        {
            Console.WriteLine("ajdlbgladfjbgvajl");
            switch(e.KeyCode) {
                case Keys.W://moves player up
                    player.VelocityY = -1;
                    break;
                case Keys.D://moves player to the right
                    player.VelocityX = +1;
                    break;
                case Keys.A://moves player down
                    player.VelocityX = -1;
                    break;
                case Keys.S://moves plaer to the left
                    player.VelocityY = +1;
                    break;
            }
            player.Update();
            dungeon.RenderDungeon((int)player.PositionX - Floor.VIEW_AREA_WIDTH / 2, (int)player.PositionY - Floor.VIEW_AREA_HEIGHT / 2);

        }
    }
}
