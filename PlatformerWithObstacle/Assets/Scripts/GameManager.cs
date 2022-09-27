using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject obstacle;
    public Transform spawnPoint;
    int score = 0;


    public TextMeshProUGUI scoreText;
    public GameObject PlayButton;
    public GameObject Player;

    public TextMeshProUGUI highscore;
    
    // Start is called before the first frame update
    void Start()
    {
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnObstacles()
    {
        while (true)
        {

            float waitTime = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(waitTime);
            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
        if(score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highscore.text = score.ToString();
        }
    } 
    public void GameStart()
    {
        Player.SetActive(true);
        PlayButton.SetActive(false);
        StartCoroutine("SpawnObstacles");
        InvokeRepeating("ScoreUp", 2f, 1f);
    }
}
