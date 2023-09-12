using UnityEngine;
using TMPro;

public class CheckEndpoints : MonoBehaviour
{
    public GameObject nullEndpointsPopup; // Referensi ke objek popup untuk endpoint bernilai null

    private void Start()
    {
        // Matikan popup pada awalnya
        nullEndpointsPopup.SetActive(false);

        // Pengecekan saat Start
        CheckAndShowPopup();
    }

    public void CheckAndShowPopup()
    {
        string imageEndpoint = PlayerPrefs.GetString("ImageEndPoint");
        string databaseEndpoint = PlayerPrefs.GetString("DatabaseEndPoint");
        string databaseEndpoint2 = PlayerPrefs.GetString("DatabaseEndPoint2"); // Tambahkan ini untuk DatabaseEndPoint2

        bool hasNullEndpoints = string.IsNullOrEmpty(imageEndpoint) || string.IsNullOrEmpty(databaseEndpoint) || string.IsNullOrEmpty(databaseEndpoint2);

        if (hasNullEndpoints)
        {
            Debug.Log("Satu atau lebih endpoint bernilai null atau kosong.");
            nullEndpointsPopup.SetActive(true);
        }
        else
        {
            Debug.Log("Semua endpoint memiliki nilai.");
            nullEndpointsPopup.SetActive(false);
        }
    }
}
