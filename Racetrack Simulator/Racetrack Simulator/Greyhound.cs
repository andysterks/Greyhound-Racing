using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racetrack_Simulator
{
    public class Greyhound
    {
        public int StartingPosition; // Where my PictureBox starts
        public int RacetrackLength; // How long the racetrack is
        public PictureBox MyPictureBox = null; // My PictureBox object
        public int Location = 0; // My Location on the racetrack
        public Random Randomizer; // An instance of Random
        public string Name;

        public void Run()
        {
            int randomNum = Randomizer.Next(0, 5);
            //int randomNum = 3; // this.Randomizer.Next(0, 5);
                // Move forward either 1, 2, 3 or 4 spaces at random
            MyPictureBox.Left += randomNum;
            // Update the position of my PictureBox on the form like this:
            //      MyPictureBox.Left = Starting Position + Location;
            // Return true if I won the race
        }

        public void TakeStartingPosition()
        {
            this.Location = 0;
            this.StartingPosition = 0;
            MyPictureBox.Left = 112;
        }
        
    }
}
