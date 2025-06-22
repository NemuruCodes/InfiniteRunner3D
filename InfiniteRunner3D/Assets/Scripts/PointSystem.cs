using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class PointSystem : MonoBehaviour
    
{
    public static PointSystem Instance { get; private set; }

    [SerializeField] private GameObject scoreDisplay;
    [SerializeField] private GameObject BossesDefeated;

    private TextMeshProUGUI valText;
    private TextMeshProUGUI bossText;


    void Start()
    {
        /*
        valText = scoreDisplay.GetComponent<TextMeshProUGUI>();
        valText.text = PointManager.Instance.value.ToString();
        */
        if (scoreDisplay != null)
        {
            valText = scoreDisplay.GetComponent<TextMeshProUGUI>();
        }

        if (valText != null)
        {
            valText.text = PointManager.Instance.value.ToString();
        }

        if(BossesDefeated != null)
        {
            bossText = BossesDefeated.GetComponent<TextMeshProUGUI>();
        }

        if (bossText != null)
        {
            bossText.text = PointManager.Instance.bossesDefeated.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //valText.text = PointManager.Instance.value.ToString();

        if (valText != null)
        {
            valText.text = PointManager.Instance.value.ToString();
        }
        if (bossText != null)
        {
            bossText.text = PointManager.Instance.bossesDefeated.ToString();
        }
    }

    
}
