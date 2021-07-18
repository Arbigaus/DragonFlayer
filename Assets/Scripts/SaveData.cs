using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SaveData : MonoBehaviour
{
    public int currentScore = 0;

    private void Start()
    {
        CreateFile();
    }

    private void CreateFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        

        if (!File.Exists(destination))
        {
            FileStream file;
            file = File.Create(destination);
            GameData data = new GameData(currentScore);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, data);
            file.Close();
        }

    }
    
    public void SaveFile(int score)
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;
 
        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);
 
        GameData data = new GameData(score);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;
 
        if(File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }
 
        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData) bf.Deserialize(file);
        file.Close();
 
        currentScore = data.score;
 
        Debug.Log(data.score);
    }
}

[System.Serializable]
public class GameData
{
    public int score;
 
    public GameData(int scoreInt)
    {
        score = scoreInt;
    }
}