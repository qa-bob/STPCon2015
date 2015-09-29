//============================================================================
// control/client/initialize.cs
//
//  client control initialization module for 3DGPAI1 emaga5 sample game
//
//  Copyright (c) 2003 by Kenneth C.  Finney.
//============================================================================

function InitializeClient()
//----------------------------------------------------------------------------
// Prepare some global client information, fire up the graphics engine,
// and then connect to the server code that is already running in another
// thread.
//----------------------------------------------------------------------------
{
   Echo("\n++++++++++++ Initializing module: emaga5 client ++++++++++++");

   InitBaseClient(); // basic client features defined in the common modules

   // Make sure a canvas has been built before any interface definitions are
   // loaded because most controls depend on the canvas to already exist when
   // they are loaded.

   InitCanvas("Emaga5 - 3DGPAi1 Sample Game"); // Start the graphics system.

   // Interface definitions
   Exec("./profiles.cs");
   Exec("./default_profiles.cs");
   Exec("./interfaces/splashscreen.gui");
   Exec("./interfaces/MenuScreen.gui");
   Exec("./interfaces/loadscreen.gui");
   Exec("./interfaces/playerinterface.gui");

   // Interface scripts
   Exec("./misc/Screens.cs");
   Exec("./misc/presetkeys.cs");
   Exec("./client.cs");

   // these modules rely on things defined in the common code
   // that are activated in the InitBaseClient() function above
   // so must be located after it has been called
   Exec("./misc/transfer.cs");
   Exec("./misc/connection.cs");

   Canvas.setContent(SplashScreen);
}
