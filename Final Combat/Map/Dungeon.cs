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

        public Dungeon(PictureBox viewport)
        {
            this.viewport = viewport;
            floors.Add(new Floor(viewport, 50,50));
        }

        public void Update()
        {
            for (int f = 0; f < floors.Count; f++)
            {
                floors[f].Update();
            }
        }

        public Floor GetFloor(int index)
        {
            if (index > 0 && index < floors.Count)
            {
                return floors[index];
            }
            return null;
        }

        public void RenderDungeon(int cameraX, int cameraY)
        {
            viewport.Image = floors[currentFloor].RenderFloor(viewport, cameraX, cameraY);
        }
    }
}
