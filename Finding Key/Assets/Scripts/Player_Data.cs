using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player_Data 
{
    public int levelsunlocked = 1;

    
    public Player_Data(Player player)
    {
        levelsunlocked = player.levelsUnlocked;
        Levels_Manager.LM.levelunlocked = levelsunlocked;
    }

}
