using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryedPlatforms : MonoBehaviour
{
    private Transform player;
    public ParticleSystem DestroyThePlatform;
    public Renderer Sector;
    
    

    private void Start()
    {
        Sector.GetComponent<Renderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        Explosion();
    }

    public void Explosion()
    {
        if (transform.position.y > player.transform.position.y)
        {
            DestroyThePlatform.Play();
            Sector.enabled = false;
            Destroy(gameObject, 1.2f);
        }
    }

}
