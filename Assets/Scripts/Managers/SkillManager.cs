using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private static SkillManager instance;
    public static SkillManager Instance { get { return instance; } }

    [HideInInspector] public Player player;
    public Dictionary<SkillName, Queue<Skill>> skillQueueDictionary = new Dictionary<SkillName, Queue<Skill>>();
    private void Start()
    {
        player = GameManager.Instance.player;
        for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++)
        {
            skillQueueDictionary.Add((SkillName)i,LTQ.ListToQueue(Data.Instance.skillDictionary[(SkillName)i]));
        }
        LevelUp(player.ship.startSkill);
    }

    public bool LevelUp(SkillName skillName)
    {
        if (CheckSkill(skillName))
        {
            Skill prevSkill = player.skillList.Find(a => a.skillName == skillName);
            if (prevSkill != null)
            {
                player.skillList.Remove(prevSkill);
                Destroy(prevSkill.gameObject);
            }
            Skill newSkill = Instantiate(skillQueueDictionary[skillName].Dequeue());
            newSkill.transform.parent = player.skillsParent;
            player.skillList.Add(newSkill);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckSkill(SkillName skillName)
    {
        return skillQueueDictionary[skillName].Count > 0;
    }

    public void LevelUpTest()
    {
        LevelUp(SkillName.RevolutionSkill);
        LevelUp(SkillName.RotatingSpeedSkill);
    }
}
