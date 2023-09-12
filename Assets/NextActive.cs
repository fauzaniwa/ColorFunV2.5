using UnityEngine;
using TMPro;

public class NextActive : MonoBehaviour
{
    public TMP_InputField inputFieldToCheck; // TMP_InputField yang akan diperiksa
    public GameObject gameObjectToEnable; // GameObject yang akan diaktifkan jika input field memiliki nilai
    public GameObject gameObjectToDisable; // GameObject yang akan dinonaktifkan jika input field memiliki nilai

    public void OnButtonClick()
    {
        // Memeriksa apakah input field memiliki nilai (tidak kosong)
        bool hasValue = !string.IsNullOrEmpty(inputFieldToCheck.text);

        // Mengaktifkan atau menonaktifkan GameObject berdasarkan hasil pengecekan
        if (gameObjectToEnable != null)
        {
            gameObjectToEnable.SetActive(hasValue);
        }

        if (gameObjectToDisable != null)
        {
            gameObjectToDisable.SetActive(!hasValue);
        }
    }
}
