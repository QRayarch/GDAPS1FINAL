using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RougeMap.MapStuff
{
    class Dungeon
    {
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
            floors.Add(new Floor(viewport, 50,50));
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
