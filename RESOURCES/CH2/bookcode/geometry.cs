// ========================================================================
//  geometry.cs
//
//  This program adds calculates the distance around the perimiter of
//  a quadrilateral, as well as the area of the quadrilateral and outputs the
//  values. It recognizes whether the quadrilateral is a square or a rectangle
//  modifies its output accordingly. Program assumes that all angles in the
//  quadrilateral are equal. Demonstrates the if-else statement.
// ========================================================================

function calcAndPrint(%theWidth, %theHeight)
// ------------------------------------------------------------------------
//    This function does the shape analysis and prints the result.
//
//    PARAMETERS: %theWidth - horizontal dimension
//                %theHeight - vertical dimension
//
//    RETURNS: none
// ------------------------------------------------------------------------
{
  // calculate perimeter
  %perimeter = 2 * (%theWidth+%theHeight);

  // calculate area
  %area = %theWidth * %theHeight;

  // first, setup the dimension output string
  %prompt = "For a " @ %theWidth @ " by " @
             %theHeight @ " quadrilateral, area and perimeter of ";

  // analyze the shape's dimensions and select different
  // descripters based on the shape's dimensions
  if (%theWidth == %theHeight)                // if true, then it's a square
    %prompt = %prompt @ "square: ";
  else                                        // otherwise it's a rectangle
    %prompt = %prompt @ "rectangle: ";

  // always output the analysis
  print (%prompt @ %area @ " " @ %perimeter);
}

function main()
// ------------------------------------------------------------------------
//     Entry point for the program.
// ------------------------------------------------------------------------
{

   // calculate and output the results for three
   // known dimension sets
   calcAndPrint(22, 26); // rectangle
   calcAndPrint(31, 31); // square
   calcAndPrint(47, 98); // rectangle
}
