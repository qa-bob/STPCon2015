//============================================================================
// control/server/server.cs
//
//  server-side game specific module for 3DGPAI1 emaga6 sample game
//  provides client connection management and and player/avatar spawning
//
//  Copyright (c) 2003 by Kenneth C.  Finney.
//============================================================================

//============================================================================
// GameConnection Methods
// Extensions to the GameConnection class. Here we add some methods
// to handle player spawning and creation.
//============================================================================

function OnServerCreated()
//----------------------------------------------------------------------------
// Once the engine has fired up the server, this function is called
//----------------------------------------------------------------------------
{
   $Game::StartTime = 0;

   Exec("./misc/camera.cs");
   Exec("./misc/shapeBase.cs");
   Exec("./misc/item.cs");
   Exec("./players/player.cs"); // Load the player datablocks and methods
   Exec("./players/beast.cs"); // Load the player datablocks and methods
   Exec("./players/ai.cs"); // Load the player datablocks and methods
   Exec("./weapons/weapon.cs");
   Exec("./weapons/crossbow.cs");
}

function startGame()
{
   if ($Game::Duration) // Start the game timer
      $Game::Schedule = schedule($Game::Duration * 1000, 0, "onGameDurationEnd" );
   $Game::Running = true;
   schedule( 2000, 0, "CreateBots");
}

function onMissionLoaded()
{
   // Called by loadMission() once the mission is finished loading.
   // Nothing special for now, just start up the game play.
   startGame();
}

function onMissionEnded()
{
   cancel($Game::Schedule);
   $Game::Running = false;
}

function GameConnection::OnClientEnterGame(%this)
//----------------------------------------------------------------------------
// Called when the client has been accepted into the game by the server.
//----------------------------------------------------------------------------
{
   // Create a new camera object.
   %this.camera = new Camera() {
      dataBlock = Observer;
   };
   MissionCleanup.add( %this.camera );

   // Create a player object.
   %this.spawnPlayer();
}

function GameConnection::SpawnPlayer(%this)
//----------------------------------------------------------------------------
// This is where we place the player spawn decision code.
// It might also call a function that would figure out the spawn
// point transforms by looking up spawn markers.
// Once we know where the player will spawn, then we create the avatar.
//----------------------------------------------------------------------------
{

   %this.createPlayer("0 0 201 1 0 0 0");
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
      dataBlock = HumanMaleAvatar;   // defined in players/player.cs
      client = %this;           // the avatar will have a pointer to its
   };                           // owner's connection

   // Player setup...
   %player.setTransform(%spawnPoint); // where to put it

   // Update the camera to start with the player
   %this.camera.setTransform(%player.getEyeTransform());
   %player.setEnergyLevel(100);

   // Give the client control of the player
   %this.player = %player;
   %this.setControlObject(%player);
}

function GameConnection::onDeath(%this, %sourceObject, %sourceClient, %damageType, %damLoc)
{

   // Switch the client over to the death cam and unhook the player object.
   if (IsObject(%this.camera) && IsObject(%this.player))
   {
      %this.camera.setMode("Death",%this.player);
      %this.setControlObject(%this.camera);
   }
   %this.player = 0;

   // Doll out points and display an appropriate message
   if (%damageType $= "Suicide" || %sourceClient == %this)
   {

   }
   else
   {
   }
}

function serverCmdToggleCamera(%client)
//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
{
   %co = %client.getControlObject();
   if (%co == %client.player)
   {
      %co = %client.camera;
      %co.mode = toggleCameraFly;
   }
   else
   {
      %co = %client.player;
      %co.mode = observerFly;
   }
   %client.setControlObject(%co);
}

function serverCmdDropPlayerAtCamera(%client)
//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
{
   if ($Server::DevMode || IsObject(EditorGui))
   {
      %client.player.setTransform(%client.camera.getTransform());
      %client.player.setVelocity("0 0 0");
      %client.setControlObject(%client.player);
   }
}

function serverCmdDropCameraAtPlayer(%client)
//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
{
   %client.camera.setTransform(%client.player.getEyeTransform());
   %client.camera.setVelocity("0 0 0");
   %client.setControlObject(%client.camera);
}


function serverCmdUse(%client,%data)
//-----------------------------------------------------------------------------
// Server Item Use
//-----------------------------------------------------------------------------
{
   %client.getControlObject().use(%data);
}

function centerPrintAll( %message, %time, %lines )
//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
{
   if( %lines $= "" || ((%lines > 3) || (%lines < 1)) )
      %lines = 1;

   %count = ClientGroup.getCount();
   for (%i = 0; %i < %count; %i++)
	{
		%cl = ClientGroup.getObject(%i);
      if( !%cl.isAIControlled() )
         commandToClient( %cl, 'centerPrint', %message, %time, %lines );
   }
}

function bottomPrintAll( %message, %time, %lines )
//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
{
   if( %lines $= "" || ((%lines > 3) || (%lines < 1)) )
      %lines = 1;

   %count = ClientGroup.getCount();
	for (%i = 0; %i < %count; %i++)
	{
		%cl = ClientGroup.getObject(%i);
      if( !%cl.isAIControlled() )
         commandToClient( %cl, 'bottomPrint', %message, %time, %lines );
   }
}

//-------------------------------------------------------------------------------------------------------

function centerPrint( %client, %message, %time, %lines )
//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
{
   if( %lines $= "" || ((%lines > 3) || (%lines < 1)) )
      %lines = 1;


   commandToClient( %client, 'CenterPrint', %message, %time, %lines );
}

function bottomPrint( %client, %message, %time, %lines )
//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
{
   if( %lines $= "" || ((%lines > 3) || (%lines < 1)) )
      %lines = 1;

   commandToClient( %client, 'BottomPrint', %message, %time, %lines );
}

//-------------------------------------------------------------------------------------------------------

function clearCenterPrint( %client )
//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
{
   commandToClient( %client, 'ClearCenterPrint');
}

function clearBottomPrint( %client )
//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
{
   commandToClient( %client, 'ClearBottomPrint');
}

//-------------------------------------------------------------------------------------------------------

function clearCenterPrintAll()
//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
{
	%count = ClientGroup.getCount();
	for (%i = 0; %i < %count; %i++)
	{
		%cl = ClientGroup.getObject(%i);
      if( !%cl.isAIControlled() )
         commandToClient( %cl, 'ClearCenterPrint');
   }
}

function clearBottomPrintAll()
//-----------------------------------------------------------------------------
//
//-----------------------------------------------------------------------------
{
	%count = ClientGroup.getCount();
	for (%i = 0; %i < %count; %i++)
	{
		%cl = ClientGroup.getObject(%i);
      if( !%cl.isAIControlled() )
         commandToClient( %cl, 'ClearBottomPrint');
   }
}