using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public Text scoreText;
    public string nextToLoad;
    public int playerLives;
    public int keyToBeCollected;
    public int timeToCompleteLevel;
    public GameObject Player;
    public GameObject pauseCanvas;
    public GameObject intialCheckPoint;
    public Text livesRemaining;
    public Text keyLeftText;
    public GameObject gameWinText;
    public GameObject gameLoseText;
    public Text timeLeft;
    public AudioClip coinCollectSFX;
    public AudioClip enemyAttackSFX;
    public AudioClip gameWinSFX;
    public AudioClip keyCollectSFX;
    public AudioClip gameLoseSFX;
    public GameObject nextLevelButton;
    public GameObject mainMenuButton;

    [HideInInspector]
    public int livesleft = 3;
    bool takeaway = false;
    int time = 0;
    private int keyleft = 0;
    int Score = 0;
    AudioSource _audio;

    private void Start()
    {
        Instance = this;
        _audio = gameObject.AddComponent<AudioSource>();
        time = timeToCompleteLevel;
        livesleft = playerLives;
    }

    private void Update()
    {
        if ( takeaway==false && time > 0)
        {
            StartCoroutine(timeremaining());
        }
    }
    public void Coin_Collect()
    {
        Score += 1;
        scoreText.text = "X " + Score.ToString();
        _audio.PlayOneShot(coinCollectSFX);
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
            Player.transform.position = intialCheckPoint.transform.position;
            livesleft -= 1;
            livesRemaining.text = "X " + livesleft.ToString();
            _audio.PlayOneShot(enemyAttackSFX);
        }
        if(livesleft <= 0)
        {
            Player.GetComponent<Animator>().SetBool("Death", true);
            _audio.PlayOneShot(gameLoseSFX);
            gameLoseText.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Key()
    {
        if (keyleft != keyToBeCollected)
        {
            keyleft += 1;
            keyLeftText.text = "X " + keyleft.ToString();
            _audio.PlayOneShot(keyCollectSFX);
        }
        if (keyleft == keyToBeCollected)
        {
            Player.GetComponent<Animator>().SetBool("Win", true);
            Time.timeScale = 0f;
            gameWinText.SetActive(true);
            _audio.PlayOneShot(gameWinSFX);
            nextLevelButton.SetActive(true);
            mainMenuButton.SetActive(true);
        }

    }

    IEnumerator timeremaining()
    {
       takeaway = true;
       yield return new WaitForSeconds(1f);
        time -= 1;
        if (time < 10)
        {
            timeLeft.text = "0" + time.ToString() + "s";
        }
        else
        {
            timeLeft.text = time.ToString() + "s";
        }
        if (time <= 0)
        {
            _audio.PlayOneShot(gameLoseSFX);
            gameLoseText.SetActive(true);
            Time.timeScale = 0f;
        }
        takeaway = false;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextToLoad);
    }
}
