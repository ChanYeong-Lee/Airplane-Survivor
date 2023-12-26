using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUI : MonoBehaviour
{
    public CharacterToggle[] characterToggles;
    private ToggleGroup toggleGroup;
    public Button applyButton;
    public CharacterInfo characterInfo;
    public int selectedIndex; 
    private void Awake()
    {
        toggleGroup = GetComponent<ToggleGroup>();
        applyButton.onClick.AddListener(Apply);
    }

    private void OnEnable()
    {
        for (int i = 0; i < characterToggles.Length; i++)
        {
            int index = i;
            characterToggles[i].shipIndex = i;
            characterToggles[i].toggle.onValueChanged.AddListener((isOn) => { if (isOn) SetInfo(index); });
        }
    }
    private void Update()
    {
        if (toggleGroup.AnyTogglesOn())
        {
            applyButton.interactable = true;
            characterInfo.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        GameManager.Instance.shipIndex = selectedIndex;
    }
  
    private void SetInfo(int index)
    {
        selectedIndex = index;
        characterInfo.selectedIndex = this.selectedIndex;
        characterInfo.InfoUpdate();
    }

    private void Apply()
    {
        gameObject.SetActive(false);
        SceneLoader.Instance.LoadScene("GameScene");
    }
}
