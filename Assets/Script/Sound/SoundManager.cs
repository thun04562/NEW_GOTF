using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }


    /*public static AudioClip jumpSound, deathSound, playerhurtSound, bloodSound, UiSound;
    static AudioSource audioSrc;
    void Start()
    {
        playerhurtSound = Resources.Load<AudioClip>("Hurt");
        jumpSound = Resources.Load<AudioClip>("Jump");
        deathSound = Resources.Load<AudioClip>("Death1");
        bloodSound = Resources.Load<AudioClip>("Blood");
        UiSound = Resources.Load<AudioClip>("UI0");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Hurt":
                audioSrc.PlayOneShot(playerhurtSound);
                break;
            case "Jump":
                audioSrc.PlayOneShot(jumpSound);
                audioSrc.volume = 0.02f;
                break;
            case "Death1":
                audioSrc.PlayOneShot(deathSound);
                break;
            case "Blood":
                audioSrc.PlayOneShot(bloodSound);
                audioSrc.volume = 0.03f;
                break;
            case "Button":
                audioSrc.PlayOneShot(UiSound);
                audioSrc.volume = 0.15f;
                break;
        }
    }*/
}
