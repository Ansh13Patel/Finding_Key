using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource Audio;

    private void Start()
    {
        Audio.volume = 0.3f;
    }

    public void Volume(float volume)
    {
        Audio.volume = volume;
    }

    public void Quality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Level_1");
    }
}
