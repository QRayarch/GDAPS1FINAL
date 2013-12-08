using RougeMap.MapStuff;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Combat
{
    abstract class Base : DisplayChar 
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

       protected bool alive;
       public bool Alive{get{return alive;}set{alive = value;}}

       protected int damage;
       //random used throughout the game
       static protected Random randRoll = new Random();
       

       //evaluates player position
       public Base(int _positionX, int _positionY)
           : base ('a', Brushes.Aquamarine)
       {
           positionX = (int)_positionX;
           positionY = (int)_positionY;  
       }
       //constructor that sets keywords for variables
       public Base(int _positionX, int _positionY, int _health, int _strength, int _constitution,
           int _dexterity, int _wisdom, int defense)
           : this (_positionX, _positionY)
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
           set { constitution = value; }
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
       public abstract int ChangeHealth();
       public abstract int Combat(EInput input, Base attacker, Base defender);
       
       public void Update()
       {   //moves them around with their velocity
           positionX = positionX + velocityX;
           positionY = positionY + velocityY;
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
