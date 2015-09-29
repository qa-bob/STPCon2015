// ========================================================================
//  paredfruit.cs
//
//  One solution to the optimization challenge
//  this rolls all loops into one loop
//
// ========================================================================

function main()
// ------------------------------------------------------------------------
//     Entry point for program. This program adds up the costs
//     and quantities of selected fruit types and outputs the results to
//     the display. This program is a variation of the program FruitLoopy
//
// ------------------------------------------------------------------------
{
 //
 // ----------------- Initialization ---------------------
 //

 %numFruitTypes = 5; // so we know how many types are in our arrays

 %bananaIdx=0;    // initilize the values of our index variables
 %appleIdx=1;
 %orangeIdx=2;
 %mangoIdx=3;
 %pearIdx=4;

 %names[%bananaIdx] = "bananas"; // initilize the fruit name values
 %names[%appleIdx] = "apples";
 %names[%orangeIdx] = "oranges";
 %names[%mangoIdx] = "mangos";
 %names[%pearIdx] = "pears";

 %cost[%bananaIdx] = 1.15; // initilize the price values
 %cost[%appleIdx] = 0.55;
 %cost[%orangeIdx] = 0.55;
 %cost[%mangoIdx] = 1.90;
 %cost[%pearIdx] = 0.68;

 %quantity[%bananaIdx] = 1; // initilize the quantity values
 %quantity[%appleIdx]  = 3;
 %quantity[%orangeIdx] = 4;
 %quantity[%mangoIdx]  = 1;
 %quantity[%pearIdx]   = 2;

 %numFruit=0;     // always a good idea to initialize *all* variables!
 %totalCost=0;    // (even if we know we are going to change them later)

 //
 // ----------------- Computation ---------------------
 //

 // Display the known statistics of the fruit collection
 // count up all the pieces of fruit and calculate the total cost
 for (%index = 0; %index < %numFruitTypes; %index++)
 {
   print("Cost of " @ %names[%index] @ ":$" @ %cost[%index]);
   print("Number of " @ %names[%index] @ ":" @ %quantity[%index]);
   %numFruit = %numFruit + %quantity[%index];
   %totalCost = %totalCost + (%quantity[%index]*%cost[%index]);
 }
 // now print the totals
 print("Total pieces of Fruit:" @ %numFruit);
 print("Total Price of Fruit:$" @ %totalCost);
}
