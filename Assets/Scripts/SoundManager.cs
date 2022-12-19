using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager inst;

    [SerializeField] AudioClip onMouseOver;
    [SerializeField] AudioClip onClick;

    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        inst = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOnMouseOverSound()
    {
        audioSource.clip = onMouseOver;
        audioSource.Play(); 
    }

    public void PlayOnClickSound()
    {
        audioSource.clip = onClick;
        audioSource.Play();
    }

}
