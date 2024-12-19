using UnityEngine;
using System.Collections;

public class SoundsManager : MonoBehaviour
{
  
    public AudioSource MenuButtonAudioSource;
    public AudioSource Pickup;
    public AudioSource Point;
    public AudioSource GameOver;

    public static bool audioEnabled;



    public static SoundsManager instance;

    bool cannotExecuteSound;
    float timeToBePaused = 0.1f;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlayAudioSource(AudioSource audioSource)
    {

        audioSource.Play();

    }

    IEnumerator CanExecuteCountDown()
    {
        cannotExecuteSound = true;
        yield return new WaitForSeconds(timeToBePaused);
        cannotExecuteSound = false;
    }



    public void PlayMenuButtonSound()
    {
        if (cannotExecuteSound) return;
        MenuButtonAudioSource.Play();
    }
    public void PlayPickupSound()
    {
        if (cannotExecuteSound) return;

        Pickup.Play();
    }

public void PlayPointSound()
    {
        if (cannotExecuteSound) return;

        Point.Play();
}


    public void PlayGameOverSound()
    {
        if (cannotExecuteSound) return;

        GameOver.Play();
    }


}


