//-----------------------------------------------------------------------------
// Projectile trail emitter
datablock ParticleData(TommyGunSmokeParticle)
{
   textureName          = "~/data/particles/smoke";

   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.2;  // rises
   inheritedVelFactor   = 0.00;

   lifetimeMS           = 300;   // time in ms
   lifetimeVarianceMS   = 150;   // ...more or less

   useInvAlpha = false;
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;

   colors[0]     = "0 0.2 1 1.0";
   colors[1]     = "0 0.2 1 1.0";
   colors[2]     = "0 0 0 0";

   sizes[0]      = 0.25;
   sizes[1]      = 0.4;
   sizes[2]      = 0.6;

   times[0]      = 0.0;
   times[1]      = 0.3;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(TommyGunSmokeEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 5;

   ejectionVelocity = 0.25;
   velocityVariance = 0.10;

   thetaMin         = 0.0;
   thetaMax         = 90.0;

   particles = TommyGunsmoke;
};


//-----------------------------------------------------------------------------
// Weapon fire emitter

datablock ParticleData(TommyGunFireParticle)
{
   textureName          = "~/data/particles/smoke";

   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.1;  // rises
   inheritedVelFactor   = 0.3;

   lifetimeMS           = 200;   // Time in ms
   lifetimeVarianceMS   = 50;    // ...more or less

   useInvAlpha = false;
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;

   colors[0]     = "1 0.6 1 1.0";
   colors[1]     = "1 1 1 1.0";
   colors[2]     = "1 0 0 0";

   sizes[0]      = 0.1;
   sizes[1]      = 0.4;
   sizes[2]      = 0.6;

   times[0]      = 0.0;
   times[1]      = 0.3;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(TommyGunFireEmitter)
{
   ejectionPeriodMS = 30;
   periodVarianceMS = 5;

   ejectionVelocity = 2;
   ejectionOffset   = 0.1;
   velocityVariance = 0.10;

   thetaMin         = 0.0;
   thetaMax         = 10.0;

   particles = TommyGunFireParticle;
};


//-----------------------------------------------------------------------------
// Projectile Explosion

datablock ParticleData(TommyGunExplosionParticle)
{
   dragCoefficient      = 2;
   gravityCoefficient   = 0.2;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 250;
   lifetimeVarianceMS   = 50;
   textureName          = "~/data/particles/smoke";
   colors[0]     = "0.2 0.2 0.2 1.0";
   colors[1]     = "0.2 0.2 0.2 0.0";
   sizes[0]      = 0.1;
   sizes[1]      = 0.05;
};

datablock ParticleEmitterData(TommyGunExplosionEmitter)
{
   ejectionPeriodMS = 7;
   periodVarianceMS = 0;
   ejectionVelocity = 1;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 60;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "TommyGunExplosionParticle";
};

datablock ExplosionData(TommyGunExplosion)
{
   //explosionShape = "~/data/shapes/weapons/TommyGun/explosion.dts";

   particleEmitter = TommyGunExplosionEmitter;
   particleDensity = 10;
   particleRadius = 0.1;

   faceViewer     = true;
   explosionScale = ".2 .2 .2";

   shakeCamera = false;
   camShakeFreq = "10.0 11.0 10.0";
   camShakeAmp = "1.0 1.0 1.0";
   camShakeDuration = 0.5;
   camShakeRadius = 10.0;
};


//-----------------------------------------------------------------------------
// Projectile Object

datablock ProjectileData(TommyGunProjectile)
{
   projectileShapeName = "~/data/shapes/weapons/TommyGun/projectile.dts";
   directDamage        = 15;
   radiusDamage        = 5;
   damageRadius        = 0.7;
   explosion           = TommyGunExplosion;
  // particleEmitter     = TommyGunSmokeEmitter;

   muzzleVelocity      = 700;
   velInheritFactor    = 1;

   armingDelay         = 0;
   lifetime            = 2500;
   fadeDelay           = 1500;
   bounceElasticity    = 0;
   bounceFriction      = 0;
   isBallistic         = true;
   gravityMod = 0.10;

   hasLight    = true;
   lightRadius = 6.0;
   lightColor  = "0.2 0.2 0.2";
};

function TommyGunProjectile::onCollision(%this,%obj,%col,%fade,%pos,%normal)
{
   // Apply damage to the object all shape base objects
   if (%col.getType() & $TypeMasks::ShapeBaseObjectType)
      %col.damage(%obj,%pos,%this.directDamage,"TommyGunBullet");

   // Radius damage is a support scripts defined in radiusDamage.cs
   radiusDamage(%obj,%pos,%this.damageRadius,%this.radiusDamage,"TommyGunBullet",0);
}


//-----------------------------------------------------------------------------
// Ammo Item

datablock ItemData(TommyGunAmmo)
{
   // Mission editor category
   category = "Ammo";

   // Add the Ammo namespace as a parent.  The ammo namespace provides
   // common ammo related functions and hooks into the inventory system.
   className = "Ammo";

   // Basic Item properties
   shapeFile = "~/data/shapes/weapons/TommyGun/ammo.dts";
   mass = 0.5;
   elasticity = 0.2;
   friction = 0.4;

	// Dynamic properties defined by the scripts
	pickUpName = ".45 Cal ammo";
   maxInventory = 30;
};


//--------------------------------------------------------------------------
// TommyGun shell that's ejected during reload.

datablock DebrisData(TommyGunShell)
{
   shapeFile = "~/data/shapes/weapons/TommyGun/shell.dts";
   lifetime = 3.0;
   minSpinSpeed = 300.0;
   maxSpinSpeed = 400.0;
   elasticity = 0.5;
   friction = 0.2;
   numBounces = 4;
   staticOnMaxBounce = true;
   snapOnMaxBounce = false;
   fade = true;
};


//--------------------------------------------------------------------------
// Weapon Item.  This is the item that exists in the world, i.e. when it's
// been dropped, thrown or is acting as re-spawnable item.  When the weapon
// is mounted onto a shape, the TommyGunImage is used.

datablock ItemData(TommyGun)
{
   // Mission editor category
   category = "Weapon";

   // Hook into Item Weapon class hierarchy. The weapon namespace
   // provides common weapon handling functions in addition to hooks
   // into the inventory system.
   className = "Weapon";

   // Basic Item properties
   shapeFile = "~/data/shapes/weapons/TommyGun/TommyGun.dts";
   mass = 1.5;
   elasticity = 0.1;
   friction = 0.9;
   emap = true;

	// Dynamic properties defined by the scripts
	pickUpName = "a sub-machinegun";
	image = TommyGunImage;
};


//-----------------------------------------------------------------------------

function TommyGunImage::onFire(%this, %obj, %slot)
{
   %projectile = %this.projectile;

   // Decrement inventory ammo. The image's ammo state is update
   // automatically by the ammo inventory hooks.
   %obj.decInventory(%this.ammo,1);

   // Determin initial projectile velocity based on the
   // gun's muzzle point and the object's current velocity
   %muzzleVelocity = %obj.getMuzzleVector(%slot);
   %objectVelocity = %obj.getVelocity();
   %velocity = VectorAdd(
      VectorScale(%muzzleVelocity, %projectile.muzzleVelocity),
      VectorScale(%objectVelocity, %projectile.velInheritFactor));

   // Create the projectile object
   %p = new (%this.projectileType)() {
      dataBlock        = %projectile;
      initialVelocity  = %velocity;
      initialPosition  = %obj.getMuzzlePoint(%slot);
      sourceObject     = %obj;
      sourceSlot       = %slot;
      client           = %obj.client;
   };
   MissionCleanup.add(%p);
   return %p;
}

