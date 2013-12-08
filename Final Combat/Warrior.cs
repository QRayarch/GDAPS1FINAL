using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Combat
{
    class Warrior : Base//inherits from Base
    {//passes in variables and sets _positionX and _positionY
        public Warrior(int _positionX, int _positionY, int _health, int _strength, int _constitution,
           int _dexterity, int _wisdom, int _defense)
            : base(_positionX, _positionY, _health, _strength, _constitution, _dexterity, _wisdom, _defense)
       {
       }

        public Warrior(int _positionX, int _positionY)
            : base(_positionX, _positionY, 30, 5, 5, 10, 5, 0)
        {
        }
        //simulates attacking
        public override int Attack()
        {
            damage = strength + randRoll.Next(1, 11);
            return damage;
        }
        //simulates magic
        public override int Magic()
        {
            damage = wisdom + randRoll.Next(1, 5);
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
        /// simulates using a potion
        /// </summary>
        /// <returns>health after use</returns>
        public override int Potion()
        {
            int healing = randRoll.Next(1, 9);
            health = health + healing;
            return healing;
        }
        /// <summary>
        /// changes health according to damage dealt
        /// </summary>
        /// <returns>remaining health</returns>
        public override int ChangeHealth()
        {
            health = health - damage;
            return health;
        }
        // Allows user to make a choice during combat
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
                    output = attacker.Defend();
                    break;
                case EInput.Magic:
                    output = attacker.Magic();
                    defender.Health -= (output - defender.Defense);
                    break;
                case EInput.Potion: 
                    output = attacker.Potion();
                    break;
            }
            return output;
        } 
    }
}
