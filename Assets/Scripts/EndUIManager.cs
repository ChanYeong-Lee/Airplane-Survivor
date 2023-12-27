using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUIManager : MonoBehaviour
{
    public Button exitButton;
    public Button restartButton;

    private void Start()
    {
        exitButton.onClick.AddListener(Exit);
        restartButton.onClick.AddListener(Restart);
    }

    private void Exit()
    {
        GameManager.Instance.ResetData();
        SceneLoader.Instance.LoadScene("StartScene");
    }
    private void Restart()
    {
        GameManager.Instance.ResetData();
        SceneLoader.Instance.LoadScene("StartScene");
    }

}
