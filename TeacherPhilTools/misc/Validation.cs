using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace TeacherPhilTools
{
    public class Validation
    {
        public Validation()
        {
            // empty
        }

        /////////////
        // Generic Validations
        /////////////

        /*
			Function: isStringEmpty()
			Argument(s): string to check
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 31/05/2021
			Purpose: Validation function that checks if a string is empty (no characters) or not
			*/
        public bool isStringEmpty(string strIn)
        {
            bool booValid = true;
            if (strIn.Equals("") || strIn.Equals(string.Empty))
            {
                booValid = false;
            }

            return booValid;

            // Example use:
            //if(!valCheck.isStringEmpty(strName))
            //    {
            //        lblDebug.Content = "Name cannot be empty!";
            //    }
        }

        /*
			Function: isIntegerNumeric()
			Argument(s): string to check
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 31/05/2021
			Purpose: Validation function that checks if a string can be converted to an integer
			*/
        public bool isStringNumericInteger(string strIn)
        {
            int intRetVal = -999;
            bool booValid = int.TryParse(strIn, out intRetVal);
            // If this fails to convert properly, intRetVal will = 0 and booValid will = false
            return booValid;
        }

        /*
			Function: isStringNumericDouble()
			Argument(s): string to check
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 31/05/2021
			Purpose: Validation function that checks if a string can be converted to an integer
			*/
        public bool isStringNumericDouble(string strIn)
        {
            double dblRetVal = -999;
            bool booValid = double.TryParse(strIn, out dblRetVal);
            // If this fails to convert properly, intRetVal will = 0 and booValid will = false
            return booValid;
        }

        /*
			Function: isNumberInRange()
			Argument(s): int to check, minimum and maximum
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 31/05/2021
			Purpose: Validation function that checks if an integer is within a range
			*/
        public bool isIntNumberInRange(int intIn, int intMin, int intMax)
        {
            bool booNumInRange = true;
            // With this logic, we accept the number (don't turn booNumInRange to false) if it is between intMin-intMax inclusive.
            if (intIn < intMin || intIn > intMax)
            {
                booNumInRange = false;
            }

            return booNumInRange;
        }

        /*
			Function: isStringAndStringEqual()
			Argument(s): 2x strings
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 31/05/2021
			Purpose: See if two strings are the same text
			*/
        public bool isStringAndStringEqual(string strOne, string strTwo)
        {
            bool booValid = string.Equals(strOne, strTwo);
            return booValid;
        }

        /*
			Function: isStringX3Equal()
			Argument(s): 3x strings
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 02/06/2021
			Purpose: See if three strings are the same text
			*/
        public bool isStringX3Equal(string strOne, string strTwo, string strThree)
        {
            bool booValid1 = string.Equals(strOne, strTwo);
            bool booValid2 = string.Equals(strOne, strThree);
            bool booValid3 = string.Equals(strTwo, strThree);

            if (booValid1 == true && booValid2 == true && booValid3 == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
			Function: roundNum()
			Argument(s): double to round
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 31/05/2021
			Purpose: Round to the nearest whole number
			*/
        public double roundNum(double dblNum)
        {
            // how to round to the nearest whole number
            double dblOut = Math.Round(dblNum);

            return dblOut;
        }

        /*
			Function: roundNum()
			Argument(s): double to round and how many decimal places to round to
			Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 31/05/2021
			Purpose: Round to x decimal points
			*/
        public double roundNum(double dblNum, int intDecimalPlace)
        {
            // How to round to x decimal places (in this case 3)
            double dblOut = Math.Round(dblNum, intDecimalPlace);

            return dblOut;
        }

        /*
			Function: RoundDoubleToInt()
			Argument(s): double to turn to an int with rounding
			Taken from: https://stackoverflow.com/questions/633335/how-might-i-convert-a-double-to-the-nearest-integer-value
			Last Edited: 13/07/2022
			Purpose: simple round to integer
			*/
        public int RoundDoubleToInt(double dblIn)
        {
            if (dblIn < 0)
            {
                return (int)(dblIn - 0.5);
            }
            return (int)(dblIn + 0.5);
        }

        /*
			Function: RemoveRoundBracketsNumbersAndTrim()
			Argument(s): string to trim
            Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 07/08/2023
			Purpose: Removes numbers and brackets
            Example: In: "Lightning Bolt (20)" Out: "Lightning Bolt"
			*/
        public string RemoveRoundBracketsNumbersAndTrim(string strIn)
        {
            //https://www.c-sharpcorner.com/blogs/replace-special-characters-from-string-using-regex1
            //https://www.tutlane.com/tutorial/csharp/csharp-string-trim-method-trimstart-trimend

            // example strIn = "Lightning Bolt (20)
            strIn = Regex.Replace(strIn, @"[()0-9]", ""); // remove (20)
            strIn = strIn.Trim(); // removes the " " at the end. (space at the end)
            return strIn;
        }

        /*
			Function: IsWordMatchSpaceNum()
			Argument(s): string to check, string of word to check for
            Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 28/1/2023
			Purpose: Determines if word + number
            Example: In: "Lightning Bolt 20" Out: true
            Example: In: "Lightning Bolt" Out: false
			*/

        public bool IsWordMatchSpaceNum(string strInput, string strWordToMatch)
        {
            return Regex.IsMatch(strInput, ".*" + strWordToMatch + "[0-9]+$");
        }

        /*
			Function: IsNumAtEndofString()
			Argument(s): string to check
            Author: Phillip Donald
			Contact: donaldp@milsen.vic.edu.au
			Last Edited: 1/12/2023
			Purpose: Whether the inputted string has a number at the end or not
            Example: In: "Lightning Bolt 20" Out: true
            Example: In: "Lightning Bolt" Out: false
			*/
        public bool IsNumAtEndofString(string strInput)
        {
            return char.IsDigit(strInput.Last());
        }

        /////////////
        // Console convenience functions
        /////////////

        // get a string
        public string ConsoleGetStringFromUser(string strQuestion)
        {
            bool booValid = false;
            string strUserInput = String.Empty;
            while(booValid == false)
            {
                Console.Write($"{strQuestion} ");
                strUserInput = Console.ReadLine();

                if(!strUserInput.Equals(String.Empty) && !strUserInput.Equals(""))
                {
                    booValid = true;
                }
            }
            
            return strUserInput;
        }

        // get an int
        public int ConsoleGetIntegerFromUser(string strQuestion)
        {
            Console.Write(strQuestion + " ");
            int intNum = -999; // error value
            while (!int.TryParse(Console.ReadLine(), out intNum))
            {
                Console.Write("The value must be an integer, try again: ");
            }

            return intNum;
        }

        // get a double
        public double ConsoleGetDoubleFromUser(string strQuestion)
        {
            Console.Write(strQuestion + " ");
            double dblNum = -999; // error value
            while (!double.TryParse(Console.ReadLine(), out dblNum))
            {
                Console.Write("The value must be a double, try again: ");
            }

            return dblNum;
        }

        // get a validated int
        public int ConsoleGetValidatedIntegerFromUser(string strQuestion, int intMin, int intMax)
        {
            bool booNumCheck = true;
            int intNum = -999; // error value
            while (booNumCheck == true)
            {
                intNum = ConsoleGetIntegerFromUser(strQuestion);

                if (intNum >= intMin && intNum <= intMax)
                {
                    // number is between intMin and intMax inclusive
                    booNumCheck = false;
                }
                else
                {
                    // number is invalid
                    Console.WriteLine("Invalid input, must be between " + intMin + " and " + intMax);
                }
            }

            return intNum;
        }

        // get a validated double
        public double ConsoleGetValidatedDoubleFromUser(string strQuestion, double dblMin, double dblMax)
        {
            bool booNumCheck = true;
            double dblNum = -999; // error value
            while (booNumCheck == true)
            {
                dblNum = ConsoleGetDoubleFromUser(strQuestion);

                if (dblNum >= dblMin && dblNum <= dblMax)
                {
                    // number is between intMin and intMax inclusive
                    booNumCheck = false;
                }
                else
                {
                    // number is invalid
                    Console.WriteLine("Invalid input, must be between " + dblMin + " and " + dblMax);
                }
            }

            return dblNum;
        }
    }
}
