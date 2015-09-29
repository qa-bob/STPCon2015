//============================================================================
// control/client/misc/connection.cs
//
// Copyright (c) 2003 Kenneth C. Finney
//============================================================================

// Functions dealing with Connecting to a server


//-----------------------------------------------------------------------------
// Server Connection Error
//-----------------------------------------------------------------------------

addMessageCallback( 'MsgConnectionError', handleConnectionErrorMessage );

function handleConnectionErrorMessage(%msgType, %msgString, %msgError)
{
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   echo("handleConnectionErrorMessage");
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   // On Connect the server transmits a message to display if there
   // are any problems with the Connection.  Most Connection Errors
   // are game version differences, so hopefully the server message
   // will tell us where to get the latest version of the game.
   $ServerConnectionErrorMessage = %msgError;
}


//----------------------------------------------------------------------------
// GameConnection client callbacks
//----------------------------------------------------------------------------


function GameConnection::InitialControlSet(%this)
//----------------------------------------------------------------------------
// This callback is called directly from inside the Torque Engine
// during server initialization.
//----------------------------------------------------------------------------
{
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   echo("GameConnection::InitialControlSet");
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   Echo ("Setting Initial Control Object");

   // The first control object has been set by the server
   // and we are now ready to go.

   Canvas.SetContent(PlayerInterface);
   echo("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz");
   echo("GameConnection::InitialControlSet");
   echo("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz");
}



function GameConnection::setLagIcon(%this, %state)
{

   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   echo("GameConnection::setLagIcon");
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
}

function GameConnection::onConnectionAccepted(%this)
{

   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   echo("GameConnection::onConnectionAccepted");
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
}

function GameConnection::onConnectionTimedOut(%this)
{
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   echo("GameConnection::onConnectionTimedOut");
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   // Called when an established Connection times out
   disConnectedCleanup();
   MessageBoxOK( "TIMED OUT", "The server Connection has timed out.");
}

function GameConnection::onConnectionDropped(%this, %msg)
{
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   echo("GameConnection::onConnectionDropped");
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   // Established Connection was dropped by the server
   disConnectedCleanup();
   MessageBoxOK( "DISConnect", "The server has dropped the Connection: " @ %msg);
}

function GameConnection::onConnectionError(%this, %msg)
{
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   echo("GameConnection::onConnectionError");
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   // General Connection Error, usually raised by ghosted objects
   // initialization problems, such as missing files.  We'll display
   // the server's Connection Error message.
   disConnectedCleanup();
   MessageBoxOK( "DISConnect", $ServerConnectionErrorMessage @ " (" @ %msg @ ")" );
}


//----------------------------------------------------------------------------
// Connection Failed Events
//----------------------------------------------------------------------------

function GameConnection::onConnectRequestRejected( %this, %msg )
{
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   echo("GameConnection::onConnectRequestRejected");
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   switch$(%msg)
   {
      case "CR_INVALID_PROTOCOL_VERSION":
         %Error = "Incompatible protocol version: Your game version is not compatible with this server.";
      case "CR_INVALID_Connect_PACKET":
         %Error = "Internal Error: badly formed network packet";
      case "CR_YOUAREBANNED":
         %Error = "You are not allowed to play on this server.";
      case "CR_SERVERFULL":
         %Error = "This server is full.";
      case "CHR_PASSWORD":
         // XXX Should put up a password-entry dialog.
         if ($Client::Password $= "")
            MessageBoxOK( "REJECTED", "That server requires a password.");
         else {
            $Client::Password = "";
            MessageBoxOK( "REJECTED", "That password is incorrect.");
         }
         return;
      case "CHR_PROTOCOL":
         %Error = "Incompatible protocol version: Your game version is not compatible with this server.";
      case "CHR_CLASSCRC":
         %Error = "Incompatible game classes: Your game version is not compatible with this server.";
      case "CHR_INVALID_CHALLENGE_PACKET":
         %Error = "Internal Error: Invalid server response packet";
      default:
         %Error = "Connection Error.  Please try another server.  Error code: (" @ %msg @ ")";
   }
   disConnectedCleanup();
   MessageBoxOK( "REJECTED", %Error);
}

function GameConnection::onConnectRequestTimedOut(%this)
{
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   echo("GameConnection::onConnectRequestTimedOut");
   echo("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
   disConnectedCleanup();
   MessageBoxOK( "TIMED OUT", "Your Connection to the server timed out." );
}


//-----------------------------------------------------------------------------
// DisConnect
//-----------------------------------------------------------------------------

function Disconnect()
{
   // Delete the Connection if it's still there.
   if (IsObject(ServerConnection))
      ServerConnection.delete();
   disConnectedCleanup();

   // Call destroyServer in case we're hosting
   destroyServer();
}

function disConnectedCleanup()
{
   // Clear misc script stuff
   HudMessageVector.clear();


   // Back to the launch screen
   Canvas.setContent(MenuScreen);

   // Dump anything we're not using
   ClearTextureHolds();
   PurgeResources();
}

