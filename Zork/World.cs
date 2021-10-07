using System.Collections.Generic;
// using System.Linq;
using System.Runtime.Serialization;

namespace Zork
{
    public class World
    {
        public Room[] Rooms { get; set; }

        public Dictionary<string, Room> RoomsByName { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            // one-line option
            // RoomsByName = Rooms.ToDictionary(room => room.Name, room => room);

            RoomsByName = new Dictionary<string, Room>();
            foreach (Room room in Rooms)
            {
                RoomsByName.Add(room.Name, room);
            }

            foreach (Room room in Rooms)
            {
                room.UpdateNeighbors(this);
            }
        }
    }
}
