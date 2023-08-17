using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;
using TMPro;

public class QRCodeGeneratorScript : MonoBehaviour
{
    public RawImage qrCodeImage;
    public string qrCodeData = ""; // Data yang ingin diubah menjadi QR code
    public string urlPrefix = "https://dkvsaturasi.com/sampleproject/halaman_gambar.php?nama_file="; // URL Prefix sebelum nama file

    private Texture2D qrCodeTexture;

    private void Start()
    {
        GenerateQRCode();
    }

    public void GenerateQRCode()
    {
        // Pastikan qrCodeData tidak null atau kosong
        if (string.IsNullOrEmpty(qrCodeData))
        {
            Debug.LogError("Data untuk QR code belum diatur!");
            return;
        }

        // Kombinasi URL dengan nama file gambar
        string fullURL = urlPrefix + qrCodeData;

        // Membuat barcode writer untuk QR code
        BarcodeWriter barcodeWriter = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Width = 256, // Lebar QR code (pengaturan resolusi)
                Height = 256, // Tinggi QR code (pengaturan resolusi)
            }
        };

        // Encode data (imageName) menjadi QR code
        Color32[] qrCodePixels = barcodeWriter.Write(fullURL);

        // Membuat texture baru dan mengisi dengan data QR code
        qrCodeTexture = new Texture2D(barcodeWriter.Options.Width, barcodeWriter.Options.Height);
        qrCodeTexture.SetPixels32(qrCodePixels);
        qrCodeTexture.Apply();

        // Menampilkan QR code pada RawImage
        qrCodeImage.texture = qrCodeTexture;
    }

    // Contoh untuk mengubah data QR code saat diperlukan
    public void UpdateQRCodeData(string newData)
    {
        qrCodeData = newData;
        GenerateQRCode();
    }
}
