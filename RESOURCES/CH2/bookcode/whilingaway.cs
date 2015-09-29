// ========================================================================
//  WhilingAway.cs
//
//  This module is a program that demonstrates while loops. It prints
//  random values on the screen as long as a condition is satisfied.
//
// ========================================================================

function main()
// ----------------------------------------------------
//     Entry point for the program.
// ----------------------------------------------------
{
   %value = 0;            // initialize %value
   while (%value < 7)     // stop looping if %n exceeds 7
   {
      %value = GetRandom(10); // get a random number between 0 and 10
      print("value="@%value);     // print the result
   }                      // back to the top of the loop
                          // ie. do it all again
}
