using UnityEngine;
using UnityEngine.UI;

public class SetVolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider soundSlider;

    void Start()
    {
        soundSlider.value = PlayerPrefs.GetFloat("sound", 1f);
    }
    public void SetValue()
    {
        float SoundPersent = soundSlider.value;
        PlayerPrefs.SetFloat("sound", SoundPersent);
        PlayerPrefs.Save();
        if (SoundFXManager.Instance != null)
        {
            SoundFXManager.Instance.masterAudioVolume = SoundPersent;
        }
    }
}
