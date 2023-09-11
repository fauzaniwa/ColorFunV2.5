using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.UI;

public class UploadImage2 : MonoBehaviour
{
    private CarouselScreenshot carouselScreenshot;
    public string phpEndpointSaveData = "https://dkvsaturasi.com/sampleproject/simpan_data_message.php"; // Hilangkan [SerializeField] agar nilai dapat diubah oleh PlayerPrefs
    public string phpEndpointSaveData2 = "https://dkvsaturasi.com/sampleproject/simpan_data_message.php";

    public GameObject saveButton;
    [SerializeField]
    private GameData gameData;

    private void Start()
    {
        carouselScreenshot = GameObject.FindObjectOfType<CarouselScreenshot>();

        // Mendapatkan nilai dari PlayerPrefs untuk phpEndpointSaveData
        phpEndpointSaveData = PlayerPrefs.GetString("DatabaseEndPoint2", phpEndpointSaveData);

        if (saveButton != null)
        {
            Button buttonComponent = saveButton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.AddListener(OnSaveButtonClicked);
            }
            else
            {
                Debug.LogError("Komponen Button tidak ditemukan pada objek SaveButton!");
            }
        }
        else
        {
            Debug.LogError("Objek SaveButton belum di-set di inspector Unity!");
        }
    }

    private void OnSaveButtonClicked()
    {
        if (carouselScreenshot != null)
        {
            string imageName = carouselScreenshot.TakeScreenshot();

            if (gameData != null)
            {
                string nama = gameData.currentAuthor;
                string receiver = gameData.currentReceiver; // Tambahkan baris ini
                string menfess = gameData.currentMenfess;   // Tambahkan baris ini

                Debug.Log("Nama yang akan disimpan: " + nama);
                Debug.Log("Receiver yang akan disimpan: " + receiver); // Tambahkan baris ini
                Debug.Log("Menfess yang akan disimpan: " + menfess);   // Tambahkan baris ini

                StartCoroutine(InsertDataToMySQLWithRetry(imageName, nama, receiver, menfess, maxRetries: 3));
            }
            else
            {
                Debug.LogError("Objek GameData belum di-set di inspector Unity!");
            }
        }
        else
        {
            Debug.LogError("Objek CarouselScreenshot belum diinisialisasi!");
        }
    }

    private System.Collections.IEnumerator InsertDataToMySQLWithRetry(string imageName, string nama, string receiver, string menfess, int maxRetries)
    {
        int retryCount = 0;
        bool success1 = false;
        bool success2 = false;

        while (retryCount < maxRetries && (!success1 || !success2))
        {
            WWWForm form = new WWWForm();
            form.AddField("imageName", imageName);
            form.AddField("nama", nama);
            form.AddField("receiver", receiver); // Tambahkan baris ini
            form.AddField("menfess", menfess);   // Tambahkan baris ini

            UnityWebRequest www1 = UnityWebRequest.Post(phpEndpointSaveData, form);
            UnityWebRequest www2 = UnityWebRequest.Post(phpEndpointSaveData2, form);

            AsyncOperation op1 = www1.SendWebRequest();
            AsyncOperation op2 = www2.SendWebRequest();

            while (!op1.isDone || !op2.isDone)
            {
                yield return null;
            }

            if (www1.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Data berhasil disimpan ke database (phpEndpointSaveData)!");
                success1 = true;
            }
            else
            {
                Debug.LogError("Gagal menyimpan data ke database (phpEndpointSaveData): " + www1.error);
                retryCount++;
            }

            if (www2.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Data berhasil disimpan ke database (phpEndpointSaveData2)!");
                success2 = true;
            }
            else
            {
                Debug.LogError("Gagal menyimpan data ke database (phpEndpointSaveData2): " + www2.error);
                retryCount++;
            }
        }

        if (!success1 && !success2)
        {
            Debug.LogError("Gagal menyimpan data ke kedua endpoint setelah " + maxRetries + " kali percobaan.");
        }
    }
}
