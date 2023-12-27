using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{
    public SkillSelectButton[] buttons;
    public UnityEngine.UI.Button applyButton;
    private void Awake()
    {
        foreach (SkillSelectButton button in buttons)
        {
            button.button.onClick.AddListener(Click);
        }
        applyButton.onClick.AddListener(Click);
    }
    private void OnEnable()
    {
        Time.timeScale = 0;
        
        foreach (SkillSelectButton button in buttons)
        {
            button.gameObject.SetActive(false); 
        }
        applyButton.gameObject.SetActive(false);

        int count = 0;
        List<SkillName> skillList = new List<SkillName>();
        for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++)
        {
            if (SkillManager.Instance.skillQueueDictionary[(SkillName)i].Count > 0)
            {
                count++;
                skillList.Add((SkillName)i);
            }
        }
        if (count == 0)
        {
            applyButton.gameObject.SetActive(true);
        }
        else
        {
            ListShuffle(skillList);
            for (int i = 0; i < count; i++)
            {
                if (i == 3)
                    break;
                buttons[i].skillName = skillList[i];
                buttons[i].gameObject.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    private void ListShuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomValue = UnityEngine.Random.Range(0, list.Count);
            T temp = list[i];
            list[i] = list[randomValue];
            list[randomValue] = temp;
        }
    }
    private void Click()
    {
        gameObject.SetActive(false);
    }
}

