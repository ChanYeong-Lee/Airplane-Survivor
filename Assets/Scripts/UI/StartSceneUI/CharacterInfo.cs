using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Image shipImage;
    public int selectedIndex;

    private void OnEnable()
    {
        InfoUpdate();
    }
    public void InfoUpdate()
    {
        nameText.text = Data.Instance.shipPrefabs[selectedIndex].shipName;
        descriptionText.text = Data.Instance.shipPrefabs[selectedIndex].description;
        shipImage.sprite = Data.Instance.shipPrefabs[selectedIndex].shipIcon;
    }


}
