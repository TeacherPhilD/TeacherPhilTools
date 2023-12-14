using TeacherPhilTools.random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace TeacherPhilTools
{
    // Purpose of this is to test and demonstrate use of some of the helper tools
    internal class Program
    {
        bool booDebug = false; // set to true for more verbose messages
        Validation valCheck = new Validation();
        RNGHelper rng = new RNGHelper();
        DiceNotation diceNotationParser;

        static void Main(string[] args)
        {
            // anti-static trick
            Program pro = new Program();
            pro.StartTests();
        }

        private void StartTests()
        {
            ValidationTests();
            //InteractiveValidationTests();
            RNGHelperTests();

            // Start the parser
            diceNotationParser = new DiceNotation(booDebug);
            DiceNotationTests();
        }

        ///////////////////
        /// Test Batteries
        ///////////////////

        private void ValidationTests()
        {
            NewHeading("Validation Tests");

            // strings to test with
            string strTestBob = "Bob";
            string strTestNum = "42";
            string strTestNum2 = "42.42";

            Console.WriteLine($"Testing {strTestBob}\nisStringEmpty: {valCheck.isStringEmpty(strTestBob)}\n");
            Console.WriteLine($"Testing {""} [a blank string]\nisStringEmpty: {valCheck.isStringEmpty(strTestBob)}\n");
            LineBreak();

            Console.WriteLine($"Testing {strTestBob}\nisStringNumericInteger: {valCheck.isStringNumericInteger(strTestBob)}\n");
            Console.WriteLine($"Testing {strTestNum}\nisStringNumericInteger: {valCheck.isStringNumericInteger(strTestNum)}\n");
            Console.WriteLine($"Testing {strTestNum}\nisStringNumericDouble: {valCheck.isStringNumericDouble(strTestNum)}\n");
            LineBreak();

            Console.WriteLine($"Testing {strTestBob}\nisStringNumericInteger: {valCheck.isStringNumericInteger(strTestBob)}\n");
            Console.WriteLine($"Testing {strTestNum2}\nisStringNumericInteger: {valCheck.isStringNumericInteger(strTestNum2)}\n");
            Console.WriteLine($"Testing {strTestNum2}\nisStringNumericDouble: {valCheck.isStringNumericDouble(strTestNum2)}\n");
            LineBreak();

            // integers to test with
            int intTooLow = 0;
            int intTooHigh = 101;
            int intMin = 1;
            int intMax = 100;

            Console.WriteLine($"Testing {intTooLow}\nisIntNumberInRange [min=1 max=100]: {valCheck.isIntNumberInRange(intTooLow, intMin, intMax)}\n");
            Console.WriteLine($"Testing {intTooHigh}\nisIntNumberInRange [min=1 max=100]: {valCheck.isIntNumberInRange(intTooHigh, intMin, intMax)}\n");
            Console.WriteLine($"Testing {intMin}\nisIntNumberInRange [min=1 max=100]: {valCheck.isIntNumberInRange(intMin, intMin, intMax)}\n");
            Console.WriteLine($"Testing {intMax}\nisIntNumberInRange [min=1 max=100]: {valCheck.isIntNumberInRange(intMax, intMin, intMax)}\n");
            LineBreak();

            // an additional string to test comparisons with
            string strTestBob2 = "Bob";

            Console.WriteLine($"Testing {strTestBob} & {strTestBob2}\nisStringAndStringEqual: {valCheck.isStringAndStringEqual(strTestBob, strTestBob2)}\n");
            Console.WriteLine($"Testing {strTestBob} & {"notBob"}\nisStringAndStringEqual: {valCheck.isStringAndStringEqual(strTestBob, "notBob")}\n");
            LineBreak();

            Console.WriteLine($"Testing {strTestBob} & {strTestBob2} & {"Bob"}\nisStringX3Equal: {valCheck.isStringX3Equal(strTestBob, strTestBob2, "Bob")}\n");
            Console.WriteLine($"Testing {strTestBob} & {strTestBob2} & {"notBob"}\nisStringX3Equal: {valCheck.isStringX3Equal(strTestBob, strTestBob2, "notBob")}\n");
            LineBreak();

            // rounding tests
            double dblTest = 42.49;
            int intDecimalPlaces = 1;

            Console.WriteLine($"Testing {dblTest}\nroundNum: {valCheck.roundNum(dblTest)}\n");
            Console.WriteLine($"Testing {dblTest}\nroundNum [to {intDecimalPlaces} decimal places: {valCheck.roundNum(dblTest, intDecimalPlaces)}\n");
            Console.WriteLine($"Testing {dblTest}\nRoundDoubleToInt: {valCheck.RoundDoubleToInt(dblTest)}\n");
            LineBreak();

            // weirdly specific tests
            string strLightningBolt = "Lightning Bolt (20)";
            string strNoBracketsLightningBolt = "Lightning Bolt 20";
            string strBadLightningBolt = "Lightning Bolt";

            Console.WriteLine($"Testing {strLightningBolt}\nRemoveRoundBracketsNumbersAndTrim: {valCheck.RemoveRoundBracketsNumbersAndTrim(strLightningBolt)}\n");
            Console.WriteLine($"Testing {strNoBracketsLightningBolt}\nRemoveRoundBracketsNumbersAndTrim: {valCheck.RemoveRoundBracketsNumbersAndTrim(strNoBracketsLightningBolt)}\n");
            Console.WriteLine($"Testing {strBadLightningBolt}\nRemoveRoundBracketsNumbersAndTrim: {valCheck.RemoveRoundBracketsNumbersAndTrim(strBadLightningBolt)}\n");
            LineBreak();

            Console.WriteLine($"Testing {strLightningBolt}\nIsNumAtEndofString: {valCheck.IsNumAtEndofString(strLightningBolt)}\n");
            Console.WriteLine($"Testing {strNoBracketsLightningBolt}\nIsNumAtEndofString: {valCheck.IsNumAtEndofString(strNoBracketsLightningBolt)}\n");
            Console.WriteLine($"Testing {strBadLightningBolt}\nIsNumAtEndofString: {valCheck.IsNumAtEndofString(strBadLightningBolt)}\n");
            LineBreak();
        }

        private void InteractiveValidationTests()
        {
            NewHeading("Interactive Validation Tests");

            string strName = valCheck.ConsoleGetStringFromUser("What is your name");
            Console.WriteLine($"Name is: {strName}");

            int intNum = valCheck.ConsoleGetIntegerFromUser("Enter number (int):");
            Console.WriteLine($"Number returned is: {intNum}");

            int intNum2 = valCheck.ConsoleGetValidatedIntegerFromUser("Enter number (int):", 1, 100);
            Console.WriteLine($"Number returned is: {intNum2}");

            double dblNum = valCheck.ConsoleGetDoubleFromUser("Enter number (double):");
            Console.WriteLine($"Number returned is: {dblNum}");

            double dblNum2 = valCheck.ConsoleGetValidatedDoubleFromUser("Enter number (double):", 1.1, 12.1);
            Console.WriteLine($"Number returned is: {dblNum2}");
        }

        private void RNGHelperTests()
        {
            NewHeading("RNG Helper Tests");

            // test out SuccessPercent
            string strSuccessPercent = "\nSuccessPercent(70)\n";
            int intCountSuccessPercent = 0;
            for (int i = 1; i < 101; i++)
            {
                bool booResult = rng.SuccessPercent(70);
                if (booResult == true)
                {
                    intCountSuccessPercent++;
                }

                if (i % 10 == 0)
                {
                    strSuccessPercent += $"{booResult}\n";
                }
                else
                {
                    strSuccessPercent += $"{booResult}, ";
                }
            }

            Console.WriteLine(strSuccessPercent + "\nSuccesses: " + intCountSuccessPercent + "\n");
            LineBreak();


            // test out Coin Toss
            string strCoinToss = "\nCoin Toss()\n";
            int intCoinTossCount = 0;
            for (int i = 1; i < 101; i++)
            {
                bool booResult = rng.CoinToss();
                if (booResult == true)
                {
                    intCoinTossCount++;
                }

                if (i % 10 == 0)
                {
                    strCoinToss += $"{booResult}\n";
                }
                else
                {
                    strCoinToss += $"{booResult}, ";
                }
            }

            Console.WriteLine(strCoinToss + "\nHeads: " + intCoinTossCount + "\n");
            LineBreak();

            // test dice rolls and give average
            int intTestDiceRolls = 101;
            TestDiceRoll(3, intTestDiceRolls);
            TestDiceRoll(6, intTestDiceRolls);
            TestDiceRoll(10, intTestDiceRolls);
            TestDiceRoll(20, intTestDiceRolls);

            // test GetDiceRolls
            int intNumDiceRolls = 100;
            int intSideDice = 6;
            int intTotalRoll = 0;
            string strDiceRolls = $"\nRolling {intNumDiceRolls}d{intSideDice}\n";
            int[] arrRolls = rng.GetDiceRolls(intNumDiceRolls, intSideDice);
            for (int i = 0; i < arrRolls.Length; i++)
            {
                intTotalRoll += arrRolls[i];
                if ((i + 1) % 10 == 0)
                {
                    strDiceRolls += $"{arrRolls[i]}\n";
                }
                else
                {
                    strDiceRolls += $"{arrRolls[i]}, ";
                }
            }
            double dblAverage = Convert.ToDouble(intTotalRoll) / Convert.ToDouble(intTestDiceRolls);
            Console.WriteLine($"{strDiceRolls}\nTotal: {intTotalRoll}\nAverage: {dblAverage}");
            LineBreak();
        }

        // test dice rolls and give average
        private void TestDiceRoll(int intDieSides, int intDiceRolls)
        {
            // test dX where X is intDieSides
            string strDX = $"\nRollD{intDieSides}()\n";
            int intTotalResults = 0;
            for (int i = 1; i < intDiceRolls; i++)
            {
                int intResult = rng.RollDie(1, intDieSides);
                intTotalResults += intResult;

                if (i % 10 == 0)
                {
                    strDX += $"{intResult}\n";
                }
                else
                {
                    strDX += $"{intResult}, ";
                }
            }

            double dblAverage = intTotalResults / intDiceRolls;
            Console.WriteLine(strDX);
            Console.WriteLine($"Total: {intTotalResults} Average: {dblAverage}\n");
            LineBreak();
        }

        private void DiceNotationTests()
        {
            NewHeading("Dice Notation Tests");

            string strInput = "0400d4b2+3";
            // Instructions
            Console.WriteLine("Input should be in the form of:\n\n#\n#d#\n#d#o#\n#d#b#\n#d#b#o#\n\nWhere # = a number and o = +/-");
            Console.WriteLine("d stands for dice, b stands for 'best of'\n");
            Console.WriteLine("So for example, 3d5 means: 3x 5-sided dice\n");
            Console.WriteLine("Another example, 2d6b1+3 means: 2x 6-sided dice, choose the highest roll and then + 3\n");
            Console.WriteLine("--- --- --- ---\n");
            Console.WriteLine($"Input string: {strInput}\n");
            Console.WriteLine("--- --- --- ---\n");

            TestDiceString("0400d4b2+3");
            TestDiceString("6d6");
            TestDiceString("66");
            TestDiceString("6ad6");
            TestDiceString("8d8b2+2");
            TestDiceString("2d4b3+5a");
            TestDiceString("2.2d4b3+5");
            TestDiceString("2dd4b3+5");
            TestDiceString("2D4b3+5");
            TestDiceString("-99");
            TestDiceString("-2d4b3+5");
            TestDiceString("2b3+5");
            TestDiceString("6d6-6");
            TestDiceString("6d6+6");
            TestDiceString("6d6b2+6");
            TestDiceString("6d6b2-6");
            TestDiceString("6d6b24-6");
        }

        private void TestDiceString(string strInput)
        {
            Console.WriteLine($"Input string: {strInput}\n");
            DiceWord diceWord = diceNotationParser.ParseDiceString(strInput);
            DiceNotationResult(diceWord);
            Console.WriteLine("Result: " + diceNotationParser.RollDiceWord(diceWord));
            FancyLineBreak();
        }

        private void DiceNotationResult(DiceWord diceWord)
        {
            if (diceWord.IsValid() == true)
            {
                Console.WriteLine("Operation Successful");
                DebugMsg(diceWord.GetDescription());
            }
            else
            {
                Console.WriteLine("Operation Unsuccessful");
            }
        }

        ///////////////////
        /// Helper Functions
        ///////////////////
        private void DebugMsg(string strDebug)
        {
            if (booDebug == true)
            {
                Console.WriteLine(strDebug);
            }
        }

        private void FancyLineBreak()
        {
            Console.WriteLine("\n=== === === === === === ===\n");
        }

        private void LineBreak()
        {
            Console.WriteLine("--- --- ---");
        }

        private void NewHeading(string strHeading)
        {
            Console.WriteLine("\n=== === === === === === ===");
            Console.WriteLine("=== === === === === === ===\n");
            Console.WriteLine(strHeading);
            Console.WriteLine("\n=== === === === === === ===");
            Console.WriteLine("=== === === === === === ===\n");
        }
    }
}
