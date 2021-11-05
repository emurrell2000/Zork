using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Zork.Builder
{
    public partial class MainForm : Form
    {
        private GameViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                if (_viewModel != value)
                {
                    _viewModel = value;
                    gameViewModelBindingSource.DataSource = _viewModel;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            ViewModel = new GameViewModel();
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string jsonString = File.ReadAllText(openFileDialog.FileName);
                ViewModel.Game = JsonConvert.DeserializeObject<Game>(jsonString);
            }
        }

        private GameViewModel _viewModel;

        private void newMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented");
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (AddRoomForm addRoomForm = new AddRoomForm())
            {
                if (addRoomForm.ShowDialog() == DialogResult.OK)
                {
                    Room room = new Room(addRoomForm.RoomName);
                    ViewModel.Rooms.Add(room);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented");
        }
    }
}
