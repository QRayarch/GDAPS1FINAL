using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Combat
{
    class Rogue : Base//inherits from Base
    {//passes in variables and sets _positionX and _positionY
        public Rogue(int _positionX, int _positionY, int _health, int _strength, int _constitution,
           int _dexterity, int _wisdom, int _defense)
           : this (_positionX, _positionY)
       {
       }

        public Rogue(int _positionX, int _positionY)
            : base(_positionX, _positionY, 9, 6, 7, 10, 7, 0)
        {
        }

        public override int Attack()
        {
            damage = strength + randRoll.Next(1, 7);
            return damage;
        }

        public override int Magic()
        {
            damage = wisdom + randRoll.Next(1, 7);
            return damage;
        }

        public override int Defend()
        {
            defense = defense + randRoll.Next(1, 11);
            return defense;
        }

        public override int Potion()
        {
            health = health + randRoll.Next(1, 9);
            return health;
        }

        public override int ChangeHealth()
        {
            health = health - damage;
            return health;
        }

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
