using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> fontButtonMenu;
    [SerializeField] private FontData fontData;
    [SerializeField] private GameData gameData;


    private int countScroll = 0;

    private void Start()
    {
        Optionscroll(0);

        foreach(GameObject item in fontButtonMenu)
        {
            item.AddComponent<Button>();
            item.GetComponent<Button>().onClick.AddListener(SetFont);
        }
    }

    public void Optionscroll(int value)
    {
        countScroll += value;

        if(countScroll >= fontButtonMenu.Count)
        {
            countScroll = 0;
        }

        foreach (var item in fontButtonMenu)
        {
            item.SetActive(false);
        }

        fontButtonMenu[countScroll].SetActive(true);
    }

    private void SetFont()
    {
        gameData.currentFont = countScroll;
        SceneManager.LoadScene("MenfesScene");
    }
}
