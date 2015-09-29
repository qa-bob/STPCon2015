//============================================================================
// control/client/misc/presetkeys.cs
//
// Copyright (c) 2003 Kenneth C. Finney
//============================================================================

if ( IsObject(PlayerKeymap) )  // If we already have a player key map,
   PlayerKeymap.delete();        // delete it so that we can make a new one
new ActionMap(PlayerKeymap);

$movementSpeed = 1;             // m/s   for use by movement functions


//------------------------------------------------------------------------------
// Non-remapable binds
//------------------------------------------------------------------------------

function DoExitGame()
{
   MessageBoxYesNo( "Quit Mission", "Exit from this Mission?", "Quit();", "");
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
function Left(%val)
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
function Right(%val)
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
function Forward(%val)
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
function Back(%val)
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
function Jump(%val)
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

function MouseAction(%val)
{
   $mvTriggerCount0++;
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
PlayerKeymap.Bind( mouse, button0, MouseAction ); // left mouse button
//Mouse button1 should be right click, I would expect my inventory to come up with the right click
PlayerKeymap.Bind(keyboard, up, Forward);
PlayerKeymap.Bind(keyboard, w, GoAhead);
PlayerKeymap.Bind(keyboard, down, Back);
PlayerKeymap.Bind(keyboard, s, BackUp);
PlayerKeymap.Bind(keyboard, left, GoLeft);
PlayerKeymap.Bind(keyboard, a, Left);
PlayerKeymap.Bind(keyboard, right, GoRight);
PlayerKeymap.Bind(keyboard, d, Right);
PlayerKeymap.Bind(keyboard, numpad0, DoJump );
PlayerKeymap.Bind(keyboard, space, Jump );
PlayerKeymap.Bind(keyboard, z, Toggle3rdPPOVLook );
PlayerKeymap.Bind(keyboard, tab, Toggle1stPPOV );
PlayerKeymap.Bind(mouse, xaxis, DoYaw );
PlayerKeymap.Bind(mouse, yaxis, DoPitch );

// these ones are always available

GlobalActionMap.Bind(keyboard, escape, DoExitGame);
GlobalActionMap.Bind(keyboard, tilde, ToggleConsole);






function dropCameraAtPlayer(%val)
{
   if (%val)
      commandToServer('dropCameraAtPlayer');
}

function dropPlayerAtCamera(%val)
{
   if (%val)
      commandToServer('DropPlayerAtCamera');
}
function toggleCamera(%val)
{
   if (%val)
   {
      commandToServer('ToggleCamera');
      }
}

PlayerKeymap.bind(keyboard, "F8", dropCameraAtPlayer);
PlayerKeymap.bind(keyboard, "F7", dropPlayerAtCamera);

PlayerKeymap.bind(keyboard, "F6", toggleCamera);