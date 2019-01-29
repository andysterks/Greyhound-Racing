using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racetrack_Simulator
{
    public class Guy
    {
        public string Name; // The guy's name
        public Bet MyBet; // An instance of Bet that has his bet
        public int Cash; // How much cash he has
       // The last two fields are the guy's GUI controls on the form
        public RadioButton MyRadioButton; // My RadioButton
        public Label MyLabel; // My Label

        // Set my label to my bet's description, and the label on my
        // radio button to show my cash ("Joe has 43 bucks")
        public void UpdateLabels()
        {
            this.MyLabel.Text = this.MyBet.GetDescription();
            this.MyRadioButton.Text = this.Name + " has " + Cash + " bucks";
        }

        // Reset my bet so it's zero
        public void ClearBet()
        {
            this.MyBet.Amount = 0;
        }
        

        public bool PlaceBet(int BetAmount, string DogToWin)
        {
            // commented out \/\/\/\/
            // Place a new bet and store it in my bet field
            //this.MyBet.Amount = BetAmount;
            //this.MyBet.Dog = DogToWin;

            // Validate that user has enough cash to cover the bet and return true if he does
            if (BetAmount <= this.Cash)
            {
                this.MyBet.Amount = BetAmount;
                this.MyBet.Dog = DogToWin;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Collect(string Winner)
        {
            // Ask my bet to pay out, clear my bet, and update my labels
            this.Cash += this.MyBet.PayOut(Winner);
            this.ClearBet();
            this.UpdateLabels();
        }

    }
}
