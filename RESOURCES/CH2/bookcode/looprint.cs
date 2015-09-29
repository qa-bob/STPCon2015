// ========================================================================
//  looprint.cs
//
//  Solution to while challenge
// ========================================================================

function main()
// ----------------------------------------------------
//     Entry point for the program.
// ----------------------------------------------------
{
   %value = 0;            // initialize %n
   while (%value < 250)     // stop looping if %n exceeds 250
   {
      %value = GetRandom(350); // get a random number between 0 and 350
      print("n="@%value);     // print the result
   }                      // back to the top of the loop
                          // ie. do it all again
}
