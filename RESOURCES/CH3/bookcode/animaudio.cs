// ========================================================================
//  animaudio.cs
//
//  This module contains the definition of an audio emitter, which uses
//  a synthetic water drop sound. It also contains functions for placing
//  the test emitter in the game world and moving the emitter.
// ========================================================================

datablock AudioProfile(TestSound)
// ----------------------------------------------------
//     Definition of the audio profile
// ----------------------------------------------------
{
   filename = "~/data/sound/testing.wav"; // wave file to use for the sound
   description = "AudioDefaultLooping3d"; // monophonic sound that repeats
	 preload = false;  // Engine will only load sound if it encounters it 
	                   // in the mission
};

function InsertTestEmitter()
// ----------------------------------------------------
//     Instantiates the test sound, then inserts it
//     into the game world to the right an offset somewhat
//     from the player's default spawn location.
// ----------------------------------------------------
{
   // An example function which creates a new TestSound object
   %emtr = new AudioEmitter() {
      position = "-93.6 -26.83743 13.5325";
      rotation = "1 0 0 0";
      scale = "1 1 1";
      profile = "TestSound"; // Use the profile in the datablock above
      useProfileDescription = "1"; 
      type = "2";
      volume = "1";
      outsideAmbient = "1";
      referenceDistance = "1";
      maxDistance = "100";
      isLooping = "1";
      is3D = "1";
      loopCount = "-1";
      minLoopGap = "0";
      maxLoopGap = "0";
      coneInsideAngle = "360";
      coneOutsideAngle = "360";
      coneOutsideVolume = "1";
      coneVector = "0 0 1";
      minDistance = "20.0";
   };
   MissionCleanup.add(%emtr);

   // Player setup-
   %emtr.setTransform("-200 -30 12 0 0 1 0"); // starting location
   echo("Inserting Audio Emitter " @ %emtr);
   return %emtr;
}

function AnimSound(%snd, %dist)
// ----------------------------------------------------
//     moves the %snd by %dist amount each time
// ----------------------------------------------------
{
   %xfrm = %snd.getTransform();
   %lx = getword(%xfrm,0); // first, get the current transform values
   %ly = getword(%xfrm,1);
   %lz = getword(%xfrm,2);
   %rx = getword(%xfrm,3);
   %ry = getword(%xfrm,4);
   %rz = getword(%xfrm,5);
   %lx += %dist;           // set the new x position 
   %snd.setTransform(%lx SPC %ly SPC %lz SPC %rx SPC %ry SPC %rz SPC %rd);
   schedule(200,0,AnimSound, %snd, %dist);

}

function DoMoveTest()
// ----------------------------------------------------
//     a function to tie together the instantation
//     and the movement in one easy to type function
//     call.
// ----------------------------------------------------
{
   %ms = InsertTestEmitter();
   AnimSound(%ms,1);
}


DoMoveTest();   // by putting this here, we cause the test to start
                // as soon as this module has been loaded into memory
