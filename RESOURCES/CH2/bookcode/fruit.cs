// ========================================================================
//  Fruit.cs
//
//  This module is a program that prints a simple greeting on the screen.
//  This program adds up the costs and quantities of selected fruit types
//  and outputs the results to the display
// ========================================================================

function main()
// ----------------------------------------------------
//     Entry point for the program.
// ----------------------------------------------------
{
 $bananaCost=1.15;// initilize the value of our variables
 $appleCost=0.55; //   (we don't need to repeat the above
 $numApples=3;    //   comment for each initialization, just
 $numBananas=1;   //   group the init statements together.)

 $numFruit=0;     // always a good idea to initialize *all* variables!
 $total=0;        // (even if we know we are going to change them later)

 print("Cost of Bananas(ea.):$"@$bananaCost);
             // the value of $bananaCost gets concatenated to the end
             // of the "Cost of Bananas:" string. Then the
             // full string gets printed. same goes for the next 3 lines
 print("Cost of Apples(ea.):$"@$appleCost);
 print("Number of Bananas:"@$numBananas);
 print("Number of Apples:"@$numApples);

 $numFruit=$numBananas+$numApples; // add up the total number of fruits
 $total = ($numBananas * $bananaCost) +
               ($numApples * $appleCost);  // calculate the total cost
             //(notice that statements can extend beyond a single line)

 print("Total amount of Fruit:"@$numFruit); // output the results
 print("Total Price of Fruit:$"@$total@"0");// add a zero to the end
                              // to make it look better on the screen
}