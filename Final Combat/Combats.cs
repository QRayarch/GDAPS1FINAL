using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Combat
{
    enum EInput //enum for player input
    {
        Attack = 1,
        Defend = 2,
        Magic = 3,
        Potion = 4
    }
    
    class Combats
    {

        static Random roll; //random for battle-end regen

        public Combats()
        {
            roll = new Random();
        }

        /// <summary>
        /// Checks if the player is alive.
        /// </summary>
        /// <param name="health"></param>
        /// <returns></returns>
        public bool IsAlive(int health) 
        {
            return (health > 0);
        }

        private bool combat = false; //a bool to see if the player is in combat
        /// <summary>
        /// Gets and sets the boolean to check if the player is in combat. 
        /// </summary>
        public bool Combat { get { return combat; } set { combat = value; } }

        string output = ""; //output for the text box

        /// <summary>
        /// The main battle method that executes the player and enemy actions. 
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="enemyInput"></param>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public string Battle(EInput userInput, EInput enemyInput, Base player, Base enemy) 
        {
            output = "";
            bool pFirst = (player.Dexterity >= enemy.Dexterity); //who goes first
            if (combat == true)
            {
                if (pFirst == true) //if player first
                {

                    if (player.Health > 0) //checks if the player is still alive
                    {
                        int playerOut = player.Combat(userInput, player, enemy); //performs the player action and prints an appropriate output
                        if (userInput == EInput.Potion)
                            output = output + "\nYou heal for " + playerOut + ".";
                        else if (userInput == EInput.Defend)
                            output = output + "\nYou defend for " + playerOut + ".";
                        else
                            output = output + "\nYou deal " + playerOut + " damage.";
                    }
                    else
                        combat = false;
                    if (enemy.Health > 0) //enemy action
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

                else //if enemy first
                {
                    int enemyOut = enemy.Combat(userInput, enemy, player);
                    if (enemyInput == EInput.Potion)
                        output = output + "\nThey heal for " + enemyOut + ".";
                    else if (enemyInput == EInput.Defend)
                        output = output + "\nThey defend for " + enemyOut + ".";
                    else
                        output = output + "\nThey deal " + enemyOut + " damage.";
                    if (player.Health > 0) //player's turn if alive
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
            if ((player.Health > 0) == true && (enemy.Health > 0) == false) //victory
            {
                player.Health += roll.Next(1, 11);
                output = output + "\nYou win!";
            }
            else if ((player.Health > 0) == false) //defeat
                output = output + "\n You have died!";
            return output;
        }
    }
}
