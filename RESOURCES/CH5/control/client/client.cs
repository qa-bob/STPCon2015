//============================================================================
// control/client/client.cs
//
// This module contains client specific code for handling
// the set up and operation of the player's in-game interface.
//
//  Copyright (c) 2003 by Kenneth C.  Finney.
//============================================================================


function LaunchGame()
{
   createServer("SinglePlayer", "control/data/maps/book_ch5.mis");
   %conn = new GameConnection(ServerConnection);
   %conn.setConnectArgs("Reader");
   %conn.connectLocal();
}

function clientCmdStartGame(%seq)
{
}

function clientCmdSyncClock(%time)
// called from within the common code
{
   // Store the base time in the hud control it will automatically increment.
   HudClock.setTime(%time);
}

//============================================================================
// the following functions are called from the client common code modules
// these stubs are added here to prevent warning messages from cluttering
// up the log file.
//============================================================================
function onServerMessage()
{
}
function onMissionDownloadPhase1()
{
}
function onPhase1Progress()
{
}
function onPhase1Complete()
{
}
function onMissionDownloadPhase2()
{
}
function onPhase2Progress()
{
}
function onPhase2Complete()
{
}
function onPhase3Complete()
{
}
function onMissionDownloadComplete()
{
}

function ShowMenuScreen()
{
   // Startup the client with the menu...
   Canvas.setContent( MenuScreen );
   Canvas.setCursor("DefaultCursor");
}

function SplashScreenInputCtrl::onInputEvent(%this, %dev, %evt, %make)
{
   if(%make)
   {
     ShowMenuScreen();
   }
}