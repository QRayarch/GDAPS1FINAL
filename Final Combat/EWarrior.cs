using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Combat
{
    class EWarrior : Warrior
    {
        /// <summary>
        /// sets values to variables 
        /// </summary>
        /// <param name="_positionX">X coordinate of player's position</param>
        /// <param name="_positionY">Y coordinate of player's position</param>
        public EWarrior(int _positionX, int _positionY)
            : base(_positionX, _positionY, 30, 8, 5, 5, 3, 4, Brushes.PeachPuff)
        {
            isEnemy = true;
        }
        //simulates attacking
        public override int Attack()
        {
            return strength + randRoll.Next(1, 11);
        }
        //simulates magic
        public override int Magic()
        {
            return wisdom + randRoll.Next(1, 5);
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
        public EInput WCombatAI()
        {
            EInput enemyAction;
            if (health > 5)
                enemyAction = EInput.Attack;
            else
            {
                int decision = randRoll.Next(1, 4);
                if (decision == 1)
                    enemyAction = EInput.Defend;
                else
                    enemyAction = EInput.Attack;
            }
            return enemyAction;
        }
    }
}
