# **TeacherPhilTools v1.0**

*14/12/2023*

**Program.cs**
A bunch of tests to make sure everything was working as intended.
Also functions as an example of how to use some of these classes.

## **Random classes**

**RNGHelper**
A collection of implementations of the built-in Random class. Can simulate coin tosses, a percent chance and various dice rolls.

You can use some convenient functions like RollD6() or you can simulate a roll of any type, ie: RollDie(7) will be a 7-sided die roll.

**DiceNotation**
Input should be in the form of:
x
xdx
xdxox
xdxbx
xdxbxox
Where x = a number and o = +/-
d stands for dice, b stands for 'best of'

So for example, 3d5 means: 3x 5-sided dice
Another example, 2d6b1+3 means: 2x 6-sided dice, choose the highest roll and then + 3

## **Misc classes**

**Validation**
A collection of simple validation checks. Grows whenever I do a new validation and remember to put it in.

**XMLUtil**
Some examples of grabbing data from xml. Commented out for convenient building without the source files.

**Files**
Some examples of loading/saving files.