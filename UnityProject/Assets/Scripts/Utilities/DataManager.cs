using System;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    private string saveFilePath;

    private string fileName;
    private LocalData localData;
    private ServerData serverData;

    public void SetLocalData(string filename, string data)
    {
        fileName = filename;
        saveFilePath = Application.persistentDataPath + "/" + fileName + ".json";
        File.WriteAllText(saveFilePath, data);
    }

    public LocalData GetLocalData(string filename)
    {
        fileName = filename;
        saveFilePath = Application.persistentDataPath + "/" + fileName + ".json";
        if (File.Exists(saveFilePath))
        {
            string jsonString = File.ReadAllText(saveFilePath);
            localData = JsonUtility.FromJson<LocalData>(jsonString);
            return localData;
        }else
        {
            return null;
        }
    }

    public void SetGlobalData(string collectionName, string field)
    {
        //TODO link firebase functionality to push data to firestore using any variables that can be
        //received through the arguments
    }

    public ServerData GetServerData(string collectionName, string field)
    {
        //TODO firebase functionality to fetch server data and return the fetched data.. the data to be received
        // are sent as arguments
        return serverData;
    }
}

[Serializable]
public class LocalData
{
    public string salesCode;
}

[Serializable]
public class ServerData
{

}