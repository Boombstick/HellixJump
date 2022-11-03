using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;

public class PlatformBreak : MonoBehaviour
{
    private Transform player;
    public float Radius;
    public float Force;
    public Rigidbody Rigidbody;
    public ParticleSystem ParticleSystem;

    private void Start()
    {
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
            Rigidbody.isKinematic = false;
            Rigidbody.useGravity = true;

            Collider[] colliders = Physics.OverlapSphere(transform.position, Radius);

            foreach (Collider collider in colliders)
            {
                Rigidbody.AddExplosionForce(Force, transform.position, Radius);
            }
            
            Destroy(gameObject, 1f);

        }
    }
}
