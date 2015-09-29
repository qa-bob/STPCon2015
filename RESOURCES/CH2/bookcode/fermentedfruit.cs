// ========================================================================
//  FermentedFruit.cs
//
//  Solution to the anti-optimization challenge
//  this uses no loops at all
// ========================================================================

function main()
// ----------------------------------------------------
//     Entry point for the program.
// ----------------------------------------------------
{
 //
 // ----------------- Initialization ---------------------
 //

 %costBananas = 1.15; // initilize the price values
 %costApples = 0.55;
 %costOranges = 0.55;
 %costMangos = 1.90;
 %costPears = 0.68;

 %quantityBananas = 1; // initilize the quantity values
 %quantityApples  = 3;
 %quantityOranges = 4;
 %quantityMangos  = 1;
 %quantityPears   = 2;

 %numFruit=0;     // always a good idea to initialize *all* variables!
 %totalCost=0;    // (even if we know we are going to change them later)

 //
 // ----------------- Computation ---------------------
 //

 // Display the known statistics of the fruit collection

   print("Cost of bananas:$" @ %costBananas);
   print("Number of bananas:" @ %quantityBananas);
   print("Cost of apples:$" @ %costApples);
   print("Number of apples:" @ %quantityApples);
   print("Cost of oranges:$" @ %costOranges);
   print("Number of oranges:" @ %quantityOranges);
   print("Cost of mangos:$" @ %costMangos);
   print("Number of mangos:" @ %quantityMangos);
   print("Cost of pears:$" @ %costPears);
   print("Number of pears:" @ %quantityPears);

 // count up all the pieces of fruit and calculate the total cost
   %numFruit = %quantityBananas + %quantityApples + %quantityOranges
               + %quantityMangos + %quantityPears;
   %totalCost = (%costBananas * %quantityBananas) +
                (%costApples  * %quantityApples)  +
                (%costOranges * %quantityOranges) +
                (%costMangos  * %quantityMangos)  +
                (%costPears   * %quantityPears);

 // now print the totals
 print("Total pieces of Fruit:" @ %numFruit);
 print("Total Price of Fruit:$" @ %totalCost);
}
