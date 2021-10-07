using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Zork
{
    public class Room
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        [JsonIgnore]
        public Dictionary<Directions, Room> Neighbors { get; set; }

        [JsonProperty(PropertyName = "Neighbors")]
        public Dictionary<Directions, string> NeighborNames { get; set; }

        public Room(string name, string description = "")
        {
            Name = name;
            Description = description;
        }

        public void UpdateNeighbors(World world)
        {
            Neighbors = new Dictionary<Directions, Room>();
            foreach (var (direction, name) in NeighborNames)
            {
                Neighbors.Add(direction, world.RoomsByName[name]);
            }
        }

        public override string ToString() => Name;

    }
}