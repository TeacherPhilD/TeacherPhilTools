using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherPhilTools.random
{
    public class DiceNotation
    {
        // Class variables
        RNGHelper rng = new RNGHelper();

        int intNumStart = -1;
        bool booNumSequence = false;
        bool booDieNumDone = false;
        bool booBestOfDone = false;
        bool booOperationDone = false;

        bool booDebug;

        public DiceNotation(bool booDebugA)
        {
            booDebug = booDebugA;
        }

        public int RollDiceString(string strDiceString)
        {
            DiceWord rollDice = ParseDiceString(strDiceString);

            // check for plain number
            if(rollDice.IsPlainNumber() == true)
            {
                // it's just a plain number!
                return rollDice.GetPlainNumber();
            }

            // check for being valid in the first place
            if(rollDice.IsValid() == false)
            {
                return -1; // error value
            }

            // resolve the dice roll with all parameters

            // Basic Dice Roll
            int intDiceResult = 0;
            List<int> lstDiceRolls = new List<int>();

            for(int i = 0; i < rollDice.GetNumDice(); i++)
            {
                int intDiceRoll = rng.RollDie(1, rollDice.GetSideDice());
                lstDiceRolls.Add(intDiceRoll);
                intDiceResult += intDiceRoll;
            }

            DebugMsg($"Rolling Stage 1: {intDiceResult}");

            if(rollDice.GetBestOfDice() > 0)
            {
                // we need to count the best dice only
                DebugMsg($"Only counting the best {rollDice.GetBestOfDice()} dice rolls");
                intDiceResult = 0;
                DebugMsg($"Dice Result now {intDiceResult}");
                
                lstDiceRolls.Sort();
                lstDiceRolls.Reverse();
                int[] arrDiceRolls = lstDiceRolls.ToArray();

                DebugMsg($"Sorted dice list");
                DebugMsg(string.Join(",", lstDiceRolls));

                for (int i = 0; i < rollDice.GetBestOfDice(); i++)
                {
                    DebugMsg($"Currently {intDiceResult} Adding {arrDiceRolls[i]}");
                    intDiceResult += arrDiceRolls[i];
                    DebugMsg($"Now {intDiceResult} at stage {i}");
                }

                DebugMsg($"Best of Result: {intDiceResult}");
            }

            if(rollDice.GetEndAddition() > 0)
            {
                // add to our result
                intDiceResult += rollDice.GetEndAddition();
            }
            else if(rollDice.GetEndSubtract() > 0)
            {
                // subtract from our result
                intDiceResult -= rollDice.GetEndSubtract();
            }

            DebugMsg($"Rolling Stage 2: {intDiceResult}");

            return intDiceResult;
        }

        // Convenience function, can roll a DiceWord
        public int RollDiceWord(DiceWord diceWord)
        {
            return RollDiceString(diceWord.GetDiceString());
        }

        // convert a DiceString, ie: "6d6+4" into a DiceWord
        public DiceWord ParseDiceString(string strDiceString)
        {
            // before we go through all this...
            // check if it's just a plain number
            // if so then we generate and return the diceword
            int intNumOnly = -999;
            if (int.TryParse(strDiceString, out intNumOnly))
            {
                // if we get in here that means its just a plain number!

                return new DiceWord(0, 0, 0, intNumOnly, 0, strDiceString, true, true);
            }

            // Function variables
            int size = strDiceString.Length;
            bool booInputValid = true;
            bool booBValid = true;
            bool booDValid = true;
            bool booOp1Valid = true;
            bool booOp2Valid = true;
            bool booSyntaxError = false;
            char charOperation = 'E'; // E for ERROR

            // numbers
            int intNumEnd = -999;
            int intSideDice = -999;
            int intNumDice = -999;
            int intBestDice = -999;

            // Loop to go through the input string
            // can access any single character through strInput[i]
            for (int i = 0; i < size; i++)
            {
                // Only continue if we haven't found an error before
                //if (booInputValid == true)
                //{
                //Switch case that goes to functions to keep things neat/sane
                switch (strDiceString[i])
                {
                    // Number cases
                    case '0':
                        CaseNumber(i);
                        break;
                    case '1':
                        CaseNumber(i);
                        break;
                    case '2':
                        CaseNumber(i);
                        break;
                    case '3':
                        CaseNumber(i);
                        break;
                    case '4':
                        CaseNumber(i);
                        break;
                    case '5':
                        CaseNumber(i);
                        break;
                    case '6':
                        CaseNumber(i);
                        break;
                    case '7':
                        CaseNumber(i);
                        break;
                    case '8':
                        CaseNumber(i);
                        break;
                    case '9':
                        CaseNumber(i);
                        break;
                    // Non-Number cases
                    case 'b':
                        booBValid = CaseNotNumber(i, 'b', strDiceString, ref intSideDice);
                        booBestOfDone = true;
                        break;
                    case 'd':
                        booDValid = CaseNotNumber(i, 'd', strDiceString, ref intNumDice);
                        booDieNumDone = true;
                        break;
                    case '+':
                        charOperation = '+';
                        if (booDieNumDone == true && booBestOfDone == true)
                        {
                            booOp1Valid = CaseNotNumber(i, '+', strDiceString, ref intBestDice);
                        }
                        else
                        {
                            booOp1Valid = CaseNotNumber(i, '+', strDiceString, ref intSideDice);
                        }
                        booOperationDone = true;
                        break;
                    case '-':
                        charOperation = '-';
                        if (booDieNumDone == true && booBestOfDone == true)
                        {
                            booOp2Valid = CaseNotNumber(i, '-', strDiceString, ref intBestDice);
                        }
                        else
                        {
                            booOp2Valid = CaseNotNumber(i, '-', strDiceString, ref intSideDice);
                        }
                        booOperationDone = true;
                        break;
                    // Error case
                    default:
                        DebugMsg($"Syntax error on character {i}, aborting");
                        booSyntaxError = true;
                        break;
                }

                // if we hit an error return false
                if (booSyntaxError == true)
                {
                    break;
                }
            }

            // check for a number at end
            bool booNumCheck = false;
            if (booDieNumDone && booBestOfDone == false && booOperationDone == false)
            {
                booNumCheck = CheckForNumber(size, strDiceString, ref intSideDice);
            }
            else if (booDieNumDone && booBestOfDone && booOperationDone == false)
            {
                booNumCheck = CheckForNumber(size, strDiceString, ref intBestDice);
            }
            else
            {
                booNumCheck = CheckForNumber(size, strDiceString, ref intNumEnd);
            }

            // check for best of more than num dice
            // this is a fail condition! Can't roll best 4 dice if there are only 3 for example
            bool booBestSanity = true;
            if(intBestDice > intNumDice)
            {
                booBestSanity = false;
            }


            // Validation results
            if (booInputValid == true && booBValid == true && booDValid == true && booOp1Valid == true && booOp2Valid == true && booSyntaxError == false && booNumCheck == true && booBestSanity == true)
            {
                DebugMsg("Successfully parsed dice input");

                // figure out if positive or negative!
                if (booOperationDone == true && charOperation == '+')
                {
                    ResetInitVariables();
                    return new DiceWord(intNumDice, intBestDice, intSideDice, intNumEnd, 0, strDiceString, true, false);
                }
                else if (booOperationDone == true && charOperation == '-')
                {
                    ResetInitVariables();
                    return new DiceWord(intNumDice, intBestDice, intSideDice, 0, intNumEnd, strDiceString, true, false);
                }
                else
                {
                    ResetInitVariables();
                    return new DiceWord(intNumDice, intBestDice, intSideDice, 0, 0, strDiceString, true, false);
                }

            }
            else
            {
                DebugMsg("Error in parsing dice input");
                ResetInitVariables();
                return new DiceWord(1, 0, 1, 0, 0, strDiceString, false, false);
            }
        }

        // function to reset class variables ready for parser to be used again
        private void ResetInitVariables()
        {
            intNumStart = -1;
            booNumSequence = false;
            booDieNumDone = false;
            booBestOfDone = false;
            booOperationDone = false;
        }

        // Called when the character is a number (0-9)
        private void CaseNumber(int intIterator)
        {
            if (booNumSequence == false)
            {
                intNumStart = intIterator;
                booNumSequence = true;
            }
        }

        // Called when the character is not a number (d, b, + or -)
        private bool CaseNotNumber(int intIterator, char charInput, string strDiceString, ref int intRetVal)
        {
            bool booParse = CheckForNumber(intIterator, strDiceString, ref intRetVal);
            DebugMsg($"{charInput} case detected at position {intIterator}");

            // laundry list of checks
            if ((charInput == '+' || charInput == '-') && booDieNumDone == false)
            {
                DebugMsg("Error Parsing: +/- out of order");
                booParse = false;
            }

            if (charInput == 'b' && booDieNumDone == false)
            {
                DebugMsg("Error Parsing: tried to do best of without having determined number of die rolls");
                booParse = false;
            }

            if (charInput == 'd' && booDieNumDone)
            {
                DebugMsg("Error Parsing: d case already done");
                booParse = false;
            }

            if (charInput == 'b' && booBestOfDone)
            {
                DebugMsg("Error Parsing: b case already done");
                booParse = false;
            }

            if (charInput == '-' && booOperationDone)
            {
                DebugMsg("Error Parsing: Operation (+/-) case already done");
                booParse = false;
            }

            if (charInput == '+' && booOperationDone)
            {
                DebugMsg("Error Parsing: Operation (+/-) case already done");
                booParse = false;
            }

            return booParse;
        }

        // Attempt to figure out a number and for how long it goes
        private bool CheckForNumber(int intIterator, string strDiceString, ref int intRetVal)
        {
            bool booParse = true;
            if (booNumSequence == true)
            {
                // End the sequence and figure out the number

                // End sequence
                booNumSequence = false;

                // Figure out number
                // intNumStart is location of beginning
                // i is location of end

                int intNumberLength = intIterator - intNumStart;

                string strNum = strDiceString.Substring(intNumStart, intNumberLength); // Takes the number out as a string

                // Convert the string to a number
                booParse = int.TryParse(strNum, out intRetVal);

                if (booParse == true)
                {
                    DebugMsg($"Number is: {intRetVal}");
                }
                else
                {
                    DebugMsg($"Could not convert {strNum} to an integer!");
                }
            }

            // returns false if cannot convert to a number
            return booParse;
        }

        private void DebugMsg(string strDebug)
        {
            if (booDebug == true)
            {
                Console.WriteLine(strDebug);
            }
        }
    }

    // class for containing all information gleaned from a dice string
    public class DiceWord
    {
        // class that contains the information gleaned from a dice notation string
        private int intNumDice;
        private int intBestOfDice;
        private int intSideDice;
        private int intEndAddition;
        private int intEndSubtract;
        private bool booValid;
        private string strDiceWord;
        private bool booPlainNumber;

        public DiceWord(int intNumDice, int intBestOfDice, int intSideDice, int intEndAddition, int intEndSubtract, string strDiceWord, bool booValid, bool booPlainNumber)
        {
            this.intNumDice = intNumDice;
            this.intBestOfDice = intBestOfDice;
            this.intSideDice = intSideDice;
            this.intEndAddition = intEndAddition;
            this.intEndSubtract = intEndSubtract;
            this.strDiceWord = strDiceWord;
            this.booValid = booValid;
            this.booPlainNumber = booPlainNumber; // plain number uses intEndAddition (see GetPlainNumber())
        }

        // Get a description of all the diceword
        // returns a nice looking summary string suitable for displaying to a user
        public string GetDescription()
        {

            if (booPlainNumber)
            {
                return ($"Plain number [no dice rolls] : {strDiceWord}");
            }
            else
            {
                string strDesc = "";
                strDesc += $"DiceWord: {strDiceWord}\n";
                strDesc += $"Rolling {intNumDice}x {intSideDice}-sided dice\n";

                if (intBestOfDice > 0)
                {
                    strDesc += $"Best of {intBestOfDice} dice\n";
                }

                if (intEndAddition > 0)
                {
                    strDesc += $"Add {intEndAddition}";
                }

                if (intEndSubtract > 0)
                {
                    strDesc += $"Subtract {intEndSubtract}";
                }

                return strDesc;
            }
        }

        ////
        // getters
        ////

        public int GetPlainNumber()
        {
            return intEndAddition;
        }

        public int GetNumDice()
        {
            return intNumDice;
        }

        public int GetBestOfDice()
        {
            return intBestOfDice;
        }

        public int GetSideDice()
        {
            return intSideDice;
        }

        public int GetEndAddition()
        {
            return intEndAddition;
        }

        public int GetEndSubtract()
        {
            return intEndSubtract;
        }

        public bool IsValid()
        {
            return booValid;
        }

        public bool IsPlainNumber()
        {
            return booPlainNumber;
        }

        public string GetDiceString()
        {
            return strDiceWord;
        }

        ////
        // setters
        ////

        public void SetToPlainNumber(int intPlainNumber)
        {
            SetNumDice(0);
            SetBestOfDice(0);
            SetSideDice(0);
            if (intPlainNumber < 0)
            {
                SetEndAddition(0);
                SetEndSubtract(intPlainNumber);
            }
            else
            {
                SetEndAddition(intPlainNumber);
                SetEndSubtract(0);
            }
            booPlainNumber = true;
            booValid = true;
            strDiceWord = intPlainNumber.ToString();
        }

        public void SetNumDice(int intNumDiceA)
        {
            intNumDice = intNumDiceA;
        }

        public void SetBestOfDice(int intBestOfDiceA)
        {
            intBestOfDice = intBestOfDiceA;
        }

        public void SetSideDice(int intSideDiceA)
        {
            intSideDice = intSideDiceA;
        }

        public void SetEndAddition(int intEndAdditionA)
        {
            intEndSubtract = 0;
            intEndAddition = intEndAdditionA;
        }

        public void SetEndSubtract(int intEndSubtractA)
        {
            intEndAddition = 0;
            intEndSubtract = intEndSubtractA;
        }
    }
}
