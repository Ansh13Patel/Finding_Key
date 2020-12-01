using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels_Manager : MonoBehaviour
{
    public Button[] Buttons;
    [HideInInspector]
    public static Levels_Manager LM;
    [HideInInspector]
    public int levelunlocked = 1;

    private bool _checknow = true;
    private bool _loaddata = true;

    private void Awake()
    {
        LM = this;
        SaveProgress.saveplayedata(Player.player);
    }
    private void Start()
    {
        SaveProgress.loadplayerdata();
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].interactable = false;
        }

        for (int i = 0 ; i < levelunlocked ; i++)
        {
            Buttons[i].interactable = true;
        }
    }

    private void Update()
    {
        if (levelunlocked > 1)
        {
            if (_checknow)
            {
                StartCoroutine(checkforunlocklevel());
            }
        }
        if(_loaddata)
        {
            StartCoroutine(loadinformation());
        }
    }


    IEnumerator checkforunlocklevel()
    {
        _checknow = false;
        yield return new WaitForSeconds(2);
        if (Player.player.levelsUnlocked > levelunlocked)
        {
            levelunlocked++;
            for (int i = levelunlocked; i < Player.player.levelsUnlocked; i++)
            {
                Buttons[i].interactable = true;
            }
        }
        _checknow = true;
    }

    IEnumerator loadinformation()
    {
        _loaddata = false;
        yield return new WaitForSeconds(3);
        SaveProgress.loadplayerdata();
        _loaddata = true;
    }
   
   
}
