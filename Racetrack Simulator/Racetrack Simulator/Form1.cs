using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Racetrack_Simulator
{
    public partial class Form1 : Form
    {
        bool gameRunning = false;

        int minBet = 5;
        
        int timeLeft = 30;

        Greyhound[] GreyhoundArray = new Greyhound[4];

        Guy joe = new Guy() { Name = "Joe", Cash = 50};
        Guy bob = new Guy() { Name = "Bob", Cash = 75};
        Guy al = new Guy() { Name = "Al", Cash = 45};

        public Form1()
        {
            InitializeComponent();

            joe.MyLabel = joeBetLabel;
            joe.MyRadioButton = joeRadioButton;
            bob.MyLabel = bobBetLabel;
            bob.MyRadioButton = bobRadioButton;
            al.MyLabel = alBetLabel;
            al.MyRadioButton = alRadioButton;

            minimumBetLabel.Text = "Minimum bet: " + minBet + " bucks";
            
            joeBetLabel.Text = "Joe hasn't placed a bet yet";
            bobBetLabel.Text = "Bob hasn't placed a bet yet";
            alBetLabel.Text = "Al hasn't placed a bet yet";
            
            joeRadioButton.Text = "Joe has " + joe.Cash + " bucks";
            bobRadioButton.Text = "Bob has " + bob.Cash + " bucks";
            alRadioButton.Text = "Al has " + al.Cash + " bucks";
            
            nameLabel.Text = "Joe";

            domainUpDown1.Items.Add("Momma's Boy");
            domainUpDown1.Items.Add("Seattle Slew");
            domainUpDown1.Items.Add("Seabiscuit");
            domainUpDown1.Items.Add("Secretariat");
            domainUpDown1.SelectedIndex = 0;

            Random MyRandomizer = new Random();

            GreyhoundArray[0] = new Greyhound()
            {
                Name = "Momma's Boy",
                MyPictureBox = pictureBox1,
                StartingPosition = pictureBox1.Left,
                RacetrackLength = raceTrackPictureBox.Width - pictureBox1.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[1] = new Greyhound()
            {
                Name = "Seattle Slew",
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = raceTrackPictureBox.Width - pictureBox2.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[2] = new Greyhound()
            {
                Name = "Seabiscuit",
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = raceTrackPictureBox.Width - pictureBox3.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[3] = new Greyhound()
            {
                Name = "Secretariat",
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = raceTrackPictureBox.Width - pictureBox4.Width,
                Randomizer = MyRandomizer
            };

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!gameRunning && timeLeft > 0)
            {
                timeLeft--;
                timerUpdate.Text = timeLeft + " Remaining Until Next Race!";
                grpboxBettingParlor.Enabled = true;
            }
            else
            {
                gameRunning = true;
                timerUpdate.Text = "RACE IN PROGRESS!!!";
                timer2.Enabled = true;
                grpboxBettingParlor.Enabled = false;
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                GreyhoundArray[i].Run();
                
                if (GreyhoundArray[i].MyPictureBox.Left >= 565)
                {
                    // turn off game timer and stop the game from running
                    timer2.Enabled = false;
                    gameRunning = false;
                    
                    // reset the timer until the next race
                    timeLeft = 30;
                    
                    // alert the user who won
                    MessageBox.Show(GreyhoundArray[i].Name + " has won the race!!!!");

                    // payout/collect money from their bets
                    joe.Collect(GreyhoundArray[i].Name);
                    bob.Collect(GreyhoundArray[i].Name);
                    al.Collect(GreyhoundArray[i].Name);
                    
                    // reset greyhounds to starting position
                    GreyhoundArray[0].TakeStartingPosition();
                    GreyhoundArray[1].TakeStartingPosition();
                    GreyhoundArray[2].TakeStartingPosition();
                    GreyhoundArray[3].TakeStartingPosition();
                    break;
                }
            }

        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            { 
                // create a new instance of bet for joe
                joe.MyBet = new Bet() { Bettor = joe };

                // change joe's bet instance to the amount selected on the form
                joe.PlaceBet(Convert.ToInt32(numericUpDown1.Value), domainUpDown1.Items[domainUpDown1.SelectedIndex].ToString());

                // update the labels for the bet that was placed
                joe.UpdateLabels();
            }
            else if (bobRadioButton.Checked)
            {
                // create a new instance of bet for bob
                bob.MyBet = new Bet() { Bettor = bob };

                // change bob's bet instance to the amount selected on form
                bob.PlaceBet(Convert.ToInt32(numericUpDown1.Value), domainUpDown1.Items[domainUpDown1.SelectedIndex].ToString());

                // update the labels for the bet that was placed
                bob.UpdateLabels();
            }
            else
            {
                // create a new instance of bet for al
                al.MyBet = new Bet() { Bettor = al };

                // change al's bet instance to the amount selected on form
                al.PlaceBet(Convert.ToInt32(numericUpDown1.Value), domainUpDown1.Items[domainUpDown1.SelectedIndex].ToString());

                // update the labels for the bet that was placed
                al.UpdateLabels();
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            { nameLabel.Text = "Joe"; }
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bobRadioButton.Checked)
            { nameLabel.Text = "Bob"; }
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (alRadioButton.Checked)
            { nameLabel.Text = "Al"; }
        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            timeLeft = 0;
        }
        
    }
}
