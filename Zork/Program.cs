using Newtonsoft.Json;
using System;
using System.IO;

namespace Zork
{
    class Program
    {
        public static Room CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }

        static void Main(string[] args)
        {
            const string roomDescriptionsFilename = "Rooms.json";

            string gameFilename = args.Length > 0 ? args[(int)CommandLineArguments.GameFilename] : roomDescriptionsFilename;

            InitializeRoomDescriptions(gameFilename);

            Console.WriteLine("Welcome to Zork!");

            Room previousRoom = null;
            
            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom);
                if (previousRoom != CurrentRoom)
                {
                    Console.WriteLine(CurrentRoom.Description);
                    previousRoom = CurrentRoom;
                }
                Console.Write("> ");
            
                command = ToCommand(Console.ReadLine().Trim());
            
                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing!");
                        break;
            
                    case Commands.LOOK:
                        Console.WriteLine(CurrentRoom.Description);
                        break;
            
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command) == false)
                        {
                            Console.WriteLine("The way is shut!");
                        }
                        break;
            
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }

        private static bool Move(Commands command)
        {
        bool didMove = true;

        switch (command)
        {
            case Commands.NORTH when Location.Row < Rooms.GetLength(0) - 1:
                Location.Row++;
                break;
        
            case Commands.SOUTH when Location.Row > 0:
                Location.Row--;
                break;
        
            case Commands.EAST when Location.Column < Rooms.GetLength(1) - 1:
                Location.Column++;
                break;
        
            case Commands.WEST when Location.Column > 0:
                Location.Column--;
                break;
        
            default:
                didMove = false;
                break;
        }
        
        return didMove;
        }

        private static Commands ToCommand(string commandString) => Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN;

        private static void InitializeRoomDescriptions(string roomsFilename) => Rooms = JsonConvert.DeserializeObject<Room[,]>(File.ReadAllText(roomsFilename));

        private static Room[,] Rooms = {
            { new Room("Rocky Trail"), new Room("South of House"), new Room("Canyon View") },
            { new Room("Forest"), new Room("West of House"), new Room("Behind House") },
            { new Room("Dense Woods"), new Room("North of House"), new Room("Clearing") }
        };

        private static (int Row, int Column) Location = (1, 1);

        private enum CommandLineArguments
        {
            GameFilename = 0
        }
    }

}
