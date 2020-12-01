using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveProgress 
{
   public static void saveplayedata(Player player)
    {
        BinaryFormatter formattor = new BinaryFormatter();
        string path = Application.persistentDataPath + "/PlayerData.binary";
        FileStream stream = new FileStream(path, FileMode.Create);

        Player_Data data = new Player_Data(player);
        formattor.Serialize(stream, data);
        stream.Close();
    } 

    public static Player_Data loadplayerdata()
    {
        string path = Application.persistentDataPath + "/PlayerData.binary";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Player_Data data = formatter.Deserialize(stream) as Player_Data;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File does not find at " + path);
            return null;
        }
    }

    public static void setlevelunlock(int resetlevel)
    {
        
    }

}
