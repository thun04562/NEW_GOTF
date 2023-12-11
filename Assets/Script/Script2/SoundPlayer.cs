using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
  // Button Audio
  public void Click()
  {
    MySound.Instance.SFXPlay(AudioPlay.Click);
  }
    public void Hover()
    {
        MySound.Instance.SFXPlay(AudioPlay.Hover);
    }
}
