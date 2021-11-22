using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Zork
{
    public class Game
    {
        public string StartingLocation { get; set; }

        [JsonIgnore]
        public Player Player { get; private set; }

        public string WelcomeMessage { get; set; }

        public string ExitMessage { get; set; }

        public World World { get; set; }

        public bool IsRunning { get; set; }

        public IOutputService Output { get; set; }
        public IInputService Input { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Player = new Player(World);
            Player.CurrentRoom = World.RoomsByName[StartingLocation];
            Player.MoveCount = 0;
            Player.Score = 0;
        }

        public void Start(IInputService input, IOutputService output)
        {
            Assert.IsNotNull(input);
            Input = input;
            Input.InputRecieved += InputRecievedHandler;

            Assert.IsNotNull(output);
            Output = output;

            IsRunning = true;            
        }

        private void InputRecievedHandler(object sender, string commandString)
        {

            Commands command = ToCommand(commandString);

            switch (command)
            {
                case Commands.QUIT:
                    Output.WriteLine(ExitMessage);
                    Player.MoveCount++; // effectively doesn't do anything but it's fun :)
                    break;

                case Commands.LOOK:
                    Output.WriteLine(Player.CurrentRoom.Description);
                    Player.MoveCount++;
                    break;

                case Commands.NORTH:
                case Commands.SOUTH:
                case Commands.EAST:
                case Commands.WEST:
                    Directions direction = (Directions)command;
                    if (Player.Move(direction) == false)
                    {
                        Output.WriteLine("The way is shut!");
                    }
                    Player.MoveCount++;
                    break;

                case Commands.SCORE:
                    Player.MoveCount++;
                    Output.WriteLine($"Your score would be {Player.Score}, in {Player.MoveCount} move(s).");
                    break;

                case Commands.REWARD:
                    Player.MoveCount++;
                    Player.Score++;
                    break;

                default:
                    Output.WriteLine("Unknown command.");
                    break;
            }
        }

        private static Commands ToCommand(string commandString) => Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
    }
}
