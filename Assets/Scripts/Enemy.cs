using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //any gameobject with this script will generate a box collider with it
        AddNonTriggerBoxCollider();   
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false; //for nontrigger box collider.
    }

    //destroy game object (enemy) when hitted by laser bullets
    void OnParticleCollision(GameObject other)
    {
        //print("Particles collided with enemy" + gameObject.name);
        Destroy(gameObject);
    }
}
