using TMPro;
using UnityEngine;

public class SaveAuthorName : MonoBehaviour
{
    [SerializeField] GameObject InputPopupName;
    [SerializeField] GameObject SelectTemplateDesainPopup;
    [SerializeField] private GameData gameData;
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private GameObject template1;
    [SerializeField] private GameObject template2;
    [SerializeField] private GameObject template3; // Referensi ke GameObject Template 3

    public void Save()
    {
        if (nameField.text != "")
        {
            InputPopupName.SetActive(false);
            SelectTemplateDesainPopup.SetActive(true);
            gameData.currentAuthor = nameField.text;

            // Pengecekan dan aktifkan template berdasarkan nilai PlayerPrefs "SelectedTemplate"
            int selectedTemplate = PlayerPrefs.GetInt("SelectedTemplate", 1);
            if (selectedTemplate == 1)
            {
                template1.SetActive(true);
                template2.SetActive(false);
                template3.SetActive(false);
            }
            else if (selectedTemplate == 2)
            {
                template1.SetActive(false);
                template2.SetActive(true);
                template3.SetActive(false);
            }
            else if (selectedTemplate == 3) // Tambahkan kondisi untuk Template 3
            {
                template1.SetActive(false);
                template2.SetActive(false);
                template3.SetActive(true);
            }
        }
    }
}
