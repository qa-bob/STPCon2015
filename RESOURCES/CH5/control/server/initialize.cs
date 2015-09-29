//============================================================================
// control/server/initialize.cs
//
//  server control initialization module for 3DGPAI1 emaga5 sample game
//
//  Copyright (c) 2003 by Kenneth C.  Finney.
//============================================================================


function InitializeServer()
//----------------------------------------------------------------------------
// Prepare some global server information & load the game-specific module
//----------------------------------------------------------------------------
{
   Echo("\n++++++++++++ Initializing module: emaga5 server ++++++++++++");

   // Specify where the mission files are.
   $Server::MissionFileSpec = "*/missions/*.mis";

   InitBaseServer(); // basic server features defined in the common modules

   // Load up game server support script
   Exec("./server.cs");
}