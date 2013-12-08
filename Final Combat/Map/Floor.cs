using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RougeMap.MapStuff
{
    class Floor
    {
        public static Random random = new Random();

        public const int VIEW_AREA_WIDTH = 33;
        public const int VIEW_AREA_HEIGHT = 21;

        private const int MIN_ROOM_SIZE = 5;
        private const int MAX_ROOM_SIZE = 18;

        public float charSize = 16;
        private DisplayChar[,] tiles;
        private List<Rectangle> rooms = new List<Rectangle>();

        public int FloorWidth 
        { 
            get 
            { 
                return tiles.GetLength(0); 
            } 
        }
        public int FloorHeight 
        {
            get
            {
                return tiles.GetLength(1);
            }
        }

        private Font renderFont;

        public Floor(PictureBox viewport, int w, int h)
        {
            tiles = new DisplayChar[w, h];
            GenerateLevel();

            charSize = viewport.Width / VIEW_AREA_WIDTH;
            renderFont = new Font(FontFamily.GenericMonospace, charSize);
        }

        private void GenerateLevel()
        {
            FillSpaceWithCharacter(0, 0, FloorWidth, FloorHeight, 'W', Brushes.Gray);
            for (int r = 0; r < random.Next(6, 20); r++)
            {
                EmptyRoomSpace(CreateRoom());
            }

            for (int c = 0; c < rooms.Count; c++)
            {
                int roomToConnectToIndex = c;
                while (roomToConnectToIndex == c)
                {
                    roomToConnectToIndex = random.Next(0, rooms.Count);
                }
                ConnectRoomsByCoridoor(rooms[c], rooms[roomToConnectToIndex]);
            }

            Rectangle upStairsRoom = rooms[random.Next(0, rooms.Count)];
            tiles[random.Next(upStairsRoom.X + 1, upStairsRoom.X + upStairsRoom.Width), random.Next(upStairsRoom.Y + 1, upStairsRoom.Y + upStairsRoom.Height)] = new DisplayChar('=', Brushes.Brown);
            Rectangle downStairsRoom = rooms[random.Next(0, rooms.Count)];
            tiles[random.Next(downStairsRoom.X + 1, downStairsRoom.X + downStairsRoom.Width), random.Next(downStairsRoom.Y + 1, downStairsRoom.Y + downStairsRoom.Height)] = new DisplayChar('=', Brushes.Brown);
        }

        private Rectangle CreateRoom()
        {
            int roomWidth = random.Next(MIN_ROOM_SIZE, MAX_ROOM_SIZE);
            int roomHeight = random.Next(MIN_ROOM_SIZE, MAX_ROOM_SIZE);
            return new Rectangle(random.Next(1, FloorWidth - roomWidth), random.Next(1, FloorHeight - roomHeight), roomWidth, roomHeight);
        }

        private void EmptyRoomSpace(Rectangle room)
        {
            rooms.Insert(random.Next(0, rooms.Count) ,room);
            FillSpaceWithCharacter(room.X, room.Y, room.X + room.Width, room.Y + room.Height, '.', Brushes.DarkSlateGray);
        }

        private void ConnectRoomsByCoridoor(Rectangle roomOne, Rectangle roomTwo)
        {
            if (roomOne == roomTwo)
            {
                return;
            }
            Point pointInRoomOne = new Point(random.Next(roomOne.X+1, roomOne.X + roomOne.Width), random.Next(roomOne.Y+1, roomOne.Y + roomOne.Height));
            Point pointInRoomTwo = new Point(random.Next(roomTwo.X+1, roomTwo.X + roomTwo.Width), random.Next(roomTwo.Y+1, roomTwo.Y + roomTwo.Height));
            ConnectCoridoor(pointInRoomOne, pointInRoomTwo);
        }

        private void ConnectCoridoor(Point pointOne, Point pointTwo)
        {
            int deltX = Math.Abs(pointOne.X - pointTwo.X);
            int deltY = Math.Abs(pointOne.Y - pointTwo.Y);
            if (pointOne.X > pointTwo.X)
            {
                int tmp = pointOne.X;
                pointOne.X = pointTwo.X;
                pointTwo.X = tmp;
            }
            if (pointOne.Y > pointTwo.Y)
            {
                int tmp = pointOne.Y;
                pointOne.Y = pointTwo.Y;
                pointTwo.Y = tmp;
            }
            FillSpaceWithCharacter(pointOne.X, pointOne.Y, pointTwo.X, pointOne.Y+1, '.', Brushes.DarkSlateGray);
            FillSpaceWithCharacter(pointTwo.X, pointOne.Y, pointTwo.X+1, pointTwo.Y, '.', Brushes.DarkSlateGray);
            FillSpaceWithCharacter(pointOne.X, pointTwo.Y, pointTwo.X, pointTwo.Y + 1, '.', Brushes.DarkSlateGray);
            FillSpaceWithCharacter(pointOne.X, pointOne.Y, pointOne.X + 1, pointTwo.Y, '.', Brushes.DarkSlateGray);
        }

        private void FillSpaceWithCharacter(int startX, int startY, int endX, int endY, char character, Brush color)
        {
            for (int x = startX; x < endX; x++)
            {
                for (int y = startY; y < endY; y++)
                {
                    tiles[x, y] = new DisplayChar(character, color);
                }
            }
        }

        private int Clamp(int value, int min, int max)
        {
            return Math.Max(Math.Min(value, max), min);
        }

        public Bitmap RenderFloor(PictureBox viewPort, int cameraX, int cameraY)
        {
            Bitmap bitmap = new Bitmap(viewPort.Width, viewPort.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Black);
            for (int x = Clamp(cameraX, 0, FloorWidth); x < Clamp(cameraX + VIEW_AREA_WIDTH, 0, FloorWidth); x++)
            {
                for (int y = Clamp(cameraY, 0, FloorHeight); y < Clamp(cameraY + VIEW_AREA_HEIGHT, 0, FloorHeight); y++)
                {
                    graphics.DrawString(tiles[x, y].CharToDisplay.ToString(), renderFont,tiles[x,y].BrushColor, (x-cameraX)*charSize, (y-cameraY)*charSize);
                }
            }
            graphics.Dispose();

            return bitmap;
        }
    }
}
