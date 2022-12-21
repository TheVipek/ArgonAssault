using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;
    private void Start() {
        scoreText = GetComponent<TMP_Text>();
    }
    
    public void IncreaseScore(int amountIncrease)
    {
        score+=amountIncrease;
        DisplayScore();
    }
    void DisplayScore(){
        scoreText.text = score.ToString();
        Debug.Log("Your current score is: "+score);
    }
}
