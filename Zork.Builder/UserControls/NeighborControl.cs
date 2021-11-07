using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zork.Builder
{
    public partial class NeighborControl : UserControl
    {
        public static readonly Room NoNeighbor = new Room("None");

        public Room Room
        {
            get => _room;
            set
            {
                if (_room != value)
                {
                    _room = value;
                    if (Room != null)
                    {
                        // var neighborList = new BindingList<Room>();
                        ViewModel.Rooms.Insert(0, NoNeighbor);
                        neighborComboBox.SelectedIndexChanged -= NeighborComboBox_SelectedIndexChanged;
                        // neighborComboBox.DataSource = neighborList;
                        

                        if (_room.Neighbors.TryGetValue(Direction, out Room neighbor))
                        {
                            neighborComboBox.SelectedItem = neighbor;
                        }
                        else
                        {
                            neighborComboBox.SelectedItem = NoNeighbor;
                        }

                        neighborComboBox.SelectedIndexChanged += NeighborComboBox_SelectedIndexChanged;
                    }
                }
                else
                {
                    neighborComboBox.DataSource = null;
                }
            }
        }

        public NeighborControl(Directions neighborDirection, Room room)
        {
            Direction = neighborDirection;
            Room = room ?? throw new ArgumentNullException(nameof(room));
        }

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

        private void NeighborComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_room != null)
            {
                Room selectedNeighbor = (Room)neighborComboBox.SelectedItem;
                if (selectedNeighbor == NoNeighbor)
                {
                    _room.Neighbors.Remove(Direction);
                }
                else
                {
                    _room.Neighbors[Direction] = selectedNeighbor;
                }
            }
        }

        public NeighborControl()
        {
            InitializeComponent();
            ViewModel = new GameViewModel();
            gameViewModelBindingSource.DataSource = ViewModel;
        }

        public Directions Direction
        {
            get => _neighborDirection;
            set
            {
                _neighborDirection = value;
                directionTextBox.Text = value.ToString();
            }
        }

        private GameViewModel _viewModel;
        private Room _room;
        private Directions _neighborDirection;
    }
}
