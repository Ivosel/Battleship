using System.Data.Common;
using Vsite.Oom.Battleship.Model;

namespace BattleshipGUI
{
    public partial class Form1 : Form
    {
        private FleetBuilder fleetGenerator;
        private Fleet playerFleet;
        private Fleet computerFleet;
        private FleetGrid playerGrid;
        private RecordGrid computerGrid;
        private readonly GameRules rules;
        private Gunnery computerGunnery;


        public Form1()
        {
            rules = new GameRules();
            playerGrid = new FleetGrid(10, 10);
            computerGrid = new RecordGrid(10, 10);
            computerGunnery = new Gunnery(rules);
            fleetGenerator = new FleetBuilder(rules);
            playerFleet = fleetGenerator.CreateFleet();
            computerFleet = fleetGenerator.CreateFleet();
            InitializeComponent();
        }

        private void newFleetButton_Click(object sender, EventArgs e)
        {
            playerFleet = fleetGenerator.CreateFleet();
            foreach (Button button in myGrid.buttons)
            {
                button.BackColor = default;
            }
            myGrid_Load(this, EventArgs.Empty);
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            newFleetButton.Enabled = false;
        }

        private void myGrid_Load(object sender, EventArgs e)
        {
            foreach (Ship ship in playerFleet.Ships)
            {
                foreach (Square square in ship.Squares)
                {
                    myGrid.buttons[square.Row, square.Column].BackColor = Color.Blue;
                }
            }
            myGrid.Refresh();
        }

        private void opponentGrid_Load(object sender, EventArgs e)
        {
            opponentGrid.AttachOpponentButtonClickEvent(RecordGridButtonClick);
        }

        private void RecordGridButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridButton gridButton = (GridButton)button;

            int row = gridButton.Row;
            int column = gridButton.Column;

            foreach (Ship ship in computerFleet.Ships)
            {
                foreach (Square square in ship.Squares)
                {
                    if (row == square.Row && column == square.Column) opponentGrid.buttons[row, column].BackColor = Color.Red;
                }
            }

            ComputerMove();
        }


        private GridButton GetPlayerGridButton(Square target)
        {
            foreach (GridButton button in myGrid.Controls)
            {
                if (button.Row == target.Row && button.Column == target.Column)
                {
                    return button;
                }
            }
            return null;
        }


        private void UpdatePlayerGridButton(Square target, HitResult result)
        {
            GridButton button = GetPlayerGridButton(target);

            switch (result)
            {
                case HitResult.Hit:
                    button.BackColor = Color.Red;
                    break;
                case HitResult.Sunk:
                    button.BackColor = Color.DarkRed;
                    break;
                case HitResult.Missed:
                    button.BackColor = Color.Gray;
                    break;
                default:
                    button.BackColor = SystemColors.Control;
                    break;
            }

        }

        private void ComputerMove()
        {
            Square target = computerGunnery.NextTarget();

            HitResult result = playerFleet.Fire(target);

            computerGunnery.ProcessHitResult(result);

            UpdatePlayerGridButton(target, result);

        }
    }

}