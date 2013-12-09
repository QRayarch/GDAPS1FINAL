using Final_Combat;
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
        public int viewAreaHeight = 21;

        private const int MIN_ROOM_SIZE = 5;
        private const int MAX_ROOM_SIZE = 18;

        public float charSize = 16;

        private List<Rectangle> rooms = new List<Rectangle>();
        private Character[,] characters;

        private Dungeon dungeon;

        private Point stairsUpLocation;
        /// <summary>
        /// Gets the point of the stairs that go up a floor on this floor.
        /// </summary>
        public Point StairsUpLocation
        {
            get
            {
                return stairsUpLocation;
            }
        }
        private Point stairsDownLocation;
        /// <summary>
        /// Gets the point of the stairs that go down a floor on this floor.
        /// </summary>
        public Point StairsDownLocation
        {
            get
            {
                return stairsDownLocation;
            }
        }

        private DisplayChar[,] tiles;
        /// <summary>
        /// Gets the width of this floor in number of characters wide.
        /// </summary>
        public int FloorWidth 
        { 
            get 
            { 
                return tiles.GetLength(0); 
            } 
        }
        /// <summary>
        /// Gets the height of this floor in number of characters high.
        /// </summary>
        public int FloorHeight 
        {
            get
            {
                return tiles.GetLength(1);
            }
        }

        private Font renderFont;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dungeon">The dungeon this floor belongs to.</param>
        /// <param name="viewport">The picturebox that will hold the rendered floor. Used to find the size of the characters to be rendered</param>
        /// <param name="w">The width that this floor will have in number of characters.</param>
        /// <param name="h">The height that this floor will have in number of chracetrs.</param>
        public Floor(Dungeon dungeon, PictureBox viewport, int w, int h)
        {
            this.dungeon = dungeon;
            tiles = new DisplayChar[w, h];
            characters = new Character[w, h];
            GenerateLevel();

            charSize = viewport.Width / VIEW_AREA_WIDTH;
            viewAreaHeight = (int)(Math.Round(viewport.Height / charSize));
            renderFont = new Font(FontFamily.GenericMonospace, charSize);
        }

        /// <summary>
        /// Fills in the floor with rooms, coridoors and enemies.
        /// </summary>
        private void GenerateLevel()
        {
            FillSpaceWithCharacter(0, 0, FloorWidth, FloorHeight, 'O', Brushes.Gray);
            for (int r = 0; r < random.Next(6, 20)+Dungeon.FloorsVisited/5; r++)
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

            Rectangle upStairsRoom = rooms[random.Next(0, rooms.Count/4)];
            stairsUpLocation = new Point(random.Next(upStairsRoom.X + 1, upStairsRoom.X + upStairsRoom.Width), random.Next(upStairsRoom.Y + 1, upStairsRoom.Y + upStairsRoom.Height));
            tiles[stairsUpLocation.X, stairsUpLocation.Y] = new DisplayChar('u', Brushes.Gold);

            Rectangle downStairsRoom = rooms[random.Next(rooms.Count / 4, rooms.Count)];
            stairsDownLocation = new Point(random.Next(downStairsRoom.X + 1, downStairsRoom.X + downStairsRoom.Width), random.Next(downStairsRoom.Y + 1, downStairsRoom.Y + downStairsRoom.Height));
            tiles[stairsDownLocation.X, stairsDownLocation.Y] = new DisplayChar('d', Brushes.Gold);

            GenerateEnemies();
        }

        /// <summary>
        /// Places enemies in the rooms.
        /// </summary>
        private void GenerateEnemies()
        {
            for (int e = 0; e < 2 + Dungeon.FloorsVisited/3 + random.Next(0, Dungeon.FloorsVisited); e++)
            {
                GenerateEnemyInRoom(rooms[random.Next(0, rooms.Count)]);
            }
        }

        /// <summary>
        /// Places a randomly generated enemy in the given room.
        /// </summary>
        /// <param name="room">The room to place a random enemy in.</param>
        private void GenerateEnemyInRoom(Rectangle room)
        {
            int x = random.Next(room.X + 1, room.X + room.Width);
            int y = random.Next(room.Y + 1, room.Y + room.Height);
            if (tiles[x, y].CharToDisplay == '.' && characters[x, y] == null)
            {
                switch (random.Next(0, 3))
                {
                    case 0:
                        AddChracter(new EMage(x, y));
                        break;
                    case 1:
                        AddChracter(new ERogue(x, y));
                        break;
                    case 2:
                        AddChracter(new EWarrior(x, y));
                        break;
                }
            }
        }

        /// <summary>
        /// Randomly creates a room that fits within the floors bounds.
        /// </summary>
        /// <returns>A rectangle which cordinates corispond to the space the room occupies.</returns>
        private Rectangle CreateRoom()
        {
            int roomWidth = random.Next(MIN_ROOM_SIZE, MAX_ROOM_SIZE);
            int roomHeight = random.Next(MIN_ROOM_SIZE, MAX_ROOM_SIZE);
            return new Rectangle(random.Next(1, FloorWidth - roomWidth), random.Next(1, FloorHeight - roomHeight), roomWidth, roomHeight);
        }

        /// <summary>
        /// Clears space in the floor that this room ocupies.
        /// </summary>
        /// <param name="room">The room to add to the room list and to add to the rendering system.</param>
        private void EmptyRoomSpace(Rectangle room)
        {
            rooms.Insert(random.Next(0, rooms.Count) ,room);
            FillSpaceWithCharacter(room.X, room.Y, room.X + room.Width, room.Y + room.Height, '.', Brushes.DarkSlateGray);
        }

        /// <summary>
        /// Connects the two rooms with coridoors by randomly choosing a point within each room.
        /// </summary>
        /// <param name="roomOne">The first room to connect.</param>
        /// <param name="roomTwo">The second room to connect.</param>
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

        /// <summary>
        /// Draws a coridoor between the two points.
        /// </summary>
        /// <param name="pointOne">The first point that the coridoor will connect to.</param>
        /// <param name="pointTwo">The second point that the coridoor will connect to.</param>
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

        /// <summary>
        /// Fills the given space with the given tile chracter to render in the given color.
        /// </summary>
        /// <param name="startX">The start x cordinate to start filling the floor with.</param>
        /// <param name="startY">The start y cordinate to start filling the floor with.</param>
        /// <param name="endX">The end x cordinate to stop filling the floor with.</param>
        /// <param name="endY">The end y cordinate to stop filling the floor with.</param>
        /// <param name="character">The chracter to fill the area with.</param>
        /// <param name="color">The color the character will be rendered with.</param>
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

        /// <summary>
        /// Adds the character to the floor at its given corinates if the space is empty.
        /// </summary>
        /// <param name="character">The character to add to the floor.</param>
        public void AddChracter(Character character)
        {
            int characterPositionX = (int)(character.PositionX);
            int characterPositionY = (int)(character.PositionY);
            if (characters[characterPositionX, characterPositionY] == null)
            {
                characters[characterPositionX, characterPositionY] = character;
            }
        }

        /// <summary>
        /// Removes the chracter from the floor.
        /// </summary>
        /// <param name="character">The chracter to remove.</param>
        public void RemoveCharacter(Character character)
        {
            for (int x = 0; x < characters.GetLength(0); x++)
            {
                for (int y = 0; y < characters.GetLength(1); y++)
                {
                    if (characters[x, y] == character)
                    {
                        characters[x, y] = null;
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Moves all the characters, resolves their collisions.
        /// If the enemies would of collided with the player battle the player.
        /// If the player used a staircase move to the new floor.
        /// </summary>
        public void Update()
        {
            for (int x = 0; x < characters.GetLength(0); x++)
            {
                for (int y = 0; y < characters.GetLength(1); y++)
                {
                    if (characters[x, y] != null)
                    {
                        Character tmpCharacter = characters[x, y];
                        if (tmpCharacter.Alive)
                        {
                            tmpCharacter.Update();
                            int newPositionX = (int)(tmpCharacter.PositionX );
                            int newPositionY = (int)(tmpCharacter.PositionY );
                            if ((characters[newPositionX, newPositionY] != null && characters[newPositionX, newPositionY] != tmpCharacter) || tiles[newPositionX, newPositionY].CharToDisplay != '.')
                            {
                                tmpCharacter.PositionX = x;
                                tmpCharacter.PositionY = y;
                                if (tmpCharacter.IsEnemy && characters[newPositionX, newPositionY] == Form1.Player)
                                {
                                    Form1.EnemyJoin(tmpCharacter);
                                }
                                else if(tmpCharacter == Form1.Player)
                                {
                                    if (tiles[newPositionX, newPositionY].CharToDisplay == 'u')
                                    {
                                        dungeon.MovePlayerUpFloor(tmpCharacter);
                                        RemoveCharacter(tmpCharacter);
                                    }
                                    else if (tiles[newPositionX, newPositionY].CharToDisplay == 'd')
                                    {
                                        dungeon.MovePlayerDownFloor(tmpCharacter);
                                        RemoveCharacter(tmpCharacter);
                                    }
                                }
                            }
                            else
                            {
                                characters[x, y] = null;
                                characters[newPositionX, newPositionY] = tmpCharacter;
                            }
                        }
                        else
                        {
                            characters[x, y] = null;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns the value if it is less than the max and greater than the min. If it is greater than the max
        /// return the max, if it is less than the min return the min.
        /// </summary>
        /// <param name="value">The value to check to see if it is above or bellow the min/max.</param>
        /// <param name="min">The min value this method can return.</param>
        /// <param name="max">The max the value this method can return.</param>
        /// <returns>The value restricted to the range of [min, max]</returns>
        private int Clamp(int value, int min, int max)
        {
            return Math.Max(Math.Min(value, max), min);
        }

        /// <summary>
        /// Renders the the characters in the cameras range,  and the dungeon tiles underneath.
        /// </summary>
        /// <param name="viewPort">The viewport to render this floor to.</param>
        /// <param name="cameraX">The point you want the camera to center on in the x direction.</param>
        /// <param name="cameraY">The point you want the camera to center on in the y direction.</param>
        /// <returns>A bitmap of the rendered floor.</returns>
        public Bitmap RenderFloor(PictureBox viewPort, int cameraX, int cameraY)
        {
            cameraX -= VIEW_AREA_WIDTH / 2;
            cameraY -= viewAreaHeight / 2;
            Bitmap bitmap = new Bitmap(viewPort.Width, viewPort.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Black);

            //Reduce the render area to only to the area the camera can see
            for (int x = Clamp(cameraX, 0, FloorWidth); x < Clamp(cameraX + VIEW_AREA_WIDTH, 0, FloorWidth); x++)
            {
                for (int y = Clamp(cameraY, 0, FloorHeight); y < Clamp(cameraY + viewAreaHeight, 0, FloorHeight); y++)
                {
                    if (characters[x, y] == null)
                    {
                        graphics.DrawString(tiles[x, y].CharToDisplay.ToString(), renderFont, tiles[x, y].BrushColor, (x - cameraX) * charSize, (y - cameraY) * charSize);
                    }
                    else
                    {
                        graphics.DrawString(characters[x, y].CharToDisplay.ToString(), renderFont, characters[x, y].BrushColor, (x - cameraX) * charSize, (y - cameraY) * charSize);
                    }
                }
            }
            graphics.Dispose();

            return bitmap;
        }
    }
}
