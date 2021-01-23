using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject Asteroid;
    public Vector3 randomPos;
    public float startWait;
    public float creationWait;
    public float loopWait;
    public Text text;
    public Text gameOverText;
    public Text restartText;
    bool gameOverControl=false;
    bool restart=false;
    int score;

    void Start()
    {
        score = 0;
        text.text = "Score = " + score;
        StartCoroutine(create());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && restart)
        {
            SceneManager.LoadScene("Level1");
        }
    }

    IEnumerator create()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                if (!gameOverControl)
                {
                    Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                    Instantiate(Asteroid, vec, Quaternion.identity);
                    yield return new WaitForSeconds(creationWait);
                }
                else
                    restart = true;
            }

            if (gameOverControl == true)
            {
                restartText.text = "YENİDEN BAŞLAMAK İÇİN  'r' TUŞUNA BASINIZ.";
            }

            yield return new WaitForSeconds(loopWait); 
        }
    }

    public void Score(int score)
    {
        this.score = this.score + score;
        text.text = "Score = " + this.score;
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER";
        gameOverControl = true;
    }
   
}
