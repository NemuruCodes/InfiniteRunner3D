using UnityEngine;
using System.Collections.Generic;

public class AccountManager : MonoBehaviour
{
    // New way makes way more  sense to be singleton istead of useing a object  that does not get  destroyedd across scense
    public static AccountManager Instance { get; private set; } 

    private AccountLoader loader;
    public BaseAccountData currentAccount { get; private set; }
    public MainMenu ui;           
    public GameObject accountUI;

    public string playerName { get; private set; }
    public string highScore { get; private set; }
    public string overallScore { get; private set; }
    public string bossesBeaten { get; private set; }


    void Awake() // Checking for if it exists
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        loader = GetComponent<AccountLoader>();
        //if (accountUI != null) accountUI.SetActive(false);
    }

    public  LoginResult Login(string enteredName)
    {
        // Check if account exists
        BaseAccountData found = loader.accounts.Find(a => a.name == enteredName);
        LoginResult result;

        if (found != null)
        {
            // Account exists — load it
            currentAccount = found;
            result = LoginResult.LoggedIn;
            //Debug.Log($"Welcome back, {currentAccount.name}! Points: {currentAccount.points}");
        }
        else
        {
            //Creating a new account when no account found
            BaseAccountData newAccount = new BaseAccountData
            {
                //id = (loader.accounts.Count + 1).ToString(),
                name = enteredName,
                highScore = "0",
                overallScore = "0",
                bossesBeaten = "0",


            };

            loader.accounts.Add(newAccount);
            loader.SaveAccounts();     // Write to JSON immediately
            currentAccount = newAccount;
            result = LoginResult.AccountCreated;
            Debug.Log($"New account created for {currentAccount.name}!");
        }

        //Old Method
        //AccountSession.Instance.playerName = currentAccount.name;
        // AccountSession.Instance.marbleType = currentAccount.marbleType;
        //AccountSession.Instance.points = currentAccount.points;


        SyncSessionData();

        //if (accountUI != null) accountUI.SetActive(true);
        ui.UpdateAccountUI(currentAccount);

        return result; 
    }
    //public void AssignMarble(Marble marble)
    //{
      //  currentAccount.marbleType = marble.MarbleType.ToString();
      //  SyncSessionData();
       // loader.SaveAccounts();
   // }

    // Getting the marble type back out when needed
    //public MarbleType GetMarbleType()
    //{
     //   return (MarbleType)System.Enum.Parse(typeof(MarbleType), currentAccount.marbleType);
   // }

   // public void UpdateMarble(MarbleType marbleType)
    //{
      //  currentAccount.marbleType = marbleType.ToString();
       // loader.SaveAccounts();
       // Debug.Log($"Marble updated to {currentAccount.marbleType}");
    //}

    public void SaveAccount()
    {
        loader.SaveAccounts();
    }

    public void Logout()
    {
        currentAccount = null;

        ClearSessionData();
        ui.ClearUI();
        Debug.Log("Logged out successfully");

        //Old Methodd
        //AccountSession.Instance.playerName = "";
        //AccountSession.Instance.marbleType = "";
        //AccountSession.Instance.points = "";

        //ui.ClearUI();

        Debug.Log("Logged out successfully");
    }

    private void SyncSessionData()
    {
        playerName = currentAccount.name;
        highScore = currentAccount.highScore;
        overallScore = currentAccount.overallScore;
        bossesBeaten = currentAccount.bossesBeaten;
    }

    private void ClearSessionData()
    {
        playerName = "";
        highScore = "";
        overallScore = "";
        bossesBeaten = "";
    }

    /*public void AddPoints(int pointsToAdd)
    {
        if (currentAccount == null) return;

        int currentPoints = 0;
        int.TryParse(currentAccount.points, out currentPoints);
        currentPoints += pointsToAdd;

        currentAccount.points = currentPoints.ToString();
        SyncSessionData(); 
        SaveAccount();

        if (ui != null)
        {
            ui.UpdateAccountUI(currentAccount);
        }

        Debug.Log($"Added {pointsToAdd} points. Total: {currentPoints}");
    }*/

    public void AddHighScore(int highScore)
    {
        if (highScore >= int.Parse(currentAccount.highScore))
        {
            currentAccount.highScore = highScore.ToString();
            SyncSessionData();
            SaveAccount();
        }
        
        
    }

    public void AddOverallScore(int TotalScore)
    {
        int currentScore = int.Parse(currentAccount.overallScore);
        int newScore = currentScore + TotalScore;
        currentAccount.overallScore = newScore.ToString();

        SyncSessionData();
        SaveAccount();
    }

    public void AddBossBeaten(int BossScore)
    {
        int BossBeaten = int.Parse(currentAccount.overallScore);
        int newScore = BossBeaten + BossScore;
        currentAccount.overallScore = newScore.ToString();

        SyncSessionData();
        SaveAccount();
    }
}

public enum LoginResult
{
    LoggedIn,
    AccountCreated
}


