//============================================================================
// control/game.cs
//
//  server-side game specific module for 3DGPAI1 emaga4 sample game
//  provides client connection management and and player/avatar spawning
//
//  Copyright (c) 2003 by Kenneth C.  Finney.
//============================================================================


function OnServerCreated()
//----------------------------------------------------------------------------
// Once the engine has fired up the server, this function is called
//----------------------------------------------------------------------------
{
   Exec("./player.cs"); // Load the player datablocks and methods
}


//============================================================================
// GameConnection Methods
// Extensions to the GameConnection class. Here we add some methods
// to handle player spawning and creation.
//============================================================================

function GameConnection::OnClientEnterGame(%this)
//----------------------------------------------------------------------------
// Called when the client has been accepted into the game by the server.
//----------------------------------------------------------------------------
{
   // Create a player object.
   %this.spawnPlayer();  //What is the %this variable for and what is its value?
}


function GameConnection::SpawnPlayer(%this)
//----------------------------------------------------------------------------
// This is where we place the player spawn decision code.
// It might also call a function that would figure out the spawn
// point transforms by looking up spawn markers.
// Once we know where the player will spawn, then we create the avatar.
//----------------------------------------------------------------------------
{

   %this.createPlayer("0 0 220 1 0 0 0");
}



function GameConnection::CreatePlayer(%this, %spawnPoint)
//----------------------------------------------------------------------------
// Create the player's avatar object, set it up, and give the player control
// of it.
//----------------------------------------------------------------------------
{
   if (%this.player > 0)//The player should NOT already have an avatar object.
   {                     // if he does, that's a Bad Thing.
      Error( "Attempting to create an angus ghost!" );
   }

   // Create the player object
   %player = new Player() {
      dataBlock = MaleAvatar;   // defined in player.cs
      client = %this;           // the avatar will have a pointer to its
   };                           // owner's connection

   // Player setup...
   %player.setTransform(%spawnPoint); // where to put it

   // Give the client control of the player
   %this.player = %player;
   %this.setControlObject(%player);
}

//============================================================================
// the following functions are called from the server common code modules
// these stubs are added here to prevent warning messages from cluttering
// up the log file.
//============================================================================
function ClearCenterPrintAll()
{
}
function ClearBottomPrintAll()
{
}