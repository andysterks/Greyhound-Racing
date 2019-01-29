using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racetrack_Simulator
{
    
    public class Bet
    {
        
        
        public int Amount; // The amount of cash that was bet
        public string Dog; // The string of the dog the bet is on
        public Guy Bettor; // The guy who placed the bet
        
        public string GetDescription()
        {
            // Return a string that says who place the bet, how much
            // cash was bet, and which dog he bet on("Joe bets 8 on
            // dog #4").  If the amount is zero, no bet was placed
            // ("Joe hasn't placed a bet")
            string betDescription;

            if (this.Amount != 0)
            {
                betDescription = this.Bettor.Name + " bets " + this.Amount + " on " + Dog;
            }
            else
            {
                betDescription = this.Bettor.Name + " hasn't placed a bet";
            }
            
            return betDescription;
        }
        
        public int PayOut(string Winner)
        {
            int payOut;
            // The parameter is the winner of the race.  If the dog won, 
            // return the amount bet.  Otherwise, return the negative of
            // the amount bet
            if (Winner == this.Dog)
            {
                payOut = this.Amount;
            }
            else
            {
                payOut = this.Amount * -1;
            }

            return payOut;
        }
    }
}
