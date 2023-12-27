using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPannelUI : MonoBehaviour
{
    [Header("LeftSide")]
    public Image shipIcon;
    public TextMeshProUGUI shipNameText;
    public TextMeshProUGUI resultText;

    [Header("RightSide")]
    public TextMeshProUGUI skillNameText;
    public TextMeshProUGUI skillLevelText;

    private void Start()
    {
        shipIcon.sprite = Data.Instance.shipPrefabs[GameManager.Instance.shipIndex].shipIcon;
        shipNameText.text = Data.Instance.shipPrefabs[GameManager.Instance.shipIndex].shipName;
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(GameManager.Instance.time);
        sb.AppendLine(GameManager.Instance.currentScore.ToString());
        sb.AppendLine(GameManager.Instance.playerLevel.ToString());
        sb.AppendLine(GameManager.Instance.killCount.ToString());
        sb.AppendLine(((int)GameManager.Instance.givenDamage).ToString());
        sb.Append(((int)GameManager.Instance.takenDamage).ToString());
        resultText.text = sb.ToString();

        StringBuilder skillNames = new StringBuilder();
        StringBuilder skillLevels = new StringBuilder();
        foreach (Skill skill in GameManager.Instance.skillList)
        {
            skillNames.AppendLine($"{skill.nameInKor}");
            skillLevels.AppendLine($"{skill.level}");
        }
        skillNameText.text = skillNames.ToString();
        skillLevelText.text = skillLevels.ToString();   
    }
}
