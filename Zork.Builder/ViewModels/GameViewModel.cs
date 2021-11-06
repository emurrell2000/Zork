using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using Zork.Common;

namespace Zork.Builder
{
    internal class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsGameLoaded { get; set; }

        public BindingList<Room> Rooms { get; set; }

        public string WelcomeMessage { get; set; }
        public string ExitMessage { get; set; }
        public string StartingLocation { get; set; }

        public Game Game
        {
            set
            {
                if (_game != value)
                {
                    _game = value;
                    if (_game != null)
                    {
                        Rooms = new BindingList<Room>(_game.World.Rooms);
                        WelcomeMessage = _game.WelcomeMessage;
                        ExitMessage = _game.ExitMessage;
                        StartingLocation = _game.StartingLocation;
                    }
                    else
                    {
                        Rooms = new BindingList<Room>(Array.Empty<Room>());
                        WelcomeMessage = "Welcome to Zork!";
                        ExitMessage = "Thank you for playing!";
                        StartingLocation = "";
                    }
                }
            }
        }

        public void SaveGame(string filename)
        {
            if (!IsGameLoaded)
            {
                throw new InvalidOperationException("No game loaded.");
            }

            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new InvalidProgramException("Invalid filename.");
            }

            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };
            using (StreamWriter streamWriter = new StreamWriter(filename))
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonWriter, _game);
            }
        }

        private Game _game;
    }
}
