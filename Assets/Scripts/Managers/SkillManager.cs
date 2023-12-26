using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillManager : MonoBehaviour
{
    private static SkillManager instance;
    public static SkillManager Instance { get { return instance; } }
    public UnityEvent onSkillChange;
    public bool isOk;
    [HideInInspector] public Player player;
    public Dictionary<SkillName, Queue<Skill>> skillQueueDictionary = new Dictionary<SkillName, Queue<Skill>>();
    private void Awake()
    {
        instance = this; 
    }
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => GameManager.Instance.prepared);
        player = GameManager.Instance.player;
        for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++)
        {
            skillQueueDictionary.Add((SkillName)i,LTQ.ListToQueue(Data.Instance.skillDictionary[(SkillName)i]));
        }
        LevelUp(player.ship.startSkill);
        isOk = true;
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
            onSkillChange?.Invoke();
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
        LevelUp(SkillName.AreaSkill);
        LevelUp(SkillName.MoveSpeedSkill);
    }
}
