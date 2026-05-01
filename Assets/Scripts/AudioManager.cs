using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource spinSource;
    public AudioSource stopSource;
    public AudioSource winSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySpin()
    {
        spinSource.loop = true;
        spinSource.Play();
    }

    public void StopSpin()
    {
        spinSource.Stop();
    }

    public void PlayStop()
    {
        stopSource.PlayOneShot(stopSource.clip);
    }

    public void PlayWin()
    {
        winSource.PlayOneShot(winSource.clip);
    }
}