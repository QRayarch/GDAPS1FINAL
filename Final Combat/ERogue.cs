using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Combat
{
    class ERogue : Rogue
    {
        /// <summary>
        /// sets values to variables 
        /// </summary>
        /// <param name="_positionX">X coordinate of player's position</param>
        /// <param name="_positionY">Y coordinate of player's position</param>
        public ERogue(int _positionX, int _positionY)
            : base(_positionX, _positionY, 18, 4, 4, 4, 4, 4, Brushes.Maroon)
        {
            isEnemy = true;
        }
        //simulates attacking
        public override int Attack()
        {
            return strength + randRoll.Next(1, 7);
        }
        //simulates magic
        public override int Magic()
        {
            return wisdom + randRoll.Next(1, 7);
        }
        /// <summary>
        /// simulates defence
        /// </summary>
        /// <param name="_damage">defends against damage passed in from opponent</param>
        /// <returns>total damage after calculations</returns>
        public override int Defend()
        {
            defense = defense + randRoll.Next(1, 11);
            return defense;
        }
        /// <summary>
        /// Enemy ai for making decisions during battle 
        /// </summary>
        /// <param name="health">the enemy's health stat</param>
        /// <returns>the choice of action the enemy makes</returns>
        public EInput RCombatAI()
        {
            EInput enemyAction;
            if (health > 6)
            {
                int decision = randRoll.Next(1, 4);
                if (decision == 1)
                    enemyAction = EInput.Magic;
                else
                    enemyAction = EInput.Attack;
            }
            else
            {
                int decision = randRoll.Next(1, 5);
                if (decision == 1)
                    enemyAction = EInput.Attack;
                else if (decision == 2)
                    enemyAction = EInput.Defend;
                else if (decision == 3)
                    enemyAction = EInput.Magic;
                else
                    enemyAction = EInput.Potion;
            }
            return enemyAction;
        }
    }
}
