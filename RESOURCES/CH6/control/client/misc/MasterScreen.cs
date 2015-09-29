//============================================================================
// control/client/misc/ServerScreen.cs
//
//  Master Server query code module for 3DGPAI1 emaga6 sample game
//
//  Copyright (c) 2003 by Kenneth C.  Finney.
//============================================================================

//----------------------------------------
function ServerScreen::onWake()
{
   // Double check the status. Tried setting this the control
   // inactive to start with, but that didn't seem to work.
   MasterJoinServer.SetActive(MasterServerList.rowCount() > 0);
   ServerScreen.queryLan();
}

//----------------------------------------
function ServerScreen::queryLan(%this)
{
   queryLANServers(
      28000,      // lanPort for local queries
      0,          // Query flags
      $Client::GameTypeQuery,       // gameTypes
      $Client::MissionTypeQuery,    // missionType
      0,          // minPlayers
      100,        // maxPlayers
      0,          // maxBots
      2,          // regionMask
      0,          // maxPing
      100,        // minCPU
      0           // filterFlags
      );
}

//----------------------------------------
function ServerScreen::Query(%this)
{

   QueryMasterServer(
      0,          // Query flags
      $Client::GameTypeQuery,       // gameTypes
      $Client::MissionTypeQuery,    // missionType
      0,          // minPlayers
      100,        // maxPlayers
      0,          // maxBots
      2,          // regionMask
      0,          // maxPing
      100,        // minCPU
      0           // filterFlags
      );
}

//----------------------------------------
function ServerScreen::Cancel(%this)
{
   CancelServerQuery();
}


//----------------------------------------
function ServerScreen::Join(%this)
{
   CancelServerQuery();
   %id = MasterServerList.GetSelectedId();

   // The server info index is stored in the row along with the
   // rest of displayed info.
   %index = getField(MasterServerList.GetRowTextById(%id),6);
   if (SetServerInfo(%index)) {
      %conn = new GameConnection(ServerConnection);
      %conn.SetConnectArgs($pref::Player::Name);
      %conn.SetJoinPassword($Client::Password);
      %conn.Connect($ServerInfo::Address);
   }
}

//----------------------------------------
function ServerScreen::Close(%this)
{
   cancelServerQuery();
   Canvas.SetContent(MenuScreen);
}

//----------------------------------------
function ServerScreen::Update(%this)
{
   // Copy the servers into the server list.
   MasterQueryStatus.SetVisible(false);
   MasterServerList.Clear();
   %sc = getServerCount();
   for (%i = 0; %i < %sc; %i++) {
      setServerInfo(%i);
      MasterServerList.AddRow(%i,
         ($ServerInfo::Password? "Yes": "No") TAB
         $ServerInfo::Name TAB
         $ServerInfo::Ping TAB
         $ServerInfo::PlayerCount @ "/" @ $ServerInfo::MaxPlayers TAB
         $ServerInfo::Version TAB
         $ServerInfo::GameType TAB
         %i);  // ServerInfo index stored also
   }
   MasterServerList.Sort(0);
   MasterServerList.SetSelectedRow(0);
   MasterServerList.scrollVisible(0);

   MasterJoinServer.SetActive(MasterServerList.rowCount() > 0);
}

//----------------------------------------
function onServerQueryStatus(%status, %msg, %value)
{
   // Update query status
   // States: start, update, ping, query, done
   // value = % (0-1) done for ping and query states
   if (!MasterQueryStatus.IsVisible())
      MasterQueryStatus.SetVisible(true);

   switch$ (%status) {
      case "start":

      case "ping":
         MasterStatusText.SetText("Finding Hosts");
         MasterStatusBar.SetValue(%value);

      case "query":

      case "done":
         MasterQueryMaster.SetActive(true);
         MasterQueryStatus.SetVisible(false);
         ServerScreen.update();
   }
}
