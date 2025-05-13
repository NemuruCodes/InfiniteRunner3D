using System.Threading;
using TMPro;
using UnityEngine;

public class PickUpUI : MonoBehaviour
{
    public static PickUpUI Instance;
    

    private float timer;
    private bool active;

    public GameObject panel;

    public TextMeshProUGUI Buff;
    public TextMeshProUGUI BuffTime;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
            panel.SetActive(false);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            timer -= Time.deltaTime;

            if (timer > 0)
            {
                BuffTime.text = timer.ToString("F1") +  "s";

            }
            else
            {
               HideBuff();  
            }
        }
    }

    public void ShowBuff(string buffName, float duration)
    {
        
        Buff.text = buffName;
        timer = duration;
    
        panel.SetActive(true);
        
        active = true;

    }
    public void HideBuff()
    {
        panel.SetActive(false);
        
        active = false;
    }
}
