using System.Collections;
using System.Collections.Generic;
using TMPro;
using TS.ColorPicker.Demo;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenfessManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> menfesTamplateList;
    [SerializeField] private MenfessController menfessController;
    public GameObject ColorDanSave;
    public GameObject CekGambar;

    private void Start()
    {
        SpawnMenfes();
    }

    private void SpawnMenfes()
    {
        var obj = Instantiate(menfesTamplateList[0]);
        menfessController = obj.GetComponent<MenfessController>();
    }

    public void SaveMenfess()
    {
        Animator anim = menfessController.GetComponent<Animator>();

        anim.SetBool("finish2", true);
        ColorDanSave.SetActive(false);
        CekGambar.SetActive(true);
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene"); // Ganti "MainMenuScene" dengan nama sesuai scene Anda
    }
}
