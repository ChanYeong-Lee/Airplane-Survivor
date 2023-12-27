using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseOption : MonoBehaviour
{
    public Button resumeButton;
    public Button exitButton;
    private void Awake()
    {
        resumeButton.onClick.AddListener(Resume);
        exitButton.onClick.AddListener(Exit);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    private void Resume()
    {
        gameObject.SetActive(false);
    }

    private void Exit()
    {
        gameObject.SetActive(false);
        GameManager.Instance.GameOver();
    }
}
