﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScreen", 2f);

    }

    void LoadFirstScreen()
    {
        SceneManager.LoadScene(1);
    }
}
