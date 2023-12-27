using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Image expBar;
    public Button PauseButton;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI killText;
    public TextMeshProUGUI scoreText;
    public Toggle sprintToggle;

    public GameObject PauseOption;
    public GameObject LevelUpPannel;
    public GameObject GameOverPannel;
    public SkillListUI skillListUI;

    private void Start()
    {
        GameManager.Instance.player.onExpChange.AddListener(UpdateEXPbar);
        GameManager.Instance.player.onDie.AddListener(GameOver);
        GameManager.Instance.player.onLevelChange.AddListener(LevelUp);
        GameManager.Instance.player.onKillChange.AddListener(KillUp);
        GameManager.Instance.player.onScoreChange.AddListener(ScoreUp);
        GameManager.Instance.player.sprintPrepared.AddListener((on) => sprintToggle.isOn = on);
        SkillManager.Instance.onSkillChange.AddListener(UpdateSkillList);
        PauseButton.onClick.AddListener(Pause);
    }

    private void Pause()
    {
        PauseOption.SetActive(true);
    }

    private void UpdateEXPbar(float amount)
    {
        expBar.fillAmount = amount;
    }

    private void LevelUp(int level)
    {
        levelText.text = $"LV{level}";
        LevelUpPannel.SetActive(true);
    }

    private void GameOver()
    {
        GameOverPannel.SetActive(true);
    }

    private void KillUp(int kill)
    {
        killText.text = $"{kill} Kill";
    }

    private void ScoreUp(int score)
    {
        scoreText.text = $"{score} Score";
    }

    private void UpdateSkillList()
    {
        skillListUI.UpdateSkillList();
    }

}
