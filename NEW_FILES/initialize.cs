//============================================================================
// control/initialize.cs    v0.2
//
//  control initialization module for 3DGPAI1 emaga4 sample game
//
//  Copyright (c) 2003 by Kenneth C.  Finney.
//============================================================================


function InitializeServer()
//----------------------------------------------------------------------------
// Prepare some global server information & load the game-specific module
//----------------------------------------------------------------------------
{
   Echo("\n--------- Initializing module: emaga server ---------");

   // Specify where the mission files are.
   $Server::MissionFileSpec = "*/missions/*.mis";

   InitBaseServer(); // basic server features defined in the common modules

   // Load up game server support script
   Exec("./server.cs");

   createServer("SinglePlayer", "control/data/maps/book_ch4.mis");
}


function InitializeClient()
//----------------------------------------------------------------------------
// Prepare some global client information, fire up the graphics engine,
// and then connect to the server code that is already running in another
// thread.
//----------------------------------------------------------------------------
{
   Echo("\n--------- Initializing module: emaga client ---------");

   InitBaseClient(); // basic client features defined in the common modules

  // these are necessary graphics settings
  $pref::Video::allowOpenGL   = true;
  $pref::Video::displayDevice = "OpenGL";

   // Make sure a canvas has been built before any gui scripts are
   // executed because many of the controls depend on the canvas to
   // already exist when they are loaded.

   InitCanvas("Egama4 - 3DGPAi1 Sample Game"); // Start the graphics system.

   Exec("./client.cs");

   %conn = new GameConnection(ServerConnection);
   %conn.connectLocal();
}
