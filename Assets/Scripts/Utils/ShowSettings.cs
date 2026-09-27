using UnityEngine;

public class ShowSettings : MonoBehaviour
{
   public void ShowSettingsObject(GameObject settingsUI)
    {
         settingsUI.SetActive(true);
    }

    public void HideSettingsObject(GameObject settingsUI)
    {
        settingsUI.SetActive(false);
    }
}
