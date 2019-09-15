using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
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
