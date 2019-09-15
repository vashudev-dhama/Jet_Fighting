using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //Awake() executes before Start() 
    //To keep music playing after loading scene 1 from splash screen.
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); //Built-in function to keep the gameObject from destroying.
    }
    
}
