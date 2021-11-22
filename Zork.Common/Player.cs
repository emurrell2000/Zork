using Newtonsoft.Json;
using System;

namespace Zork
{
    public class Player
    {
        public event EventHandler<Room> LocationChanged;

        public World World { get; }

        [JsonIgnore]
        public Room CurrentRoom
        {
            get
            {
                return _location;
            }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    LocationChanged?.Invoke(this, _location);
                }
            }
        }

        [JsonIgnore]
        public int Score { get; set; }

        [JsonIgnore]
        public int MoveCount { get; set; }

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

        private Room _location;
    }
}
