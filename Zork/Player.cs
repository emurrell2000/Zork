using Newtonsoft.Json;
using System;

namespace Zork
{
    public class Player
    {
        public World World { get; }

        [JsonIgnore]
        public Room CurrentRoom { get; set; }

        [JsonIgnore]
        public Room PreviousRoom { get; set; }

        public Player(World world)
        {
            World = world;
        }

        public bool Move(Directions direction)
        {
            bool isValidMove = CurrentRoom.Neighbors.TryGetValue(direction, out Room neighbor);
            if (isValidMove)
            {
                CurrentRoom = neighbor;
            }

            return isValidMove;
        }
    }
}
