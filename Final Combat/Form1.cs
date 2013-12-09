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
    public delegate void EnemyJoinCombat(Character enemy);

    public partial class Form1 : Form
    {
        Combats FIGHT;
        private static Character player;
        public static Character Player
        {
            get
            {
                return player;
            }
        }
        private static Character enemy;
        public static void EnemyJoin(Character newEnemy)
        {
            if (enemy != null && !enemy.Alive)
            {
                enemy = null;
            }
            else if (enemy == null)
            {
                enemy = newEnemy;
            }
        }
        public static event EnemyJoinCombat enemyJoinedCombat = EnemyJoin;

        Dungeon dungeon; 
        public Form1()
        {
            KeyDown += KeyPressed;
            InitializeComponent();
            dungeon = new Dungeon(map);
            EInput userInput;
            FIGHT = new Combats();
            player = new Warrior(25, 25, 100, 10, 10, 10, 10, 0, Brushes.PowderBlue);
            dungeon.GetFloor(0).AddChracter(player);
            dungeon.RenderDungeon((int)player.PositionX, (int)player.PositionY);
            //enemyPlayerFighting = new EWarrior(0, 0);
            FIGHT.Combat = false;
            playerStats.Text = player.ToString();
            //CombatVisCheck();
        }

        private void CombatVisCheck()
        {
            if (enemy != null && player.Health > 0 && enemy.Health > 0)
            {
                CombatVisibility(true);
                FIGHT.Combat = true;
            }
            else
            {
                CombatVisibility(false);
                if (player.Health > 0 && enemy != null)
                {
                    enemy = null;
                    MessageBox.Show("You have won the combat!", "Victory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (enemy != null && enemy.Health > 0)
                {
                    MessageBox.Show("You have died!", "Defeat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }

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
            if (combat != combatText.Enabled)
            {
                combatText.Text = "You have entered combat! What do you do?";
            }
            potionButton.Enabled = combat;
            combatText.Enabled = combat;
            enemyStats.Enabled = combat;
            enemyStats.Text = enemy == null?"":enemy.ToString();
        }

        // Connects the attack button to the Attack method 
        //Also prints out result of using the method
        private void attackButton_Click(object sender, EventArgs e)
        {
            EInput userInput = EInput.Attack;
            string output = FIGHT.Battle(userInput, PickEnemyMove(), player, enemy);
            combatText.Text = combatText.Text + output;
            playerStats.Text = player.ToString();
            enemyStats.Text = enemy.ToString();
            CombatVisCheck();
        }
        //connects the defend button to the Defend method
        //Also prints out result of using the method
        private void defendButton_Click(object sender, EventArgs e)
        {
            EInput userInput = EInput.Defend;
            string output = FIGHT.Battle(userInput, PickEnemyMove(), player, enemy);
            combatText.Text = combatText.Text + output;
            playerStats.Text = player.ToString();
            enemyStats.Text = enemy.ToString();
            CombatVisCheck();
        }
        //connects the Magic button to the Magic method
        //Also prints out result of using the method
        private void magicButton_Click(object sender, EventArgs e)
        {
            EInput userInput = EInput.Magic;
            string output = FIGHT.Battle(userInput, PickEnemyMove(), player, enemy);
            combatText.Text = combatText.Text + output;
            playerStats.Text = player.ToString();
            enemyStats.Text = enemy.ToString();
            CombatVisCheck();
        }
        //connects potion button to Potion method
        //Also prints out result of using the method
        private void potionButton_Click(object sender, EventArgs e)
        {
            EInput userInput = EInput.Potion;
            string output = FIGHT.Battle(userInput, PickEnemyMove(), player, enemy);
            combatText.Text = combatText.Text + output;
            playerStats.Text = player.ToString();
            enemyStats.Text = enemy.ToString();
            CombatVisCheck();
        }

        private EInput PickEnemyMove()
        {
            if (enemy is EMage)
            {
                return (enemy as EMage).MCombatAI();
            }
            if (enemy is ERogue)
            {
                return (enemy as ERogue).RCombatAI();
            }
            if (enemy is EWarrior)
            {
                return (enemy as EWarrior).WCombatAI();
            }
            return EInput.Defend;
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
            if (enemy != null)
            {
                CombatVisCheck();
            }
            if (!FIGHT.Combat)
            {
                switch (e.KeyCode)
                {
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
                dungeon.Update();
                dungeon.RenderDungeon((int)player.PositionX, (int)player.PositionY);
            }
        }
    }
}
