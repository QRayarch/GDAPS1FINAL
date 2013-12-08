using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Combat
{
    class EMage : Mage
    {
        /// <summary>
        /// sets values to variables 
        /// </summary>
        /// <param name="_positionX">X coordinate of player's position</param>
        /// <param name="_positionY">Y coordinate of player's position</param>
        public EMage(int _positionX, int _positionY)
            : base (_positionX, _positionY, 10, 7, 6, 9, 5, 0)
        {
        }
        /// <summary>
        /// gives enemy ai for movement. Compares enemy position to user
        /// and makes a decision to get closer to the player 
        /// </summary>
        /// <param name="_positionX">enemy's X coordinate</param>
        /// <param name="_positionY">enemy's Y coordinate</param>
        public void Movement(int _positionX, int _positionY)
        {
            if (_positionX > this.positionX)
                velocityX = 1;

            else if (_positionX < this.positionX)
                velocityX= -1;

            if (_positionX > this.positionX)
                velocityX = 1;

            else if (_positionY < this.positionY)
                velocityX=  -1;
        }
        //simulates attacking
        public override int Attack()
        {
            damage = strength + randRoll.Next(1, 5);
            return damage;
        }
        //simulates magic
        public override int Magic()
        {
            damage = wisdom + randRoll.Next(1, 11);
            return damage;
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
        public EInput MCombatAI(int health)
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public override int Combat(EInput input, Base attacker, Base defender)
        {
            int output = 0;
            switch (input)
            {
                case EInput.Attack:
                    output = attacker.Attack();
                    defender.Health -= (output - defender.Defense);
                    if (defender.Defense < output)
                        defender.Defense = 0;
                    else
                        defender.Defense -= output;
                    break;
                case EInput.Defend:
                    output = 0;
                    break;
                case EInput.Magic:
                    output = attacker.Magic();
                    defender.Health -= (output - defender.Defense);
                    break;
                case EInput.Potion:
                    output = attacker.Potion();
                    attacker.Health += output;
                    break;
            }
            return output;
        }
    }
}

