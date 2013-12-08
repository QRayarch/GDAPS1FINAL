using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Combat
{   // stores options for the enemy ai to choose
    enum EInput
    {
        Attack = 1,
        Defend = 2,
        Magic = 3,
        Potion = 4
    }
    
    class Combats
    {
        static Random roll; 
        
        public Combats()
        {
            roll = new Random();
        }

        public bool IsAlive(int health)
        {
            return (health > 0);
        }

        private bool combat = false;
        public bool Combat { get { return combat; } set { combat = value; } }

        string output = "";

        public string Battle(EInput userInput, EInput enemyInput, Character player, Character enemy)
        {
            output = "";
            bool pFirst = (player.Dexterity >= enemy.Dexterity);
            if (combat == true)
            {
                if (pFirst == true)
                {
                    if (player.Health > 0)
                    {
                        int playerOut = player.Combat(userInput, player, enemy);

                        if (userInput == EInput.Potion)
                            output = output + "\nYou heal for " + playerOut + ".";
                        else if (userInput == EInput.Defend)
                            output = output + "\nYou defend for " + playerOut + ".";
                        else
                            output = output + "\nYou deal " + playerOut + " damage.";
                    }
                    else
                        combat = false;

                    if (enemy.Health > 0)
                    {
                        int enemyOut = enemy.Combat(enemyInput, enemy, player);

                        if (enemyInput == EInput.Potion)
                            output = output + "\nThey heal for " + enemyOut + ".";
                        else
                            output = output + "\nThey deal " + enemyOut + " damage.";
                    }
                    else
                        combat = false;
                }

                else
                {
                    int enemyOut = enemy.Combat(userInput, enemy, player);

                    if (enemyInput == EInput.Potion)
                        output = output + "\nThey heal for " + enemyOut + ".";
                    else if (enemyInput == EInput.Defend)
                        output = output + "\nThey defend for " + enemyOut + ".";
                    else
                        output = output + "\nThey deal " + enemyOut + " damage.";

                    if (player.Health > 0)
                    {
                        int playerOut = player.Combat(enemyInput, enemy, player);
                        if (userInput == EInput.Potion)
                            output = output + "\nYou heal for " + playerOut + ".";
                        else
                            output = output + "\nYou deal " + playerOut + " damage.";
                    }
                    else
                        combat = false;
                }
            }

            if ((player.Health > 0) == true && (enemy.Health > 0) == false)
            {
                player.Health += roll.Next(1, 11);
                output = output + "\nYou win!";
            }
            else if ((player.Health > 0) == false)
                output = output + "\n You have died!";
            return output;
        }
    }
}
