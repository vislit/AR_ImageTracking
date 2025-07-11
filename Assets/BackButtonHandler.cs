using UnityEngine;

public class BackButtonHandler : MonoBehaviour
{
    public DragonSelector dragonSelector; // Inspector’dan atanacak

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKeyDown(KeyCode.Escape))
        {
            if (dragonSelector != null)
            {
                dragonSelector.BackToMenu();
            }
        }
    }
}
