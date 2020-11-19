using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public Text scoreText;
    public string levelToBeReload;
    public GameObject Player;
    public GameObject pauseCanvas;
    public GameObject checkPoint;
    [HideInInspector]
    public Text livesRemaining;
    public Text keyLeftText;
    public GameObject gameWinText;

   [HideInInspector]
    public int livesleft = 3;
    private int keyleft = 0;
    int Score = 0;

    private void Start()
    {
        Instance = this;
    }
    public void Coin_Collect()
    {
        Score += 1;
        scoreText.text = "X " + Score.ToString();
    }
    public void mainPausemenu()
    {
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
    }

    public void backtohome()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void death()
    {
        if (livesleft > 0)
        {
            Player.transform.position = checkPoint.transform.position;
            livesleft -= 1;
        }
        else
        {
            Player.GetComponent<Animator>().SetBool("Death", true);
            Time.timeScale = 0f;
            SceneManager.LoadScene(levelToBeReload);
        }
    }

    public void Key()
    {
        if (keyleft != 3)
        {
            keyleft += 1;
            keyLeftText.text = "X" + keyleft.ToString();
        }
        if (keyleft == 3)
        {
            Player.GetComponent<Animator>().SetBool("Win", true);
            Time.timeScale = 0f;
            gameWinText.SetActive(true);
        }

    }
}
