using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenfessController : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private FontData fontData;
    [SerializeField] private TMP_Text authorText;
    [SerializeField] private TMP_Text receiverText;
    [SerializeField] private TMP_Text menfessText;

    private void Start()
    {
        SetMenfesInfo();
    }

    public void SetMenfesInfo()
    {
        receiverText.font = fontData.fontTemplate[gameData.currentFont];
        menfessText.font = fontData.fontTemplate[gameData.currentFont];

        authorText.text = gameData.currentAuthor;
        receiverText.text = "Dear " + gameData.currentReceiver + ",";
        menfessText.text = gameData.currentMenfess;
    }
}
