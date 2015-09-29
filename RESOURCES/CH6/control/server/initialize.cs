//============================================================================
// control/server/initialize.cs
//
//  server control initialization module for 3DGPAI1 emaga6 sample game
//
//  Copyright (c) 2003 by Kenneth C.  Finney.
//============================================================================
$Pref::Server::AdminPassword = "";
$Pref::Server::BanTime = 1800;
$pref::Master0 = "2:master.garagegames.com:28002"; //added to the file 1/9/2012
$Pref::Server::ConnectionError = "You do not have the correct version of 3DGPAI1 client or the related art needed to play on this server. This is the server for Chapter 6. Please check that chapter for directions.";
$Pref::Server::FloodProtectionEnabled = 1;
$Pref::Server::Info = "3D Game Programming All-In-One by Kenneth C. Finney.";
$Pref::Server::KickBanTime = 300;
$Pref::Server::MaxChatLen = 120;
$Pref::Server::MaxPlayers = 64;
$Pref::Server::Name = "3DGPAI1 Book - Chapter 6 Server";
$Pref::Server::Password = "";
$Pref::Server::Port = 28000;
$Pref::Server::RegionMask = 2;
$Pref::Server::TimeLimit = 20;

$Pref::Net::LagThreshold = "400";
$pref::Net::PacketRateToClient = "10";
$pref::Net::PacketRateToServer = "32";
$pref::Net::PacketSize = "200";
$pref::Net::Port = 28000;

function InitializeServer()
//----------------------------------------------------------------------------
// Prepare some global server information & load the game-specific module
//----------------------------------------------------------------------------
{
   Echo("\n++++++++++++ Initializing module: emaga6 server ++++++++++++");
   $Server::GameType = "3DGPAI1";
   $Server::MissionType = "Emaga6";
   $Server::Status = "Unknown";
   $Server::TestCheats = false;

   // Specify where the mission files are.
   $Server::MissionFileSpec = "*/missions/*.mis";

   InitBaseServer(); // basic server features defined in the common modules

   // Load up game server support script
   Exec("./server.cs");
}

function InitializeDedicatedServer()
//------------------------------------------------------------------------
// Dedicated server will need a windows console and an initial start
//    mission. It always launches in multiplayer mode, of course.
//------------------------------------------------------------------------
{
   EnableWinConsole(true);
   Echo("\n--------- Starting Dedicated Server ---------");

   // Make sure this variable reflects the correct state.
   $Server::Dedicated = true;

   // The server isn't started unless a mission has been specified.
   if ($missionArg !$= "") {
      CreateServer("MultiPlayer", $missionArg);
   }
   else
      Echo("No mission specified (use -mission filename)");
}
