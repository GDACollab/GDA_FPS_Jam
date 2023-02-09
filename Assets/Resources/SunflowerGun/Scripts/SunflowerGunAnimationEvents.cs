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
    public AudioClip ShroudRotate;
    public AudioClip ShroudRotateShort;
    [Space(15)]
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
        PlayFireSteamSound(1f);
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
    public void PlayShroudRotateSound(float volume)
    {
        animator.PlayAudio(ShroudRotate, volume);
    }
    public void PlayShroudRotateShortSound(float volume)
    {
        animator.PlayAudio(ShroudRotateShort, volume);
    }


    public void PlayDrawRustleSound(float volume)
    {
        animator.PlayAudio(DrawRustle, volume);
    }
    public void PlayDrawBoltSound(float volume)
    {
        animator.PlayAudio(DrawBolt, volume);
    }
    public void PlayDrawSightsSound(float volume)
    {
        animator.PlayAudio(DrawSights, volume);
    }


    public void PlayADSOnSound(float volume)
    {
        animator.PlayAudio(ADS_On, volume);
    }
    public void PlayADSOffSound(float volume)
    {
        animator.PlayAudio(ADS_Off, volume);
    }


    public void PlayFireMainSound(float volume)
    {
        animator.PlayAudio(FireMain, volume);
    }
    public void PlayFireSteamSound(float volume)
    {
        animator.PlayAudio(FireSteam, volume);
    }

    
    public void PlayReloadOpenSound(float volume)
    {
        animator.PlayAudio(ReloadOpen, volume);
    }
    public void PlayReloadOpenEjectMagSound(float volume)
    {
        animator.PlayAudio(ReloadOpenEjectMag, volume); // this needs to be played at a much lower volume than normal
    }
    public void PlayReloadOpenCaseHitGroundSound(float volume)
    {
        animator.PlayAudio(ReloadOpenCaseHitGround, volume);
    }


    public void PlayReloadGrabMagSound(float volume)
    {
        animator.PlayAudio(ReloadGrabMag, volume);
    }
    public void PlayReloadInsertMagSound(float volume)
    {
        animator.PlayAudio(ReloadInsertMag, volume);
    }
    public void PlayReloadInsertProjectileSound(float volume)
    {
        animator.PlayAudio(ReloadInsertProjectile, volume);
    }


    public void PlayReloadLockMechanismSound(float volume)
    {
        animator.PlayAudio(ReloadLockMechanism, volume);
    }
    public void PlayReloadLockRustleSound(float volume)
    {
        animator.PlayAudio(ReloadLockRustle, volume);
    }


    public void PlayReloadBoltFirstSound(float volume)
    {
        animator.PlayAudio(ReloadBoltFirst, volume);
    }
    public void PlayReloadBoltSecondSound(float volume)
    {
        animator.PlayAudio(ReloadBoltSecond, volume);
    }


    public void PlayReloadEndSound(float volume)
    {
        animator.PlayAudio(ReloadEnd, volume);
    }
#endregion
}
