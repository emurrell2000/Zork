﻿using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Zork
{
    public class Game
    {
        public World World { get; set; }

        public string StartingLocation { get; set; }

        [JsonIgnore]
        public Player Player { get; private set; }

        public string WelcomeMessage { get; set; }

        public string ExitMessage { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Player = new Player(World);
            Player.CurrentRoom = World.RoomsByName[StartingLocation];
            Player.MoveCount = 0;
            Player.Score = 0;
        }

        public void Run()
        {
            Console.WriteLine(WelcomeMessage);

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(Player.CurrentRoom);
                if (Player.PreviousRoom != Player.CurrentRoom)
                {
                    Console.WriteLine(Player.CurrentRoom.Description);
                    Player.PreviousRoom = Player.CurrentRoom;
                }
                Console.Write("> ");

                command = ToCommand(Console.ReadLine().Trim());
            
                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine(ExitMessage);
                        Player.MoveCount++; // effectively doesn't do anything but it's fun :)
                        break;
            
                    case Commands.LOOK:
                        Console.WriteLine(Player.CurrentRoom.Description);
                        Player.MoveCount++;
                        break;
            
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        Directions direction = Enum.Parse<Directions>(command.ToString(), true);
                        if (Player.Move(direction) == false)
                        {
                            Console.WriteLine("The way is shut!");
                        }
                        Player.MoveCount++;
                        break;

                    case Commands.SCORE:
                        Player.MoveCount++;
                        Console.WriteLine($"Your score would be {Player.Score}, in {Player.MoveCount} move(s).");
                        break;

                    case Commands.REWARD:
                        Player.MoveCount++;
                        Player.Score++;
                        break;
            
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }
        private static Commands ToCommand(string commandString) => Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
    }
}