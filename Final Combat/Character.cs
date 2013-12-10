using RougeMap.MapStuff;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Combat
{
    public abstract class Character : DisplayChar 
    {
       //basic fields needed for movement and stats
       protected float positionX;
       protected float positionY;

       protected float velocityX;
       protected float velocityY;

       protected int health;
       protected int strength;
       protected int constitution;
       protected int dexterity;
       protected int wisdom;
       protected int defense;

       public bool Alive{get{return health>0;}}

       protected bool isEnemy = false;
       public bool IsEnemy
       {
           get
           {
               return isEnemy;
           }
       }

       //protected int damage;
       //random used throughout the game
       static protected Random randRoll = new Random();
       

       //evaluates player position
       public Character(int _positionX, int _positionY, char enemy, Brush color)
           : base (enemy, color)
       {
           positionX = (int)_positionX;
           positionY = (int)_positionY;  
       }
       //constructor that sets keywords for variables
       public Character(int _positionX, int _positionY, int _health, int _strength, int _constitution,
           int _dexterity, int _wisdom, int defense, char enemy, Brush color)
           : this (_positionX, _positionY, enemy, color)
       {
           positionX = (int)_positionX;
           positionY = (int)_positionY;
           health = _health;
           strength = _strength;
           constitution = _constitution;
           dexterity = _dexterity;
           wisdom = _wisdom;
       }
       //The following properties set the stats, positions, and velocities
       //for the character at the chosen values and return said values
       public int Health
       {
           get { return health; }
           set { health = value; }
       }
       public int Strength
       {
           get { return strength; }
           set { strength = value; }
       }
       public int Constitution
       {
           get { return constitution; }
           set { constitution = value;
           health = constitution * 10;
           }

       }
       public int Dexterity
       {
           get { return dexterity; }
           set { dexterity = value; }
       }
       public int Wisdom
       {
           get { return wisdom; }
           set { wisdom = value; }
       }
       public float VelocityX
       {
           get { return velocityX; }
           set {velocityX = value;}
       }
       public float VelocityY
       {
           get { return velocityY; }
           set { velocityY = value; }
       }
       public float PositionX
       {
           get { return positionX; }
           set { positionX = value; }
       }
       public float PositionY
       {
           get { return positionY; }
           set { positionY = value; }
       }
       public int Defense
       {
           get { return defense; }
           set { defense = value; }
       }
       
       //abstract methods for child classes
       public abstract int Attack();
       public abstract int Magic();
       public abstract int Defend();
       public abstract int Potion();
       public int Combat(EInput input, Character defender)
       {
           int output = 0;
           switch (input)
           {
               case EInput.Attack:
                   output = Attack();
                   if (defender.Defense < output)
                   {
                       defender.Defense = 0;
                       defender.Health -= Math.Max((output - defender.Defense), 0);
                   }
                   else
                       defender.Defense -= output;
                   break;
               case EInput.Defend:
                   output = Defend();
                   break;
               case EInput.Magic:
                   output = Magic();
                   if (defender.Defense < output)
                   {
                       defender.Defense = 0;
                       defender.Health -= Math.Max((output - defender.Defense), 0);
                   }
                   else
                       defender.Defense -= output;
                   break;
               case EInput.Potion:
                   output = Potion();
                   break;
           }
           return output;
       } 
       
       public void Update()
       {
           if (isEnemy)
           {
               Movement((int)(FinalCombat.Player.PositionX), (int)(FinalCombat.Player.PositionY));
           }
           //moves them around with their velocity
           positionX = positionX + velocityX;
           positionY = positionY + velocityY;
           velocityX = 0;
           velocityY = 0;
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
               velocityX = -1;

           if (_positionY > this.positionY)
               velocityY = 1;

           else if (_positionY < this.positionY)
               velocityY = -1;
       }
       /// <summary>
       /// makes a string of the player's or enemy's stats to be printed 
       /// </summary>
       /// <returns>the string of stats</returns>
       public override string ToString()
       {
           return "Strength: " + Strength + "\nConstitution: " + Constitution + "\nDexterity: " + Dexterity + "\nWisdom: " + Wisdom + "\nHealth: " + Health + "\nDefense: " + Defense;
       }
    }
}
