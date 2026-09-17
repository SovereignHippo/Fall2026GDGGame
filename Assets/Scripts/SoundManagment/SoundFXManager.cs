using Unity.Mathematics;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;
    [SerializeField] private AudioSource soundFXObject;
    
    public float masterAudioVolume = 1f;
    private void Awake()
    {
        Instance = Instance != null ? Instance : this;
    }
    

    public void PlaySoundFXClip(AudioClip clip, float volume = 1f)
    {
        Transform sourceTransform = Camera.main.gameObject.transform;

        AudioSource audioSource = Instantiate(soundFXObject, sourceTransform.position, quaternion.identity);

        audioSource.clip = clip;
        audioSource.volume = volume * masterAudioVolume;
        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }

      public void PlayRandomSoundFXClip(AudioClip[] clip, float volume)
    {
        Transform sourceTransform = Camera.main.gameObject.transform;

        int rand = UnityEngine.Random.Range(0, clip.Length);
        AudioSource audioSource = Instantiate(soundFXObject, sourceTransform.position, quaternion.identity);

        audioSource.clip = clip[rand];
        audioSource.volume = volume * masterAudioVolume;
        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }
}
