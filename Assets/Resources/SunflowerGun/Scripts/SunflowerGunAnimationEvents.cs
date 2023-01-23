using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerGunAnimationEvents : MonoBehaviour
{
    [Header("Animator")]
    public SunflowerGunAnimator animator;


    [Header("Particle Emitter References")]
    public ParticleSystem BarrelSteam;
    public ParticleSystem ReloadEjectionSteam;
    public ParticleSystem MuzzleFlash;


    [Header("Audio References")]
    public AudioClip DrawRustle;
    public AudioClip DrawBolt;
    public AudioClip DrawSights;
    [Space(15)]
    public AudioClip ADS_On;
    public AudioClip ADS_Off;
    [Space(15)]
    public AudioClip FireMain;
    public AudioClip FireSteam;
    [Space(15)]
    public AudioClip ReloadOpen;
    public AudioClip ReloadOpenEjectMag;
    public AudioClip ReloadOpenCaseHitGround;
    [Space(15)]
    public AudioClip ReloadGrabMag; // grabbing the mag from player's body
    public AudioClip ReloadInsertMag;
    public AudioClip ReloadInsertProjectile;
    [Space(15)]
    public AudioClip ReloadLockMechanism;
    public AudioClip ReloadLockRustle; // for when the player moves their hand to cock the bolt
    [Space(15)]
    public AudioClip ReloadBoltFirst;
    public AudioClip ReloadBoltSecond;
    public AudioClip ReloadEnd; // for settling into idle hold (i.e left hand settles on gun grip)


    public void ShootingDone()
    {
        animator.ShootingDone();
    }

#region Particle Emitter Functions
    public void PlayBarrelSteamEmitter()
    {
        animator.PlayParticleEmitter(BarrelSteam);
        PlayFireSteamSound();
    }

    public void PlayReloadEjectionSteamEmitter()
    {
        animator.PlayParticleEmitter(ReloadEjectionSteam);
    }

    public void PlayMuzzleFlashEmitter()
    {
        animator.PlayParticleEmitter(MuzzleFlash);
    }
#endregion


#region Sound Functions
    public void PlayDrawRustleSound()
    {
        animator.PlayAudio(DrawRustle);
    }
    public void PlayDrawBoltSound()
    {
        animator.PlayAudio(DrawBolt);
    }
    public void PlayDrawSightsSound()
    {
        animator.PlayAudio(DrawSights);
    }


    public void PlayADSOnSound()
    {
        animator.PlayAudio(ADS_On);
    }
    public void PlayADSOffSound()
    {
        animator.PlayAudio(ADS_Off);
    }


    public void PlayFireMainSound()
    {
        animator.PlayAudio(FireMain);
    }
    public void PlayFireSteamSound()
    {
        animator.PlayAudio(FireSteam);
    }

    
    public void PlayReloadOpenSound()
    {
        animator.PlayAudio(ReloadOpen);
    }
    public void PlayReloadOpenEjectMagSound()
    {
        animator.PlayAudio(ReloadOpenEjectMag); // this needs to be played at a much lower volume than normal
    }
    public void PlayReloadOpenCaseHitGroundSound()
    {
        animator.PlayAudio(ReloadOpenCaseHitGround);
    }


    public void PlayReloadGrabMagSound()
    {
        animator.PlayAudio(ReloadGrabMag);
    }
    public void PlayReloadInsertMagSound()
    {
        animator.PlayAudio(ReloadInsertMag);
    }
    public void PlayReloadInsertProjectileSound()
    {
        animator.PlayAudio(ReloadInsertProjectile);
    }


    public void PlayReloadLockMechanismSound()
    {
        animator.PlayAudio(ReloadLockMechanism);
    }
    public void PlayReloadLockRustleSound()
    {
        animator.PlayAudio(ReloadLockRustle);
    }


    public void PlayReloadBoltFirstSound()
    {
        animator.PlayAudio(ReloadBoltFirst);
    }
    public void PlayReloadBoltSecondSound()
    {
        animator.PlayAudio(ReloadBoltSecond);
    }


    public void PlayReloadEndSound()
    {
        animator.PlayAudio(ReloadEnd);
    }
#endregion
}
