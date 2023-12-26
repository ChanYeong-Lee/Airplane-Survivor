using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterToggle : MonoBehaviour
{
    public Toggle toggle;
    public int shipIndex;
    public TextMeshProUGUI nameText;
    public Image shipImage;

    private void Start()
    {
        nameText.text = Data.Instance.shipPrefabs[shipIndex].shipName;
        shipImage.sprite = Data.Instance.shipPrefabs[shipIndex].shipIcon;
    }
}
