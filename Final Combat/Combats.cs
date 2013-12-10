using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Combat
{   // stores options for the enemy ai to choose
    public enum EInput
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

        /// <summary>
        /// Performs a round of combat based on player and enemy inputs. 
        /// </summary>
        /// <param name="userInput">Player's input</param>
        /// <param name="enemyInput">Enemy's input</param>
        /// <param name="player">Player</param>
        /// <param name="enemy">Enemy</param>
        /// <returns></returns>
        public string Battle(EInput userInput, EInput enemyInput, Character player, Character enemy)
        {
            output = "";
            if (combat == true)
            {
                BattleAction(userInput, enemyInput, player, enemy);
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

        /// <summary>
        /// Executes player and enemy actions.
        /// </summary>
        /// <param name="firstInput">Player action</param>
        /// <param name="secondInput">Enemy action</param>
        /// <param name="first">Player</param>
        /// <param name="second">Enemy</param>
        /// <returns></returns>
        public string BattleAction(EInput firstInput, EInput secondInput, Character first, Character second)
        {
            string whoFirst = "You ";
            string whoSecond = "They ";
            Console.WriteLine(first.Dexterity + "\n" + second.Dexterity);
            if (first.Dexterity > second.Dexterity)
            {
                whoFirst = "They ";
                Console.WriteLine("swap");
                whoSecond = "You ";
            }
            if (first.Health > 0)
            {
                int firstOut = first.Combat(firstInput, second);

                if (firstInput == EInput.Potion)
                    output = output + "\n" + whoFirst + "heal for " + firstOut + ".";
                else if (firstInput == EInput.Defend)
                    output = output + "\n" + whoFirst + "defend for " + firstOut + ".";
                else
                    output = output + "\n" + whoFirst + "deal " + firstOut + " damage.";
            }
            else
                combat = false;

            if (second.Health > 0)
            {
                int secondOut = second.Combat(secondInput, first);

                if (secondInput == EInput.Potion)
                    output = output + "\n" + whoSecond + "heal for " + secondOut + ".";
                else if (secondInput == EInput.Defend)
                    output = output + "\n" + whoSecond + "defend for " + secondOut + ".";
                else
                    output = output + "\n" + whoSecond + "deal " + secondOut + " damage.";
            }
            else
                combat = false;
            return output;
        }
    }
}
