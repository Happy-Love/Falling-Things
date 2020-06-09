using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour 
{
    public int coins;
    [Multiline(20)]
    public string data;
    public void CollectInfo(Character currentCharacter)
    {
        coins = currentCharacter.coins;
    }
    public void SetInfo()
    {
        Character currentCharacter = GetComponent<Character>();
        currentCharacter.coins=coins;
    }

    public void Save()
    {
        CollectInfo(GetComponent<Character>());
        data = JsonUtility.ToJson(this,true);
        System.IO.File.WriteAllText(Application.persistentDataPath+"/info.txt", data);

    }
    public void Load()
    {
        data = System.IO.File.ReadAllText(Application.persistentDataPath+"/info.txt");
        JsonUtility.FromJsonOverwrite(data, this);
        SetInfo();

    }















    //public class SaveManager<T>
    //{
    //    public void SaveToJsonCharacter(T data)
    //    {
    //        string jsonCharacter = JsonUtility.ToJson(data);
    //        System.IO.File.WriteAllText(Application.persistentDataPath + "/CharacterData.json", jsonCharacter);
    //    }
    //    public void LoadFromJsonCharacter(T data)
    //    {
    //        string recieveJsonData = System.IO.File.ReadAllText(Application.persistentDataPath + "/CharacterData.json");
    //        JsonUtility.FromJsonOverwrite(recieveJsonData, data);
    //    }

    //}
}
