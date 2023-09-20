using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UpdateEndPoint : MonoBehaviour
{
    public TMP_InputField uploadURLInputField;
    public TMP_InputField phpEndpointSaveDataInputField;
    public TMP_InputField menfessEndpointInputField; // Tambahkan ini

    public GameObject successPopup; // Referensi ke objek popup sukses
    public TMP_Dropdown templateDropdown; // Referensi ke dropdown template
    public TMP_Dropdown tamplateMenfessOption;
    public TMP_InputField targetWidthInputField; // Referensi ke input field targetWidth
    public TMP_InputField targetHeightInputField; // Referensi ke input field targetHeight
    public GameObject BG1; // Referensi ke bg 1
    public GameObject BG2; // Referensi ke bg 2

    public GameObject template1; // Referensi ke GameObject Template 1
    public GameObject template2; // Referensi ke GameObject Template 2 Hindi
    public GameObject template3; // Referensi ke GameObject Template 3

    private string[] templateLabels = { "Template 1", "Template 2 Hindi", "Template 3" }; // Tambahkan ini

    private void Start()
    {
        // Mendapatkan nilai dari PlayerPrefs dan inisialisasi input field
        uploadURLInputField.text = PlayerPrefs.GetString("ImageEndPoint", "");
        phpEndpointSaveDataInputField.text = PlayerPrefs.GetString("DatabaseEndPoint", "");
        menfessEndpointInputField.text = PlayerPrefs.GetString("DatabaseEndPoint2", ""); // Tambahkan ini

        // Matikan popup sukses pada awalnya
        successPopup.SetActive(false);

        // Inisialisasi konten dropdown
        InitializeDropdownContent();

        // Tambahkan event listener untuk pemilihan template
        templateDropdown.onValueChanged.AddListener(OnTemplateDropdownValueChanged);
        tamplateMenfessOption.onValueChanged.AddListener(OnMenfessTamplateValueChanged);

        // Atur label dropdown berdasarkan nilai PlayerPrefs "SelectedTemplate"
        int selectedTemplate = PlayerPrefs.GetInt("SelectedTemplate", 1); // Default: Template 1
        templateDropdown.value = selectedTemplate - 1; // Kurangi 1 karena index dimulai dari 0
        templateDropdown.RefreshShownValue();

        // Atur label template pada tamplateMenfessOption berdasarkan nilai PlayerPrefs "SelectedMenfesTamplate"
        int selectedMenfesTemplate = PlayerPrefs.GetInt("SelectedMenfesTamplate", 0); // Default: Template 1
        tamplateMenfessOption.value = selectedMenfesTemplate;
        tamplateMenfessOption.RefreshShownValue();
        SetMenfessTemplateLabel(selectedMenfesTemplate);

        // Tampilkan nilai targetWidth dan targetHeight dari PlayerPrefs
        targetWidthInputField.text = PlayerPrefs.GetInt("targetWidth", 1920).ToString();
        targetHeightInputField.text = PlayerPrefs.GetInt("targetHeight", 1080).ToString();
    }

    private void InitializeDropdownContent()
    {
        // Bersihkan konten dropdown
        templateDropdown.ClearOptions();
        tamplateMenfessOption.ClearOptions();

        // Tambahkan pilihan "Template 1", "Template 2 Hindi", dan "Template 3"
        templateDropdown.AddOptions(new List<string> { "Template 1", "Template 2 Hindi", "Template 3" });
        tamplateMenfessOption.AddOptions(new List<string> { "Template 1", "Template 2 Hindi" });
    }

    public void OnSaveButtonClicked()
    {
        // Simpan nilai input field ke dalam PlayerPrefs
        PlayerPrefs.SetString("ImageEndPoint", uploadURLInputField.text);
        PlayerPrefs.SetString("DatabaseEndPoint", phpEndpointSaveDataInputField.text);
        PlayerPrefs.SetString("DatabaseEndPoint2", menfessEndpointInputField.text);

        // Simpan nilai targetWidth dan targetHeight ke dalam PlayerPrefs
        int targetWidth = string.IsNullOrEmpty(targetWidthInputField.text) ? 1920 : int.Parse(targetWidthInputField.text);
        int targetHeight = string.IsNullOrEmpty(targetHeightInputField.text) ? 1080 : int.Parse(targetHeightInputField.text);
        PlayerPrefs.SetInt("targetWidth", targetWidth);
        PlayerPrefs.SetInt("targetHeight", targetHeight);

        PlayerPrefs.Save();

        Debug.Log("Nilai UploadURL, phpEndpointSaveDataInputField, DatabaseEndPoint2, targetWidth, dan targetHeight berhasil disimpan!");

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
            BG1.SetActive(true);
            BG2.SetActive(false);
        }
        else if (index == 1)
        {
            PlayerPrefs.SetInt("SelectedTemplate", 2); // Template 2 Hindi
            BG1.SetActive(true);
            BG2.SetActive(false);
        }
        else if (index == 2)
        {
            PlayerPrefs.SetInt("SelectedTemplate", 3); // Template 3
            BG1.SetActive(false);
            BG2.SetActive(true);
        }
    }

    private void OnMenfessTamplateValueChanged(int index)
    {
        PlayerPrefs.SetInt("SelectedMenfesTamplate", index);
        SetMenfessTemplateLabel(index);
    }

    private void SetMenfessTemplateLabel(int templateIndex)
    {
        tamplateMenfessOption.captionText.text = templateLabels[templateIndex];
    }
}
