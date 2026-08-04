using UnityEngine;
using System.Collections.Generic;
using System.IO;

//https://www.youtube.com/watch?v=W85lx7QO6_8
//https://docs.unity3d.com/ScriptReference/JsonUtility.html
public class AccountLoader : MonoBehaviour
{
    public List<BaseAccountData> accounts = new List<BaseAccountData>();

    void Awake()
    {
        try
        {
            LoadAccounts();
        }
        catch (System.Exception e)
        {
            Debug.LogError("AccountLoader failed: " + e.Message);
        }
    }

    public void LoadAccounts()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "accounts.json");
        Debug.Log("Looking for file at: " + path); // Add this to see what path it's actually checking

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            accounts = new List<BaseAccountData>(JsonUtility.FromJson<AccountListWrapper>(json).Account);
            Debug.Log("File found, accounts loaded: " + accounts.Count);
        }
        else
        {
            Debug.Log("File NOT found, creating empty list");
            accounts = new List<BaseAccountData>();
            SaveAccounts();
        }

        /*string path = Path.Combine(Application.streamingAssetsPath, "accounts.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            accounts = new List<BaseAccountData>(JsonUtility.FromJson<AccountListWrapper>(json).Account);
        }
        else
        {
            accounts = new List<BaseAccountData>(); // No file yet, start fresh
        }*/
    }

    public void SaveAccounts()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "accounts.json");
        AccountListWrapper wrapper = new AccountListWrapper();
        wrapper.Account = accounts.ToArray();
        string json = JsonUtility.ToJson(wrapper, true); // true = pretty print
        File.WriteAllText(path, json);
    }
}

