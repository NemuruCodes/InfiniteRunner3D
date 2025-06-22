using UnityEngine;
using TMPro;

public class BossDefeatUI : MonoBehaviour
{
    public TextMeshProUGUI bossDefeatedText;


    
    void Update()
    {
        bossDefeatedText.text = PointManager.Instance.bossesDefeated.ToString();
    }
}
