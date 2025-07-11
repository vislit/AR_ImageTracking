using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;  // backToMenuButton için



public class DragonSelector : MonoBehaviour
{
    public GameObject backToMenuButton;  // Inspector’dan atanacak

    public GameObject joystick; // Joystick GameObject’ini Inspector’dan atayacağız
    public GameObject[] dragonPrefabs; // Inspector’dan 4 ejderhayı buraya atacağız
    public GameObject selectionPanel;  // Inspector’dan UI panelini buraya atacağız

    private GameObject spawnedDragon;
    private ARTrackedImage trackedImage; // Tarama yapıldıktan sonra referans alınacak

    // Butonlardan çağrılacak
    public void SelectDragon(int index)
    {
        if (spawnedDragon != null)
            Destroy(spawnedDragon);

        if (trackedImage != null)
        {
            spawnedDragon = Instantiate(
            dragonPrefabs[index],
            trackedImage.transform.position + new Vector3(0, 0.001f, 0), //ejdeha hafif zeminden yukarı spawnlanır
            trackedImage.transform.rotation);
        }

        selectionPanel.SetActive(false); // Seçim tamamlandı, paneli kapat
        joystick.SetActive(true); // Seçim tamamlandı, joystick geri gelsin
        backToMenuButton.SetActive(true);
        
    }

    // Tarama yapıldıktan sonra taranan görsel referansını ver
    public void SetTrackedImage(ARTrackedImage image)
    {
        trackedImage = image;
        selectionPanel.SetActive(true); // Paneli aç
        joystick.SetActive(false); //Joystick'i gizle
    }

    private void Start()
    {
        selectionPanel.SetActive(false);
        joystick.SetActive(true);           // başta joystick açık
        backToMenuButton.SetActive(false);  // ilk başta görünmesin!

        // ÖNEMLİ: Butona dinleyici ekle
        backToMenuButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(BackToMenu);
        
    }


    public void BackToMenu()
    {
        // Ejderha varsa sahneden kaldır
        if (spawnedDragon != null)
        Destroy(spawnedDragon);

        // Sadece selection paneli geri getir
        selectionPanel.SetActive(true);
        joystick.SetActive(false);
        backToMenuButton.SetActive(false);

        trackedImage = null; // Yeniden tarama yapabilsin diye
    }
}

