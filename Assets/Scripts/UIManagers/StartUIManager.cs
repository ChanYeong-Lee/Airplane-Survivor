using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public TextMeshProUGUI scoreText;
    public GameObject characterSelectUI;

    private void Awake()
    {
        startButton.onClick.AddListener(CharacterSelect);
        exitButton.onClick.AddListener(Exit);
        scoreText.text = GameManager.Instance.highScore.ToString();
    }

    private void CharacterSelect()
    {
        characterSelectUI.SetActive(true);
    }

    private void Exit()
    {
        SceneLoader.Instance.Quit();
    }
}
