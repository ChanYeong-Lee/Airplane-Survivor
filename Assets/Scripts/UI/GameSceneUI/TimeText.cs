using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>(); 
    }
    private void Update()
    {
        if (Clock.Instance.Running)
        {
            text.text = $"{Clock.Instance.minutes:D2} : {Clock.Instance.seconds:D2}";
        }
    }
}
