using UnityEngine;
using TMPro;

public class AccountDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text accountInfoText;

    void Start()
    {
        if (AccountManager.Instance != null && AccountManager.Instance.currentAccount != null)
        {
            UpdateAccountUI(AccountManager.Instance.currentAccount);
        }
        else
        {
            Debug.LogWarning("No account logged in when Level 1 loaded.");
            accountInfoText.text = "";
        }
    }

    public void UpdateAccountUI(BaseAccountData account)
    {
        accountInfoText.text = "Name: " + account.name + "\n" +
                                "High Score: " + account.highScore + "\n" +
                                "Overall Score: " + account.overallScore + "\n" +
                                "Bosses Beaten: " + account.bossesBeaten;
    }
}
