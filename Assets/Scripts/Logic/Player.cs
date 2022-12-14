using Assets.Scripts;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Game Game;
    public Platform CurrentPlatform;
    public Platform platform;
    public int PlatformScore = 0;
    public AudioManager AudioManager;
    public ParticleSystem ParticleSystemOfWin;
    public ParticleSystem ParticleSystemOfLose;


    public void Bounce()
    {

        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
        AudioManager.PlayerBounceSound();

    }

    public void ReachFinish()
    {
        ParticleSystemOfWin.Play();
        Game.OnPlayerReachedFinish();
        Rigidbody.velocity = Vector3.zero;

    }

    public void Die()
    {
        ParticleSystemOfLose.Play();
        Game.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
        {

            PlatformScore++;
            AudioManager.PlatformBreak();
        }

    }
  
}
 

