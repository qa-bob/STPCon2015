//------------------------------------------------------------------------
// control/player.cs
//
// player definition module for 3DGPAI1 emaga4 tutorial game
//
// Copyright (c) 2003 by Kenneth C. Finney.
//------------------------------------------------------------------------
datablock PlayerData(HumanMaleAvatar)
{
	className = Avatar;
	shapeFile = "~/player.dts";
	emap = true;
	renderFirstPerson = false;
	cameraMaxDist = 4;
	mass = 100;
	density = 10;
	drag = 0.1;
	maxdrag = 0.5;
	maxEnergy = 100;
	maxDamage = 100;
	maxForwardSpeed = 15;
	maxBackwardSpeed = 10;
	maxSideSpeed = 12;
	minJumpSpeed = 20;
	maxJumpSpeed = 30;
	runForce = 4000;
	jumpForce = 1000;
	runSurfaceAngle = 70;
	jumpSurfaceAngle = 80;
};
//----------------------------------------------------------------------------
// Avatar Datablock methods
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
function Avatar::onAdd(%this,%obj)
{
}
function Avatar::onRemove(%this, %obj)
{
	if (%obj.client.player == %obj)
		%obj.client.player = 0;
}