using Final_Combat;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RougeMap.MapStuff
{
    class Dungeon
    {
        private static int floorsVisited = 0;
        /// <summary>
        /// Gets the number of floors visited.
        /// </summary>
        public static int FloorsVisited
        {
            get
            {
                return floorsVisited;
            }
        }
        private List<Floor> floors = new List<Floor>();
        private int currentFloor = 0;
        private PictureBox viewport;

        /// <summary>
        /// Creates a new dungeon with the viewport.
        /// Adds a floor on the first level.
        /// </summary>
        /// <param name="viewport">the viewport to use for rendering.</param>
        public Dungeon(PictureBox viewport)
        {
            this.viewport = viewport;
            floors.Add(new Floor(this, viewport, 50,50));
        }

        /// <summary>
        /// Updates all the floors.
        /// </summary>
        public void Update()
        {
            for (int f = 0; f < floors.Count; f++)
            {
                floors[f].Update();
            }
        }

        /// <summary>
        /// Gets the floor if it is in bounds, otherwise return null.
        /// </summary>
        /// <param name="index">The floor index to get.</param>
        /// <returns>The floor if index is in bounds, else null.</returns>
        public Floor GetFloor(int index)
        {
            if (index > -1 && index < floors.Count)
            {
                return floors[index];
            }
            return null;
        }

        /// <summary>
        /// Moves a chracter up a floor, if it exists, otherwise create a new
        /// floor.
        /// </summary>
        /// <param name="player">The chracter to move up the floor.</param>
        public void MovePlayerUpFloor(Character player)
        {
            currentFloor++;
            Floor floorTravelingTo;
            if (currentFloor >= floors.Count)
            {
                floorTravelingTo = new Floor(this, viewport, 50 + floorsVisited, 50 + floorsVisited);
                floors.Add(floorTravelingTo);
                floorsVisited++;
            }
            else
            {
                floorTravelingTo = floors[currentFloor];
            }
            MovePlayerToFloor(floorTravelingTo.StairsDownLocation, floorTravelingTo, player);
        }

        /// <summary>
        /// Moves a character down a floor if it exists, otherwise create a new floor.
        /// </summary>
        /// <param name="player">The character to move down a floor.</param>
        public void MovePlayerDownFloor(Character player)
        {
            currentFloor--;
            Floor floorTravelingTo;
            if (currentFloor < 0)
            {
                floorTravelingTo = new Floor(this, viewport, 50 + floorsVisited, 50 + floorsVisited);
                floors.Insert(0,floorTravelingTo);
                floorsVisited++;
                currentFloor = 0;
            }
            else
            {
                floorTravelingTo = floors[currentFloor];
            }
            MovePlayerToFloor(floorTravelingTo.StairsUpLocation, floorTravelingTo, player);
        }

        /// <summary>
        /// Handles addeing the chracter to the new floor, and sets the positon of the character to the 
        /// location of the stairs.
        /// </summary>
        /// <param name="stairsLocation">The location of the stairs where the player will end up at.</param>
        /// <param name="floorTravelingTo">The new floor the chracter will be on.</param>
        /// <param name="player">The character to move to the new floor.</param>
        private void MovePlayerToFloor(Point stairsLocation, Floor floorTravelingTo, Character player)
        {
            floorTravelingTo.AddChracter(player);
            player.PositionX = stairsLocation.X;
            player.PositionY = stairsLocation.Y + 1;
            RenderDungeon((int)player.PositionX, (int)player.PositionY);
        }

        /// <summary>
        /// Puts the viewports image to the current floors render.s
        /// </summary>
        /// <param name="cameraX">The camera x position to render at.</param>
        /// <param name="cameraY">The camera y position to render at.</param>
        public void RenderDungeon(int cameraX, int cameraY)
        {
            viewport.Image = floors[currentFloor].RenderFloor(viewport, cameraX, cameraY);
        }
    }
}
