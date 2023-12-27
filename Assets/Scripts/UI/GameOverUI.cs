using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Button exitButton;
    private void Awake()
    {
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

    private void Exit()
    {
        gameObject.SetActive(false);
        GameManager.Instance.GameOver();
    }
}
