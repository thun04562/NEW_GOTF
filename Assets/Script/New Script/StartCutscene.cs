using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public GameObject UI;
    public static bool isCutsceneOn;
    public Animator camAnim;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isCutsceneOn = true;
            camAnim.SetBool("cutscene1",true);
            Invoke(nameof(StopCutscene), 2.5f);
        }
    }

    void StopCutscene()
    {
        isCutsceneOn = false;
        camAnim.SetBool("cutscene1", false);
        Destroy(gameObject);
        UI.SetActive(true);
        
    }
}
