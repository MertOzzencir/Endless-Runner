using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI speedText;
    PlayerMovement playerSpeed;
    private void Awake()
    {
        inst = this;
    }
    private void Start()
    {
        playerSpeed = FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerSpeed != null)
        {
            scoreText.text = "SCORE: " + score.ToString();
            speedText.text = "SPEED: " + (Mathf.CeilToInt(playerSpeed.speed)).ToString();
        }
       
        if (score >= 1000)
        {
           StartCoroutine( GameOver());


        }

    }

    IEnumerator GameOver()
    {
        speedText.text = "GAMEOVER";
        Destroy(playerSpeed.gameObject);
        Destroy(gameObject);
        yield return null;

    }
}
