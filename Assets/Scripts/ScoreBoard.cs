using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();//get the Text component
        scoreText.text = score.ToString(); //update the text of the component
    }

    public void ScoreHit(int scoreIncrease)
    {
        score += scoreIncrease;
        scoreText.text = score.ToString(); //update text component

    }
}
