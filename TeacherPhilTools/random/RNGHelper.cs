using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherPhilTools.random
{
    public class RNGHelper
    {
        private Random rngGen;
        
        // Constructor
        public RNGHelper()
        {
            // init random seed
            rngGen = new Random();
        }

		/*
			Function: SuccessPercent(int intPercentageChance)
			Argument(s): intPercentageChance is the % chance for success, ie: 70 means 70%
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 13/07/2022
			Purpose: Determines if something with x% succeeds.
			*/
		public bool SuccessPercent(int intPercentageChance)
		{
			int intResult = RollDie(1, 100);

			if (intResult <= intPercentageChance)
			{
				// success
				return true;
			}
			else
			{
				// fail
				return false;
			}
		}

		/*
			Function: CoinToss()
			Argument(s): -
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 13/07/2022
			Purpose: Tosses a coin and decides if you won the coin toss or not
			*/
		public bool CoinToss()
		{
			int intResult = RollDie(1, 2);

			if (intResult == 1)
			{
				// won coin toss
				return true;
			}
			else
			{
				// lost coin toss
				return false;
			}
		}

		/*
			Function: RollDie()
			Argument(s): intMin is the minimum number on die, intMax is maximum number on die
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 25/04/2022
			Purpose: Customisable dice roll, ie: d6 use intMin as 1 and intMax as 6
			*/
		public int RollDie(int intMin, int intMax)
		{
			intMax++; // needs to be one more because of weird way random.Next works
			return rngGen.Next(intMin, intMax);
		}

        /*
			Function: RollNormalDie()
			Argument(s): intMax is maximum number on die
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 13/02/2023
			Purpose: Customisable dice roll, ie: d6 use intMax as 6
			*/
        public int RollNormalDie(int intMax)
        {
            intMax++; // needs to be one more because of weird way random.Next works
            return rngGen.Next(1, intMax);
        }

        /*
			Function: RollD3()
			Argument(s): -
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 31/05/2021
			Purpose: Shortcut to roll a D3
			*/
        public int RollD3()
		{
			return rngGen.Next(1, 4);
		}

		/*
			Function: RollD4()
			Argument(s): -
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 31/05/2021
			Purpose: Shortcut to roll a D4
			*/
		public int RollD4()
		{
			return rngGen.Next(1, 5);
		}

		/*
			Function: RollD6()
			Argument(s): -
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 31/05/2021
			Purpose: Shortcut to roll a D6
			*/
		public int RollD6()
		{
			return rngGen.Next(1, 7);
		}

        /*
			Function: RollD8()
			Argument(s): -
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 14/12/2023
			Purpose: Shortcut to roll a D8
			*/
        public int RollD8()
        {
            return rngGen.Next(1, 9);
        }

        /*
			Function: RollD10()
			Argument(s): -
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 10/07/2022
			Purpose: Shortcut to roll a D10
			*/
        public int RollD10()
		{
			return rngGen.Next(1, 11);
		}

		/*
			Function: RollD12()
			Argument(s): -
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 31/05/2021
			Purpose: Shortcut to roll a D12
			*/
		public int RollD12()
		{
			return rngGen.Next(1, 13);
		}

		/*
			Function: RollD20()
			Argument(s): -
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 31/05/2021
			Purpose: Shortcut to roll a D20
			*/
		public int RollD20()
		{
			return rngGen.Next(1, 21);
		}

        /*
			Function: GetDiceRolls()
			Argument(s): - intNumDiceRolls - how many times to roll the die
						 - intSideDice - how many sides the die has
						 - don't use negative numbers
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 14/12/2023
			Purpose: Returns an array of the die rolls
			*/

        public int[] GetDiceRolls(int intNumDiceRolls, int intSideDice)
		{
			int[] arrDiceRolls = new int[intNumDiceRolls];

			for(int i = 0; i < intNumDiceRolls; i++)
			{
				arrDiceRolls[i] = RollNormalDie(intSideDice);
			}

			return arrDiceRolls;
		}
    }
}
