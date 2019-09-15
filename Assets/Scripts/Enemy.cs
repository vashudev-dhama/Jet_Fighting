using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        //any gameobject with this script will generate a box collider with it
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>(); //find reference to the score board
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false; //for nontrigger box collider.
    }

    //destroy game object (enemy) when hitted by laser bullets
    void OnParticleCollision(GameObject other)
    {
        //Instantiate(prefabToUse, worldSpacePosition, Quanternion.identity) for runtime instantiation of enemy's explosion
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent; //set fx's local position parent
        //print("Particles collided with enemy" + gameObject.name);
        Destroy(gameObject);
        scoreBoard.ScoreHit(scorePerHit);
    }
}
