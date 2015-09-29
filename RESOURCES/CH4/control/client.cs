//============================================================================
// control/client.cs
//
// This module contains client specific code for handling
// the set up and operation of the player's in-game interface.
//
// 3DGPAI1 emaga4 sample game
//
//  Copyright (c) 2003 by Kenneth C.  Finney.
//============================================================================

if ( IsObject( playerKeymap ) )  // If we already have a player key map,
   playerKeymap.delete();        // delete it so that we can make a new one
new ActionMap(playerKeymap);

$movementSpeed = 1;             // m/s   for use by movement functions

//----------------------------------------------------------------------------
// The player sees the game via this control
//----------------------------------------------------------------------------
new GameTSCtrl(PlayerInterface) {
   profile = "GuiContentProfile";
   noCursor = "1";  //This turns the cursor off, however we may want the 
					//cursor on when the user is interacting with menus so we may need to turn it back on later
};

function PlayerInterface::onWake(%this)
//----------------------------------------------------------------------------
// When PlayerInterface is activated, this function is called.
//----------------------------------------------------------------------------
{
   $enableDirectInput = "1";
   activateDirectInput();

   // restore the player's key mappings
   playerKeymap.push();
}

function GameConnection::InitialControlSet(%this)
//----------------------------------------------------------------------------
// This callback is called directly from inside the Torque Engine
// when during server initialization.
//----------------------------------------------------------------------------
{
   Echo ("Setting Initial Control Object");

   // The first control object has been set by the server
   // and we are now ready to go.

   Canvas.SetContent(PlayerInterface);
}


//============================================================================
// Motion Functions
//============================================================================

function GoLeft(%val)
//----------------------------------------------------------------------------
// "strafing"
//----------------------------------------------------------------------------
{
   $mvLeftAction = %val;
}

function GoRight(%val)
//----------------------------------------------------------------------------
// "strafing"
//----------------------------------------------------------------------------
{
   $mvRightAction = %val;
}

function GoAhead(%val)
//----------------------------------------------------------------------------
// running forward
//----------------------------------------------------------------------------
{
   $mvForwardAction = %val;
}

function BackUp(%val)
//----------------------------------------------------------------------------
// running backwards
//----------------------------------------------------------------------------
{
   $mvBackwardAction = %val;
}

function DoYaw(%val)
//----------------------------------------------------------------------------
// looking, spinning or aiming horizontally by mouse or joystick control
//----------------------------------------------------------------------------
{
   $mvYaw += %val * ($cameraFov / 90) * 0.02;
}

function DoPitch(%val)
//----------------------------------------------------------------------------
// looking vertically by mouse or joystick control
//----------------------------------------------------------------------------
{
   $mvPitch += %val * ($cameraFov / 90) * 0.02;
}

function DoJump(%val)
//----------------------------------------------------------------------------
// momentary upward movement, with character animation
//----------------------------------------------------------------------------
{
   $mvTriggerCount2++;
}

//============================================================================
// View Functions
//============================================================================

function Toggle3rdPPOVLook( %val )
//----------------------------------------------------------------------------
// enable the "free look" feature. As long as the mapped key is pressed,
// the player can view his avatar by moving the mouse around.
//----------------------------------------------------------------------------
{
   if ( %val )
      $mvFreeLook = true;
   else
      $mvFreeLook = false;
}

function Toggle1stPPOV(%val)
//----------------------------------------------------------------------------
// switch between 1st and 3rd person point-of-views.
//----------------------------------------------------------------------------
{
   if (%val)
   {
      $firstPerson = !$firstPerson;
   }
}

//============================================================================
// keyboard control mappings
//============================================================================
// these ones available when player is in game
playerKeymap.Bind(keyboard, up, GoAhead);
playerKeymap.Bind(keyboard, down, BackUp);
playerKeymap.Bind(keyboard, left, GoLeft);
playerKeymap.Bind(keyboard, right, GoRight);
playerKeymap.Bind( keyboard, numpad0, DoJump ); //swich this with the space bar
playerKeymap.Bind( mouse, xaxis, DoYaw );
playerKeymap.Bind( mouse, yaxis, DoPitch );
//what does the mouse wheel do?  It should zoom in and out.
playerKeymap.Bind( keyboard, z, Toggle3rdPPOVLook );
playerKeymap.Bind( keyboard, tab, Toggle1stPPOV );

// these ones are always available
GlobalActionMap.BindCmd(keyboard, escape, "", "quit();");
GlobalActionMap.Bind(keyboard, tilde, ToggleConsole);


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