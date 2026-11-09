using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject loginPanel;
    [SerializeField] private GameObject mainMenuUi;

    [SerializeField] private TMP_InputField nameInputField;
    // [SerializeField] private AccountManager accountManager;

    public TMP_Text MetricsText;
    public TMP_Text feedbackText;


    //string Key = "HighScore";

    //string nameKey = "Name";
    //string highScoreKey = "HighScore";
    //string overallScoreKey = "OverallScore";
    //string bossesBeatenKey = "BossesBeaten";

    string output = "";
    string output2 = "";
    string output3 = "";
    string output4 = "";

    private void Start()
    {
        Debug.Log("MainMenu script initialized");

        if (AccountManager.Instance != null)
        {
            AccountManager.Instance.ui = this;

            if (AccountManager.Instance != null && AccountManager.Instance.currentAccount != null)
            {
                ShowMainMenu();
                ShowAccountUI();
            }
            else
            {
                ShowLoginPanel();
            }
        }
    }

    private void ShowLoginPanel()
    {
        if (loginPanel != null) loginPanel.SetActive(true);
    }

    private void HideLoginPanel()
    {
        if (loginPanel != null) loginPanel.SetActive(false);
    }

    private void ShowAccountUI()
    {
        HideLoginPanel();
        UpdateAccountUI(AccountManager.Instance.currentAccount);
    }

    private void ShowMainMenu()
    {
        mainMenuUi.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Time.timeScale = 1;
        PlayerController.isAlive = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void SettingsLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
    }

    public void Close()
    {
        SceneManager.UnloadSceneAsync("SettingsMenu");
    }

    public void OnLoginButtonPressed()
    {
        string playerName = nameInputField.text.Trim(); // nameInputField is a TMP_InputField
        if (!string.IsNullOrEmpty(playerName))
        {
            
            LoginResult result = AccountManager.Instance.Login(playerName);
            //accountManager.Login(playerName);

            switch (result)
            {
                case LoginResult.LoggedIn:
                    ShowFeedback($"Welcome back, {playerName}!");
                    break;
                case LoginResult.AccountCreated:
                    ShowFeedback($"Account created for {playerName}!");
                    break;
            }


            HideLoginPanel();
        }

        nameInputField.text = "";
    }

    public void OnLogoutButtonPressed()
    {
        AccountManager.Instance.Logout();
        //accountManager.Logout();
    }

    
    public void UpdateAccountUI(BaseAccountData account)
    {
        output = account.name;
        output2 = account.highScore;
        output3 = account.overallScore;
        output4 = account.bossesBeaten;

        

        string TotalOutput = "Name: " + output + "\n" + "High Score: " + output2 + "\n" + "Overall Score: " + output3 + "\n" + "Bosses Beaten: " + output4;


        MetricsText.text = TotalOutput;

    }



    public void ClearUI()
    {
        MetricsText.text = "";
    }

    private void ShowFeedback(string message) // Bit  overkill but cool to do
    {
        

        feedbackText.text = message;
        feedbackText.gameObject.SetActive(true);
        StartCoroutine(HideFeedbackAfterDelay(30f));
    }

    private IEnumerator HideFeedbackAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (feedbackText != null) feedbackText.gameObject.SetActive(false);
    }

}
