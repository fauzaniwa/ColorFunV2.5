using UnityEngine;
using System.IO;
using System;
using UnityEngine.Networking;

public class CarouselScreenshot : MonoBehaviour
{
    public string uploadURL = "https://colorfun.registercepat.net/upload_image_colorfun.php";
    public string uploadURL2 = "https://dkvsaturasi.com/sampleproject/upload_image_colorfun.php"; // Tambahkan URL kedua
    public Camera camera2;

    public int maxRetries = 3;

    private void Start()
    {
        // Ambil nilai uploadURL dari PlayerPrefs jika tersedia
        if (PlayerPrefs.HasKey("ImageEndPoint"))
        {
            uploadURL = PlayerPrefs.GetString("ImageEndPoint");
        }
    }

    public string TakeScreenshot()
    {
        DateTime now = DateTime.Now;
        string dateTimeString = now.ToString("HHmmss_ddMMyyyy");

        string fileName = dateTimeString + ".jpg";

        int originalCullingMask = camera2.cullingMask;

        int screenshotLayer = LayerMask.NameToLayer("ScreenshotLayer");
        camera2.cullingMask = 1 << screenshotLayer;

        RenderTexture renderTexture = new RenderTexture(1920, 1080, 24);
        camera2.targetTexture = renderTexture;
        Texture2D screenShot = new Texture2D(1920, 1080, TextureFormat.RGB24, false);
        camera2.Render();
        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(new Rect(0, 0, 1920, 1080), 0, 0);
        camera2.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        camera2.cullingMask = originalCullingMask;

        StartCoroutine(UploadImageToBothURLs(fileName, screenShot, maxRetries));

        return fileName;
    }

    private System.Collections.IEnumerator UploadImageToBothURLs(string fileName, Texture2D image, int maxRetries)
    {
        int retryCount = 0;

        while (retryCount < maxRetries)
        {
            byte[] imageData = image.EncodeToPNG();

            WWWForm form = new WWWForm();
            form.AddField("imageName", fileName);
            form.AddBinaryData("image", imageData, fileName, "image/jpg");

            using (UnityWebRequest www1 = UnityWebRequest.Post(uploadURL, form))
            using (UnityWebRequest www2 = UnityWebRequest.Post(uploadURL2, form))
            {
                yield return www1.SendWebRequest();
                yield return www2.SendWebRequest();

                if (www1.result == UnityWebRequest.Result.Success && www2.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("Gambar berhasil diunggah ke kedua server!");
                    break;
                }
                else
                {
                    Debug.LogError("Gagal mengunggah gambar: " + www1.error + ", " + www2.error);
                    retryCount++;
                }
            }
        }

        if (retryCount >= maxRetries)
        {
            Debug.LogError("Gagal mengunggah gambar ke kedua server setelah " + maxRetries + " kali percobaan.");
        }
    }
}
