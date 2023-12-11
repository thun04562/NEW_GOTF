using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MySound : MonoBehaviour
{
  public static MySound Instance;
  [HideInInspector] public float bgmValue;
  [HideInInspector] public float sfxValue;
    public AudioMixer mixer;
  public AudioSource bgm;
    public List<AudioClip> audioClips = new List<AudioClip>();
  public List<AudioSource> audioSources = new List<AudioSource>();

  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
      Destroy(gameObject);
  }
    public void Start()
    {

    }
    public void PlayBGM()
  {
    bgm.Play();
  }
  public void PauseBGM()
  {
    bgm.Stop();
  }

  public void SFXPlay(AudioPlay play)
  {
    AudioSource audio = audioSources[0];
    audio.clip = audioClips[(int)play];
    audio.Play();
    audioSources.Remove(audio);
    audioSources.Add(audio);
  }
  public void BGMPlay(AudioPlay play)
  {
    bgm.clip = audioClips[(int)play];
    bgm.Play();
  }
  public void BGMSlider(float value)
  {
    mixer.SetFloat("bgm", Mathf.Log10(value) * 20);
    bgmValue = value;
  }
  public void SFXSlider(float value)
  {
    mixer.SetFloat("sfx", Mathf.Log10(value) * 20);
    sfxValue = value;
  }
}
public enum AudioPlay
{
    Click,
    Hover,
    Dead,
    Continue,
    MatchSizzle,
    Running,
    Accept,
    Complete,
    LevelUp,
    OpenBag,
    Getting,
    Success,
    Buy,
    HeartBeat,
    Title,
    Ending,
    AmbientPlay
}