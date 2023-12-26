using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Image expBar;
    public Button PauseButton;
    public GameObject PauseOption;

    private void Pause()
    {
        PauseOption.SetActive(true);
    }

}
