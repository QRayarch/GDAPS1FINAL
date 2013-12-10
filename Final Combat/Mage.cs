using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Combat
{
    class Mage : Character
        //inherits from Base
    {   //passes in variables and sets _positionX and _positionY
        public Mage(int _positionX, int _positionY, int _health, int _strength, int _constitution,
           int _dexterity, int _wisdom, int _defense, Brush color)
            : base(_positionX, _positionY, _health, _strength, _constitution, _dexterity, _wisdom, _defense, 'M', color)
       {
       }
       /// <summary>
       /// sets values to variables 
       /// </summary>
       /// <param name="_positionX">X coordinate of player's position</param>
       /// <param name="_positionY">Y coordinate of player's position</param>
       public Mage(int _positionX, int _positionY, Brush color)
           : base (_positionX, _positionY, 15, 4, 6, 9, 10, 0, 'M', color)
       {
       }

       public Mage(int _positionX, int _positionY)
           : this (_positionX, _positionY, Brushes.PowderBlue)
       {
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
       /// <summary>
       /// simulates using a potion
       /// </summary>
       /// <returns>health after use</returns>
       public override int Potion()
       {
           health = health + randRoll.Next(1, 9);
           return health;
       }
    }
}
