﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Combat
{
    class ERogue : Rogue
    {
        /// <summary>
        /// sets values to variables 
        /// </summary>
        /// <param name="_positionX">X coordinate of player's position</param>
        /// <param name="_positionY">Y coordinate of player's position</param>
        public ERogue(int _positionX, int _positionY)
            : base(_positionX, _positionY, 10, 7, 6, 9, 5, 0, Brushes.Maroon)
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
                velocityX = -1;

            if (_positionX > this.positionX)
                velocityX = 1;

            else if (_positionY < this.positionY)
                velocityX = -1;
        }
        //simulates attacking
        public override int Attack()
        {
            damage = strength + randRoll.Next(1, 7);
            return damage;
        }
        //simulates magic
        public override int Magic()
        {
            damage = wisdom + randRoll.Next(1, 7);
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
        public EInput RCombatAI(int health)
        {
            EInput enemyAction;
            if (health > 6)
            {
                int decision = randRoll.Next(1, 4);
                if (decision == 1)
                    enemyAction = EInput.Magic;
                else
                    enemyAction = EInput.Attack;
            }
            else
            {
                int decision = randRoll.Next(1, 5);
                if (decision == 1)
                    enemyAction = EInput.Attack;
                else if (decision == 2)
                    enemyAction = EInput.Defend;
                else if (decision == 3)
                    enemyAction = EInput.Magic;
                else
                    enemyAction = EInput.Potion;
            }
            return enemyAction;
        }
        /// <summary>
        ///Calls methods to activate the user's choice during battle
        /// </summary>
        /// <param name="input">the decision made by the enemy in the ai method</param>
        /// <param name="attacker">the enemy</param>
        /// <param name="defender">the player</param>
        /// <returns></returns>
        public override int Combat(EInput input, Character attacker, Character defender)
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
