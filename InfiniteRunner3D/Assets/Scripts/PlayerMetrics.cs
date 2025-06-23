using UnityEngine;
using TMPro;
using Unity.Services.CloudSave;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Collections.Generic;


public class PlayerMetrics : MonoBehaviour
{
    [SerializeField] public string inputText;
    public TMP_Text MetricsText;

    //string Key = "HighScore";

    string highScoreKey = "HighScore";
    string overallScoreKey = "OverallScore";
    string bossesBeatenKey = "BossesBeaten";

    string output = "1";
    string output2 = "0";
    string output3 = "0";



    public void InputIn(string input)
    {
        inputText = input;
        //Debug.Log(input);
    }


    public async void Start()
    {
        await UnityServices.InitializeAsync();
        //await AuthenticationService.Instance.SignInAnonymouslyAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("Signed in anonymously. PlayerID: " + AuthenticationService.Instance.PlayerId);
        }
        else
        {
            Debug.Log("Already signed in.");
        }

        

    }

     public async void SignUp()
     {


        var data = new Dictionary<string, object> { { "HighScore", 0 }, { "OverallScore", 0 }, { "BossesBeaten", 0 } };
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);
        Debug.Log("User created: " + inputText);

        //Debug.Log(inputText);
         //inputText = inputText;
         //var result = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> { inputText }); //Most forms say to use CloudSaveService.Instance.Data.LoadAsync but that is obsolete. Also had to use var as the data is not set

        // if (result.ContainsKey(inputText))
        // {
         //    Debug.LogWarning("Username already taken.");
        // }
         //else
         //{

             //await CloudSaveService.Instance.Data.Player.SaveAsync(new Dictionary<string, object>
             //{
              //   { "PlayerName", inputText },
               //  { "OverallScore", 0 },
                // { "HighScore", 0 },
                // { "BossesBeaten", 0 }
            // });

             

         
             
        //}



     }

    public async void Add(int HScore, int OScore ,int Boss)
    {
        //LogIn();
        if (HScore >= int.Parse(output))
        {
            int Total = OScore + int.Parse(output2);

            var data = new Dictionary<string, object> { { "HighScore", HScore }, { "OverallScore", Total }, { "BossesBeaten", Boss } };
            await CloudSaveService.Instance.Data.Player.SaveAsync(data);
            Debug.Log("User Updated: " + inputText);
        }
        else
        {
            int Total = OScore + int.Parse(output2);
            var data = new Dictionary<string, object> { { "OverallScore", Total } };
            await CloudSaveService.Instance.Data.Player.SaveAsync(data);
            Debug.Log("User Updated: " + inputText);
        }
        
    }

    public async void LogIn()
    {

        Dictionary<string, string> savedData = await CloudSaveService.Instance.Data.LoadAsync(new HashSet<string> { highScoreKey, overallScoreKey, bossesBeatenKey });


             Debug.Log(savedData[highScoreKey]);

            if (savedData[highScoreKey] == null)
            {
                SignUp();
            }

            else
            {
               output = savedData[highScoreKey];
               output2 = savedData[overallScoreKey];
               output3 = savedData[bossesBeatenKey];

            string TotalOutput = "High Score: " +  output + "\n" + "Overall Score: " + output2 + "\n" + "Bosses Beaten: " + output3;


                MetricsText.text = TotalOutput;
            }




            /* if (!savedData.TryGetValue(Key, out string value) || string.IsNullOrEmpty(value))
             {
                 // If the key doesn't exist or the value is empty/null
                 SignUp();
             }
             else
             {
                 Debug.Log($"Raw Cloud Save value: {value}");

                 // Try to parse as integer
                 if (int.TryParse(value, out int numericValue))
                 {
                     MetricsText.text = numericValue.ToString();
                     // You can now use `numericValue` as an int
                 }
                 else
                 {
                     Debug.LogWarning($"Value for key '{Key}' is not a valid integer: {value}");
                     MetricsText.text = value;
                 }
             }*/










            //var keysToLoad = new HashSet<string> { "PlayerName", "OverallScore", "HighScore", "BossesBeaten" };
            //var data = await CloudSaveService.Instance.Data.Player.LoadAsync(keysToLoad);

            /* if (data.ContainsKey("PlayerName"))
             {

                 string name = data["PlayerName"].Value.ToString();
                 int score = int.Parse(data["OverallScore"].Value.ToString());
                 int highScore = int.Parse(data["HighScore"].Value.ToString());
                 int bosses = int.Parse(data["BossesBeaten"].Value.ToString());

                 string output = $"Welcome back, {name}!\n" +
                                 $"Score: {score}\n" +
                                 $"High Score: {highScore}\n" +
                                 $"Bosses Beaten: {bosses}";

                 Debug.Log(output);
                 MetricsText.text = output;


             }
             else
             {
                 Debug.Log("No save found for username: " + inputText);
             }*/

            //var data = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> { inputText });
            /*var data = await CloudSaveService.Instance.Data.Player.LoadAsync(new HashSet<string> {
            "PlayerName", "Score", "HighScore", "BossesBeaten"
             });

            //if (data.TryGetValue(inputText, out var PlayerData))
            if (data.TryGetValue("PlayerName", out var playerNameItem) && playerNameItem.Value.ToString() == inputText)
            {
               // var data = PlayerData.Value as Dictionary<string, object>;

                int score = int.Parse(data["Score"].ToString());
                int highScore = int.Parse(data["HighScore"].ToString());
                int bosses = int.Parse(data["BossesBeaten"].ToString());

                string output = $"Loaded for {inputText}:\n" +
                                   $"Score: {score}\n" +
                                   $"High Score: {highScore}\n" +
                                   $"Bosses Beaten: {bosses}";

                Debug.Log(output);

                MetricsText.text = output;
            }
            else
            {
                Debug.Log("No save found for username: " + inputText);
            }*/
        }

    }
