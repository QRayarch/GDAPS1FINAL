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
           : this (_positionX, _positionY, color)
       {
       }
       /// <summary>
       /// sets values to variables 
       /// </summary>
       /// <param name="_positionX">X coordinate of player's position</param>
       /// <param name="_positionY">Y coordinate of player's position</param>
       public Mage(int _positionX, int _positionY, Brush color)
           : base (_positionX, _positionY, 10, 7, 6, 9, 5, 0, 'M', color)
       {
       }

       public Mage(int _positionX, int _positionY)
           : this (_positionX, _positionY, Brushes.PowderBlue)
       {
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
       /// simulates using a potion
       /// </summary>
       /// <returns>health after use</returns>
       public override int Potion()
       {
           health = health + randRoll.Next(1, 9);
           return health;
       }
       // Allows user to make a choice during combat
       
    }
}
