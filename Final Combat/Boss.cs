using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Combat
{
    class Boss : Mage
    {
        /// <summary>
        /// sets values to variables 
        /// </summary>
        /// <param name="_positionX">X coordinate of player's position</param>
        /// <param name="_positionY">Y coordinate of player's position</param>
        public Boss(int _positionX, int _positionY)
            : base(_positionX, _positionY, 100, 15, 15, 15, 15, 5, Brushes.CornflowerBlue)
        {
            isEnemy = true;
        }
        //simulates attacking
        public override int Attack()
        {
            return strength + randRoll.Next(1, 5);
        }
        //simulates magic
        public override int Magic()
        {
            return wisdom + randRoll.Next(1, 11);
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

        public override int Potion()
        {
            health = health + randRoll.Next(10, 21);
            return health;
        }

        /// <summary>
        /// Enemy ai for making decisions during battle 
        /// </summary>
        /// <param name="health">the enemy's health stat</param>
        /// <returns>the choice of action the enemy makes</returns>
        public EInput MCombatAI()
        {
            EInput enemyAction;
            if (health > 8)
                enemyAction = EInput.Magic;
            else if (health > 5 && health <= 8)
            {
                int decision = randRoll.Next(1, 4);
                if (decision == 1)
                    enemyAction = EInput.Defend;
                else
                    enemyAction = EInput.Magic;
            }
            else
            {
                int decision = randRoll.Next(1, 4);
                if (decision == 1)
                    enemyAction = EInput.Potion;
                else
                    enemyAction = EInput.Defend;
            }
            return enemyAction;
        }
    }
}
