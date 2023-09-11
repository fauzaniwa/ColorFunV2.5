using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SelectRangkulFeature()
    {
        PlayerPrefs.SetInt("SelectedTemplate", 4);
    }
}
