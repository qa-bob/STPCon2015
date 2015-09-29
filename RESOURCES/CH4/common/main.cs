//------------------------------------------------------------------------
//  common/main.cs
//
//  common main module for emaga4 sample game
//
//  Copyright (c) 2003 by Kenneth C.  Finney.
//------------------------------------------------------------------------

// ========================================================================
// ========================= Initializations ==============================
// ========================================================================

//-----------------------------------------------------------------------------
// Load up defaults console values.

Exec("./presets.cs");

//-----------------------------------------------------------------------------

function InitCommon()
//------------------------------------------------------------------------
//
//------------------------------------------------------------------------
{
   // All mods need the random seed set
   SetRandomSeed();

   // Very basic functions used by everyone
   Exec("./client/canvas.cs");
   Exec("./client/audio.cs");
}

function InitBaseClient()
//------------------------------------------------------------------------
//
//------------------------------------------------------------------------
{
   // Base client functionality
   Exec("./client/message.cs");
   Exec("./client/mission.cs");
   Exec("./client/missionDownload.cs");
   Exec("./client/actionMap.cs");
   Exec("./editor/editor.cs");

   // There are also a number of support scripts loaded by the canvas
   // when it's first initialized.  Check out client/canvas.cs
}

function InitBaseServer()
//------------------------------------------------------------------------
//
//------------------------------------------------------------------------
{
   // Base server functionality
   Exec("./server/audio.cs");
   Exec("./server/server.cs");
   Exec("./server/message.cs");
   Exec("./server/commands.cs");
   Exec("./server/missionInfo.cs");
   Exec("./server/missionLoad.cs");
   Exec("./server/missionDownload.cs");
   Exec("./server/clientConnection.cs");
   Exec("./server/game.cs");
}


//-----------------------------------------------------------------------------
package common {

function displayHelp() {
   Parent::displayHelp();
   Error(
      "Common options:\n"@
      "  -fullscreen            Starts game in full screen mode\n"@
      "  -windowed              Starts game in windowed mode\n"@
      "  -autoVideo             Auto detect video, but prefers OpenGL\n"@
      "  -openGL                Force OpenGL acceleration\n"@
      "  -directX               Force DirectX acceleration\n"@
      "  -voodoo2               Force Voodoo2 acceleration\n"@
      "  -noSound               Starts game without sound\n"@
      "  -prefs <configFile>    Exec the config file\n"
   );
}

function ParseArgs()
//------------------------------------------------------------------------
//
//------------------------------------------------------------------------
{
   Parent::ParseArgs();

   // Arguments override defaults...
   for (%i = 1; %i < $Game::argc ; %i++)
   {
      %arg = $Game::argv[%i];
      %nextArg = $Game::argv[%i+1];
      %hasNextArg = $Game::argc - %i > 1;

      switch$ (%arg)
      {
         //--------------------
         case "-fullscreen":
            $pref::Video::fullScreen = 1;
            $argUsed[%i]++;

         //--------------------
         case "-windowed":
            $pref::Video::fullScreen = 0;
            $argUsed[%i]++;
         //--------------------
         case "-openGL":
            $pref::Video::displayDevice = "OpenGL";
            $argUsed[%i]++;

         //--------------------
         case "-directX":
            $pref::Video::displayDevice = "D3D";
            $argUsed[%i]++;

         //--------------------
         case "-voodoo2":
            $pref::Video::displayDevice = "Voodoo2";
            $argUsed[%i]++;

         //--------------------
         case "-autoVideo":
            $pref::Video::displayDevice = "";
            $argUsed[%i]++;

         //--------------------
         case "-prefs":
            $argUsed[%i]++;
            if (%hasNextArg) {
               Exec(%nextArg, true, true);
               $argUsed[%i+1]++;
               %i++;
            }
            else
               Error("Error: Missing Command Line argument. Usage: -prefs <path/script.cs>");
      }
   }
}

function OnStart()
//------------------------------------------------------------------------
// Called by root main when package is loaded
//------------------------------------------------------------------------
{
   Parent::OnStart();
   Echo("\n--------- Initializing module: Common ---------");
   InitCommon();
}

function OnExit()
//------------------------------------------------------------------------
// Called by root main when package is unloaded
//------------------------------------------------------------------------
{

   Parent::OnExit();
}

};

// Common package
Echo("*** Activating common package ***");
ActivatePackage(common);
