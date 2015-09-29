// ========================================================================
//  turnshape.cs
//
//  This module contains the definition of a test shape, which uses
//  a model of a medical kit. It contains functions for placing
//  the test shape in the game world and rotating the shape according to
//  a recurring scheduled function call.
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

function TurnShape(%shape, %angle)
// ----------------------------------------------------
//     turns the %shape by %angle amount, and then
//     schedules itself to be called again in 1/5
//     of a second.
// ----------------------------------------------------
{
   %xfrm = %shape.getTransform();
   %lx = getword(%xfrm,0);
   %ly = getword(%xfrm,1);
   %lz = getword(%xfrm,2);
   %rx = getword(%xfrm,3);
   %ry = getword(%xfrm,4);
   %rz = getword(%xfrm,5);
   %rd = getword(%xfrm,6);
   %angle += 1;
   %rd = %angle;
   %shape.setTransform(%lx SPC %ly SPC %lz SPC %rx SPC %ry SPC %rz SPC %rd);
   schedule(1000,0,TurnShape, %shape, %angle);
}

function DoTurnTest()
// ----------------------------------------------------
//     a function to tie together the instantion
//     and the movement in one easy to type function
//     call.
// ----------------------------------------------------
{
   %ts = InsertTestShape();
   TurnShape(%ts,0.0);
}
