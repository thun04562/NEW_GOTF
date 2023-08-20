using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShowText : MonoBehaviour
{
    public GameObject gb;

    public string sceneName;
    private void Update()
    {
        
            gb.SetActive(false);

            if (Input.GetKeyDown(KeyCode.W))
            {
                //Sec.instance.Showtime();
                SceneManager.LoadScene(sceneName);
            }
   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gb.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gb.SetActive(false);
        }

    }
}
