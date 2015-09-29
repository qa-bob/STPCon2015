

//----------------------------------------
function StartHost()
{
   %id = HostMissionList.getSelectedId();
   %mission = getField(HostMissionList.getRowTextById(%id), 1);

   StopMusic(AudioIntroMusicProfile);
   createServer("MultiPlayer", %mission);
   %conn = new GameConnection(ServerConnection);
   RootGroup.add(ServerConnection);
   %conn.setConnectArgs($pref::Player::Name);
   %conn.setJoinPassword($Client::Password);
   %conn.connectLocal();
}


//----------------------------------------
function HostScreen::onWake()
{
   HostMissionList.clear();
   %i = 0;
   for(%file = findFirstFile($Server::MissionFileSpec);
         %file !$= ""; %file = findNextFile($Server::MissionFileSpec))
      if (strStr(%file, "CVS/") == -1 && strStr(%file, "common/") == -1)
         HostMissionList.addRow(%i++, getMissionDisplayName(%file) @ "\t" @ %file );
   HostMissionList.sort(0);
   HostMissionList.setSelectedRow(0);
   HostMissionList.scrollVisible(0);
}


//----------------------------------------
function getMissionDisplayName( %missionFile )
{
   %file = new FileObject();

   %MissionInfoObject = "";

   if ( %file.openForRead( %missionFile ) ) {
		%inInfoBlock = false;

		while ( !%file.isEOF() ) {
			%line = %file.readLine();
			%line = trim( %line );

			if( %line $= "new ScriptObject(MissionInfo) {" )
				%inInfoBlock = true;
			else if( %inInfoBlock && %line $= "};" ) {
				%inInfoBlock = false;
				%MissionInfoObject = %MissionInfoObject @ %line;
				break;
			}

			if( %inInfoBlock )
			   %MissionInfoObject = %MissionInfoObject @ %line @ " ";
		}

		%file.close();
	}
	%MissionInfoObject = "%MissionInfoObject = " @ %MissionInfoObject;
	eval( %MissionInfoObject );

   %file.delete();

   if( %MissionInfoObject.name !$= "" )
      return %MissionInfoObject.name;
   else
      return fileBase(%missionFile);
}

