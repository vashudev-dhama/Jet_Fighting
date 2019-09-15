using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //Awake() executes before Start() 
    //To keep music playing after loading scene 1 from splash screen.
    private void Awake()
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        //if more than one music player in scene then only distroy ourselves
        if(numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject); //Built-in function to keep the gameObject from destroying.
        }

    }
    
}
