//============================================================================
// control/client/initialize.cs
//
//  client control initialization module for 3DGPAI1 emaga6 sample game
//
//  Copyright (c) 2003 by Kenneth C.  Finney.
//============================================================================

// Used to query the master server


function InitializeClient()
//----------------------------------------------------------------------------
// Prepare some global client information, fire up the graphics engine,
// and then connect to the server code that is already running in another
// thread.
//----------------------------------------------------------------------------
{
   Echo("\n++++++++++++ Initializing module: emaga6 client ++++++++++++");

  $Client::GameTypeQuery = "3DGPAI1";
  $Client::MissionTypeQuery = "Any";
   InitBaseClient(); // basic client features defined in the common modules

   // Make sure a canvas has been built before any interface definitions are
   // loaded because most controls depend on the canvas to already exist when
   // they are loaded.

   InitCanvas("emaga6 - 3DGPAi1 Sample Game"); // Start the graphics system.

   // Interface definitions
   Exec("./profiles.cs");
   Exec("./default_profiles.cs");
   Exec("./interfaces/splashscreen.gui");
   Exec("./interfaces/menuScreen.gui");
   Exec("./interfaces/loadscreen.gui");
   Exec("./interfaces/playerinterface.gui");
   Exec("./interfaces/serverscreen.gui");

   // Interface scripts
   Exec("./misc/screens.cs");
   Exec("./misc/serverscreen.cs");

   Exec("./misc/presetkeys.cs");
   Exec("./client.cs");

   // these modules rely on things defined in the common code
   // that are activated in the InitBaseClient() function above
   // so must be located after it has been called
   Exec("./misc/transfer.cs");
   Exec("./misc/connection.cs");


   Canvas.setContent(SplashScreen);
   SetNetPort(0);
}
