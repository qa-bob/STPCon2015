// ========================================================================
//  Sizeshape.cs
//
//  This module contains the definition of a test shape, which uses
//  a model of a stylized heart. It also contains functions for placing
//  the test shape in the game world and then Sizing the shape.
// ========================================================================

datablock ItemData(TestShape)
// ----------------------------------------------------
//     Definition of the shape object
// ----------------------------------------------------
{
   // Basic Item properties
   shapeFile = "~/data/shapes/items/heart.dts";
   mass = 1;      //we give the shape mass and
   friction = 1;  // friction to stop the item from sliding
                  // down hills
};

function InsertTestShape()
// ----------------------------------------------------
//     Instantiates the test shape, then inserts it
//     into the game world roughly in front of the
//     the player's default spawn location.
// ----------------------------------------------------
{
   // An example function which creates a new TestShape object
   %shape = new Item() {
      datablock = TestShape;
      rotation = "0 0 1 0"; // initialize the values
                            // to something meaningful
   };
   MissionCleanup.add(%shape);

   // Player setup
   %shape.setTransform("-90 -2 20 0 0 1 0"); 
   echo("Inserting Shape " @ %shape);
   return %shape;
}

function SizeShape(%shape, %scale)
// ----------------------------------------------------
//     moves the %shape by %scale amount
// ----------------------------------------------------
{
   %shape.setScale(%scale SPC %scale SPC %scale);    
}

function DoSizeTest()
// ----------------------------------------------------
//     a function to tie together the instantion
//     and the movement in one easy to type function
//     call.
// ----------------------------------------------------
{
   %ms = InsertTestShape();
   SizeShape(%ms,5);
}
