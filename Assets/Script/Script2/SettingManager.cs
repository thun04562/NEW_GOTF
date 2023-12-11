using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public GameObject settingUI;
  public Slider bgm;
  public Slider sfx;
  void Start()
  {

  }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CloseUI();
        }
    }
    // button function
    public void OpenUI()
    {
        settingUI.SetActive(true);
    }
    public void CloseUI()
  {
    settingUI.SetActive(false);
  }

  // sliders function
  public void BGMControl()
  {
        MySound.Instance.BGMSlider(bgm.value);
    }
  public void SFXControl()
  {
        MySound.Instance.SFXSlider(sfx.value);
    }
    private void OnDestroy()
    {
        MySound.Instance.PauseBGM();
    }
}
