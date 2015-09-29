// ========================================================================
//  animshape.cs
//
//  This module contains the definition of a test shape, which uses
//  a model of a stylized heart. It also contains functions for placing
//  the test shape in the game world and then animating the shape using
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
   };
   MissionCleanup.add(%shape);

   // Player setup
   %shape.setTransform("-90 -2 20 0 0 1 90");
   echo("Inserting Shape " @ %shape);
   return %shape;
}

function AnimShape(%shape, %dist, %angle, %scale)
// ----------------------------------------------------
//     moves the %shape by %dist amount, and then
//     schedules itself to be called again in 1/5
//     of a second.
// ----------------------------------------------------
{
   %xfrm = %shape.getTransform();
   %lx = getword(%xfrm,0); // first, get the current transform values
   %ly = getword(%xfrm,1);
   %lz = getword(%xfrm,2);
   %rx = getword(%xfrm,3);
   %ry = getword(%xfrm,4);
   %rz = getword(%xfrm,5);
   %rd = getword(%xfrm,6);
   %lx += %dist;           // set the new x position

   %rd = %rd + %angle;

   if ($grow)             // if the shape is growing larger
   {
    if (%scale < 5.0)     // and hasn't gotten too big
      %scale += 0.1;      // make it bigger
    else
      $grow = false;      // if it's too big, don't let it grow more
   }
   else                 // if it's shrinking
   {
    if (%scale > 4.5)  // and isn't too small
      %scale -= 0.1;   // then make it smaller
    else
      $grow = true;   // if it's too small, don't let it grow smaller
   }

   %shape.setScale(%scale SPC %scale SPC %scale);
   %shape.setTransform(%lx SPC %ly SPC %lz SPC %rx SPC %ry SPC %rz SPC %rd);
   schedule(200,0,AnimShape, %shape, %dist, %angle, %scale);

}

function DoAnimTest()
// ----------------------------------------------------
//     a function to tie together the instantion
//     and the movement in one easy to type function
//     call.
// ----------------------------------------------------
{
   %ms = InsertTestShape();
   $grow = true;
   AnimShape(%ms,0.1,mDegToRad(1), 2);
}
