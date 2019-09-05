using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicPlayer : MonoBehaviour
{
    //Awake() executes before Start() 
    //To keep music playing after loading scene 1 from splash screen.
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); //Built-in function to keep the gameObject from destroying.
    }
    // Start is called before the first frame update
    void Start()
    {
        //Load level 1 after 2 sec from splash screen.
        Invoke("LoadFirstScreen", 2f);
    }

    //To load scene 1
    void LoadFirstScreen()
    {
        SceneManager.LoadScene(1);
    }
}
