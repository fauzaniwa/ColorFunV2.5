using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAuthorName : MonoBehaviour
{
    [SerializeField] GameObject InputPopupName;
    [SerializeField] GameObject SelectTemplateDesainPopup;
    [SerializeField] private GameData gameData;
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private GameObject template1;
    [SerializeField] private GameObject template2;
    [SerializeField] private GameObject template3; // Referensi ke GameObject Template 3
    [SerializeField] private GameObject selectFontBoard;
    [SerializeField] private GameObject BG;

    [SerializeField] private TMP_InputField receiverField;
    [SerializeField] private TMP_InputField menfessField;

    public void Save()
    {
        if (nameField.text != "")
        {
            InputPopupName.SetActive(false);
            SelectTemplateDesainPopup.SetActive(true);
            gameData.currentAuthor = nameField.text;
            BG.SetActive(false);
            // Pengecekan dan aktifkan template berdasarkan nilai PlayerPrefs "SelectedTemplate"
            int selectedTemplate = PlayerPrefs.GetInt("SelectedTemplate", 1);
            if (selectedTemplate == 1)
            {
                template1.SetActive(true);
                template2.SetActive(false);
                template3.SetActive(false);
                selectFontBoard.SetActive(false);
            }
            else if (selectedTemplate == 2)
            {
                template1.SetActive(false);
                template2.SetActive(true);
                template3.SetActive(false);
                selectFontBoard.SetActive(false);
            }
            else if (selectedTemplate == 3) // Tambahkan kondisi untuk Template 3
            {
                template1.SetActive(false);
                template2.SetActive(false);
                template3.SetActive(true);
                selectFontBoard.SetActive(false);
            }
            else if (selectedTemplate == 4)
            {
                template1.SetActive(false);
                template2.SetActive(false);
                template3.SetActive(false);
                selectFontBoard.SetActive(true);
            }

        }
    }

    public void SaveMenfes()
    {
        gameData.currentAuthor = nameField.text;
        gameData.currentReceiver = receiverField.text;
        gameData.currentMenfess = menfessField.text;

        int selectedTemplate = PlayerPrefs.GetInt("SelectedTemplate", 1);
        if (selectedTemplate == 1)
        {
            template1.SetActive(true);
            template2.SetActive(false);
            template3.SetActive(false);
            selectFontBoard.SetActive(false);
        }
        else if (selectedTemplate == 2)
        {
            template1.SetActive(false);
            template2.SetActive(true);
            template3.SetActive(false);
            selectFontBoard.SetActive(false);
        }
        else if (selectedTemplate == 3) // Tambahkan kondisi untuk Template 3
        {
            template1.SetActive(false);
            template2.SetActive(false);
            template3.SetActive(true);
            selectFontBoard.SetActive(false);
        }
        else if (selectedTemplate == 4)
        {
            template1.SetActive(false);
            template2.SetActive(false);
            template3.SetActive(false);
            selectFontBoard.SetActive(true);
        }

    }
}
