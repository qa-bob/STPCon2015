// ========================================================================
//  WormyFruit.cs
//
//  Buggy version of TwotyFruity. It has five known bugs in it.
//  This program adds up the costs and quantities of selected fruit types
//  and outputs the results to the display. This module is a variation
//  of the the FruitLoopy.cs module designed to demonstrate how to use
//  functions.
// ========================================================================

function InitializeFruit(%numFruitTypes)
// ------------------------------------------------------------------------
//     Set the starting values for our fruit arrays, and the type
//     indices
//
//     RETURNS: number of different types of fruit
//
// ------------------------------------------------------------------------
{
    $numTypes = 5; // so we know how many types are in our arrays
    $bananaIdx=0;    // initilize the values of our index variables
    $appleIdx=1;
    $orangeIdx=2;
    $mangoIdx=3;
    $pearIdx=3;

    $names[$bananaIdx] = "bananas"; // initilize the fruit name values
    $names[$appleIdx] = "apples";
    $names[$orangeIdx] = "oranges";
    $names[$mangoIdx] = "mangos";
    $names[$pearIdx] = "pears";

    $cost[$bananaIdx] = 1.15; // initilize the price values
    $cost[$appleIdx] = 0.55;
    $cost[$orangeIdx] = 0.55;
    $cost[$mangoIdx] = 1.90;
    $cost[$pearIdx] = 0.68;

    $quantity[$bananaIdx] = 1; // initilize the quantity values
    $quantity[$appleIdx]  = 3;
    $quantity[$orangeIdx] = 4;
    $quantity[$mangoIdx]  = 1;
    $quantity[$pearIdx]   = 2;

    return(%numTypes);
}

function addEmUp($numFruitTypes)
// ------------------------------------------------------------------------
//     Add all prices of different fruit types to get a full total cost
//
//     PARAMETERS: %numTypes -the number of different fruit that are tracked
//
//     RETURNS: total cost of all fruit
//
// ------------------------------------------------------------------------
{
   %total = 0;
   for (%index = 0; %index <= $numFruitTypes; %index++)
   {
      %total = %total + ($quantity[%index]*$cost[%index]);
   }
   return %total;
}


// ------------------------------------------------------------------------
//  countEm
//
//     Add all quantities of different fruit types to get a full total
//
//     PARAMETERS: %numTypes -the number of different fruit that are tracked
//
//     RETURNS: total of all fruit types
//
// ------------------------------------------------------------------------
function countEm($numFruitTypes)
{
   %total = 0;
   for (%index = 0; %index <= $numFruitTypes; %index++)
   {
      %total = %total + $quantity[%index];
   }
}

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

   $numFruitTypes=InitializeFruit(); // set up fruit arrays and variables
   %numFruit=0     // always a good idea to initialize *all* variables!
   %totalCost=0;    // (even if we know we are going to change them later)

   //
   // ----------------- Computation ---------------------
   //

   // Display the known statistics of the fruit collection
   for (%index = 0; %index < $numFruitTypes; %index++)
   {
   print("Cost of " @ $names[%index] @ ":$" @ $cost[%index]);
   print("Number of " @ $names[%index] @ ":" @ $quantity[%index]);
   }

   // count up all the pieces of fruit, and display that result
   %numFruit = countEm($numFruitTypes));
   print("Total pieces of Fruit:" @ %numFruit);

   // now calculate the total cost
   %totalCost = addEmUp($numFruitTypes);
   print("Total Price of Fruit:$" @ %totalCost);
}
