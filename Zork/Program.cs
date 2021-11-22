using System;
using System.IO;
using Newtonsoft.Json;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.json";
            string gameFilename = args.Length > 0 ? args[(int)CommandLineArguments.GameFilename] : defaultGameFilename;

            Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(gameFilename));

            ConsoleInputService input = new ConsoleInputService();
            ConsoleOutputService output = new ConsoleOutputService();

            game.Output.WriteLine(game.WelcomeMessage);

            game.Start(input, output);

            Room previousRoom = null;
            while (game.IsRunning)
            {
                output.WriteLine(game.Player.CurrentRoom);
                if (previousRoom != game.Player.CurrentRoom)
                {
                    output.WriteLine(game.Player.CurrentRoom.Description);
                    previousRoom = game.Player.CurrentRoom;
                }

                output.Write("> ");
                input.ProcessInput();
            }

            game.Output.WriteLine(game.ExitMessage);
        }

        private enum CommandLineArguments
        {
            GameFilename = 0
        }
    }

}
