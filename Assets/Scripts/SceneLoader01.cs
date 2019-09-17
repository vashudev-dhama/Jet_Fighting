using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadSecondScreen", 30f); //for future level addition
    }

    //To load next scene in future
    void LoadSecondScreen()
    {
        Application.Quit();//for now quit the application
    }

}
