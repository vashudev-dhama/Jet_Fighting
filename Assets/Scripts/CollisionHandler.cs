using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;
    //test
    //void OnCollisionEnter(Collision collision)
    //{
    //    print("Player collide something");
    //}

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath"); //Used to communicate with other methods
        
    }

    private void ReloadScene() //string referenced by Invoke
    {
        SceneManager.LoadScene(1);
    }
}
