using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Combat
{
    class Warrior : Character//inherits from Base
    {//passes in variables and sets _positionX and _positionY
        public Warrior(int _positionX, int _positionY, int _health, int _strength, int _constitution,
           int _dexterity, int _wisdom, int _defense, Brush color)
            : base (_positionX, _positionY, _health, _strength, 
                _constitution, _dexterity, _wisdom, _defense, 'W', color)
            {
            }

        public Warrior(int _positionX, int _positionY, Brush color)
            : base(_positionX, _positionY, 15, 5, 5, 10, 5, 0, 'W', color)
        {
        }

        public Warrior(int _positionX, int _positionY)
            : this(_positionX, _positionY, Brushes.PowderBlue)
        {
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
        /// simulates using a potion
        /// </summary>
        /// <returns>health after use</returns>
        public override int Potion()
        {
            int healing = randRoll.Next(1, 9);
            health = health + healing;
            return healing;
        }
    }
}
