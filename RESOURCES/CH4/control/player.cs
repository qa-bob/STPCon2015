//------------------------------------------------------------------------
// control/player.cs
//
//  player definition module for 3DGPAI1 emaga4 sample game
//
//  Copyright (c) 2003 by Kenneth C.  Finney.
//------------------------------------------------------------------------

datablock PlayerData(MaleAvatar)
{
   renderFirstPerson = true;
   emap = true;

   className = Avatar;
   shapeFile = "~/player.dts";
   cameraMaxDist = 3;

   mass = 100;
   drag = 0.1;
   maxdrag = 0.5;
   density = 10;
   maxDamage = 100;
   maxEnergy =  100;

   runForce = 50 * 90;
   maxForwardSpeed = 15;
   maxBackwardSpeed = 10;
   maxSideSpeed = 12;

   jumpForce = 10 * 90;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;

   minJumpSpeed = 20;
   maxJumpSpeed = 30;


};


//----------------------------------------------------------------------------
// Avatar Datablock methods
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

function Avatar::onAdd(%this,%obj)
{
}

function Avatar::onRemove(%this, %obj)
{
   if (%obj.client.player == %obj)
      %obj.client.player = 0;
}

