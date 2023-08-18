using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UpdateEndPoint : MonoBehaviour
{
    public TMP_InputField uploadURLInputField;
    public TMP_InputField phpEndpointSaveDataInputField;
    public GameObject successPopup; // Referensi ke objek popup sukses
    public TMP_Dropdown templateDropdown; // Referensi ke dropdown template

    public GameObject template1; // Referensi ke GameObject Template 1
    public GameObject template2; // Referensi ke GameObject Template 2 Hindi

    private void Start()
    {
        // Mendapatkan nilai dari PlayerPrefs dan inisialisasi input field
        uploadURLInputField.text = PlayerPrefs.GetString("ImageEndPoint", "");
        phpEndpointSaveDataInputField.text = PlayerPrefs.GetString("DatabaseEndPoint", "");

        // Matikan popup sukses pada awalnya
        successPopup.SetActive(false);

        // Inisialisasi konten dropdown
        InitializeDropdownContent();

        // Tambahkan event listener untuk pemilihan template
        templateDropdown.onValueChanged.AddListener(OnTemplateDropdownValueChanged);

        // Atur label dropdown berdasarkan nilai PlayerPrefs "SelectedTemplate"
        int selectedTemplate = PlayerPrefs.GetInt("SelectedTemplate", 1); // Default: Template 1
        templateDropdown.value = selectedTemplate - 1; // Kurangi 1 karena index dimulai dari 0
        templateDropdown.RefreshShownValue();
    }

    private void InitializeDropdownContent()
    {
        // Bersihkan konten dropdown
        templateDropdown.ClearOptions();

        // Tambahkan pilihan "Template 1", "Template 2 Hindi", dan "Template 3"
        templateDropdown.AddOptions(new List<string> { "Template 1", "Template 2 Hindi", "Template 3" });
    }

    public void OnSaveButtonClicked()
    {
        // Simpan nilai input field ke dalam PlayerPrefs
        PlayerPrefs.SetString("ImageEndPoint", uploadURLInputField.text);
        PlayerPrefs.SetString("DatabaseEndPoint", phpEndpointSaveDataInputField.text);
        PlayerPrefs.Save();

        Debug.Log("Nilai UploadURL dan phpEndpointSaveDataInputField berhasil disimpan!");

        // Tampilkan popup sukses
        successPopup.SetActive(true);

        // Jalankan Coroutine untuk menonaktifkan popup setelah 1,5 detik
        StartCoroutine(DisableSuccessPopupAfterDelay());
    }

    private System.Collections.IEnumerator DisableSuccessPopupAfterDelay()
    {
        yield return new WaitForSeconds(1f); // Tunggu selama 1,5 detik
        successPopup.SetActive(false); // Matikan popup sukses
    }

    private void OnTemplateDropdownValueChanged(int index)
    {
        // Atur nilai PlayerPrefs berdasarkan pilihan template
        if (index == 0)
        {
            PlayerPrefs.SetInt("SelectedTemplate", 1); // Template 1
        }
        else if (index == 1)
        {
            PlayerPrefs.SetInt("SelectedTemplate", 2); // Template 2 Hindi
        }
        else if (index == 2)
        {
            PlayerPrefs.SetInt("SelectedTemplate", 3); // Template 3
        }
    }
}
