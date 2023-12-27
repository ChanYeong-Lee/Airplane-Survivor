using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillListUI : MonoBehaviour
{
    public Image[] activeImages;
    public Image[] passiveImages;
    [HideInInspector] public List<Skill> skillList;

    public void UpdateSkillList()
    {
        skillList = GameManager.Instance.player.skillList;

        Queue<Skill> activeSkills = new Queue<Skill>();
        Queue<Skill> passiveSkills = new Queue<Skill>();
        foreach (Skill skill in skillList)
        {
            if (skill.skillType == SkillType.Active)
            {
                activeSkills.Enqueue(skill);
            }
            else if (skill.skillType == SkillType.Passive)
            {
                passiveSkills.Enqueue(skill);
            }
        }
        int activeIndex = 0;
        while (activeSkills.Count > 0)
        {
            activeImages[activeIndex].sprite = activeSkills.Dequeue().skillIcon;
            activeImages[activeIndex].color = new Color(255, 255, 255, 255);
            activeIndex++;
        }
        int passiveIndex = 0;
        while (passiveSkills.Count > 0)
        {
            passiveImages[passiveIndex].sprite = passiveSkills.Dequeue().skillIcon;
            passiveImages[passiveIndex].color = new Color(255, 255, 255, 255);
            passiveIndex++;
        }
    }
}
