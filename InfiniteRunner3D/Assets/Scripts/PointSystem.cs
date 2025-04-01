using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class PointSystem : MonoBehaviour
    
{
    [SerializeField] private GameObject scoreDisplay;

    TextMeshProUGUI valText;
    void Start()
    {
        valText = scoreDisplay.GetComponent<TextMeshProUGUI>();
        valText.text = PointManager.Instance.value.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        valText.text = PointManager.Instance.value.ToString();
    }
}
