using UnityEngine;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField usernameInputField;
    public TMP_InputField passwordInputField;
    public GameObject settingPopup; // Referensi ke objek popup setting
    public GameObject wrongPopup; // Referensi ke objek popup salah

    private string correctUsername = "colorfun";
    private string correctPassword = "admin";

    public void OnLoginButtonClicked()
    {
        string enteredUsername = usernameInputField.text;
        string enteredPassword = passwordInputField.text;

        if (enteredUsername == correctUsername && enteredPassword == correctPassword)
        {
            Debug.Log("Login berhasil. Menampilkan popup setting.");
            settingPopup.SetActive(true);
        }
        else
        {
            Debug.Log("Login gagal. Username atau password salah.");
            wrongPopup.SetActive(true);
            Invoke("HideWrongPopup", 1f); // Panggil fungsi HideWrongPopup setelah 1 detik
        }
    }

    private void HideWrongPopup()
    {
        wrongPopup.SetActive(false);
    }
}
