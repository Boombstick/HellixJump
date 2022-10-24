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


    

    public void Bounce()
    {

        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);

    }

    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
        Rigidbody.velocity = Vector3.zero;

    }

    public void Die()
    {
        Game.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Platform")
        {
            PlatformScore++;
        }
    }

}
 

