//============================================================================
// control/client/misc/serverscreen.cs
//
//  Master Server query code module for 3DGPAI1 koob23 sample game
//
//  Copyright (c) 2003 by Kenneth C.  Finney.
//============================================================================

//----------------------------------------
function ServerScreen::onWake()
{
   // Double check the status. Tried setting this the control
   // inactive to start with, but that didn't seem to work.
   MasterJoinServer.SetActive(MasterServerList.rowCount() > 0);
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
   ServerQueryStatus.SetVisible(false);
   ServerServerList.Clear();
   %sc = getServerCount();
   for (%i = 0; %i < %sc; %i++) {
      setServerInfo(%i);
      ServerServerList.AddRow(%i,
         ($ServerInfo::Password? "Yes": "No") TAB
         $ServerInfo::Name TAB
         $ServerInfo::Ping TAB
         $ServerInfo::PlayerCount @ "/" @ $ServerInfo::MaxPlayers TAB
         $ServerInfo::Version TAB
         $ServerInfo::GameType TAB
         %i);  // ServerInfo index stored also
   }
   ServerServerList.Sort(0);
   ServerServerList.SetSelectedRow(0);
   ServerServerList.scrollVisible(0);

   ServerJoinServer.SetActive(ServerServerList.rowCount() > 0);
}

//----------------------------------------
function onServerQueryStatus(%status, %msg, %value)
{
   // Update query status
   // States: start, update, ping, query, done
   // value = % (0-1) done for ping and query states
   if (!ServerQueryStatus.IsVisible())
      ServerQueryStatus.SetVisible(true);

   switch$ (%status) {
      case "start":
         ServerJoinServer.SetActive(false);
         ServerQueryServer.SetActive(false);
         ServerStatusText.SetText(%msg);
         ServerStatusBar.SetValue(0);
         ServerServerList.Clear();

      case "ping":
         ServerStatusText.SetText("Ping Servers");
         ServerStatusBar.SetValue(%value);

      case "query":
         ServerStatusText.SetText("Query Servers");
         ServerStatusBar.SetValue(%value);

      case "done":
         ServerQueryServer.SetActive(true);
         ServerQueryStatus.SetVisible(false);
         ServerScreen.update();
   }
}
