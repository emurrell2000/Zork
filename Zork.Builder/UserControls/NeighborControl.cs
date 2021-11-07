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
                    if (_room != null)
                    {
                        var neighborList = new List<Room>(Rooms);
                        neighborList.Insert(0, NoNeighbor);
                        neighborComboBox.SelectedIndexChanged -= NeighborComboBox_SelectedIndexChanged;
                        neighborComboBox.DataSource = neighborList;

                        if (_room.Neighbors.TryGetValue(Direction, out Room neighbor))
                        {
                            Neighbor = neighbor;
                        }
                        else
                        {
                            Neighbor = NoNeighbor;
                        }

                        neighborComboBox.SelectedIndexChanged += NeighborComboBox_SelectedIndexChanged;
                    }
                    else
                    {
                        neighborComboBox.DataSource = null;
                    }
                }
            }
        }

        public BindingList<Room> Rooms { get; set; }

        public NeighborControl(Directions neighborDirection, Room room)
        {
            Direction = neighborDirection;
            Room = room ?? throw new ArgumentNullException(nameof(room));
        }

        // private GameViewModel ViewModel
        // {
        //     get => _viewModel;
        //     set
        //     {
        //         if (_viewModel != value)
        //         {
        //             _viewModel = value;
        //             gameViewModelBindingSource.DataSource = _viewModel;
        //         }
        //     }
        // }

        private void NeighborComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_room != null)
            {
                Room selectedNeighbor = (Room)Neighbor;
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

        public Room Neighbor
        {
            get => (Room)neighborComboBox.SelectedItem;
            set => neighborComboBox.SelectedItem = value;
        }

        public NeighborControl()
        {
            InitializeComponent();
            // ViewModel = new GameViewModel();
            // gameViewModelBindingSource.DataSource = ViewModel;
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

        // private GameViewModel _viewModel;
        private Room _room;
        private Directions _neighborDirection;
    }
}
