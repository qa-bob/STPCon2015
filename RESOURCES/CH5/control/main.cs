
//------------------------------------------------------------------------
// control/main.cs
//  main control module for 3DGPAI1 emaga chapter4 sample game
//
//  Copyright (c) 2003 by Kenneth C.  Finney.
//------------------------------------------------------------------------
// Run the command window script in hidden mode so it does not freak out the user
//-----------------------------------------------------------------------------
// Load up defaults console values.

// Pre-determined setting variables
Exec("./client/presets.cs");  //exec = execute, runs the presets or set up for the client
Exec("./server/presets.cs");  //exec = execute, runs the presets or set up for the server


// Defaults console values

//-----------------------------------------------------------------------------
// Package overrides to initialize the module
package control {

function OnStart()
//------------------------------------------------------------------------
// Called by root main when package is loaded
//------------------------------------------------------------------------
{
   Parent::OnStart();
   Echo("\n++++++++++++ Initializing control module ++++++++++++");

   // The following scripts contain the preparation code for
   // both the client and server code. A client can also host
   // games, so they need to be able to act as servers if the
   // user wants to host a game. That means we always prepare
   // to be a server at anytime, unless we are launched as a
   // dedicated server.
   Exec("./client/initialize.cs");
   Exec("./server/initialize.cs");
   InitializeServer(); // Prepare the server-specific aspects
   InitializeClient(); // Prepare the client-specific aspects
}

function OnExit()
//------------------------------------------------------------------------
// Called by root main when package is unloaded
//------------------------------------------------------------------------
{

   Parent::onExit();
}

}; // Client package

ActivatePackage(control); // Tell TGE to make the client package active