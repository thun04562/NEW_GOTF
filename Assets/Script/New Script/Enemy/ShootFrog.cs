using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFrog : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private Animator anim;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
            StartCoroutine(frogShoot());

            //anim.SetBool("Shoot", true);
            //frogShooting();
        }
        
    }

    void frogShooting()
    {

        Instantiate(bullet, bulletPos.position, Quaternion.identity);

    }

    IEnumerator frogShoot()
    {
        anim.SetBool("Shoot", true);
        yield return new WaitForSeconds(1f);
        //frogShooting();
        anim.SetBool("Shoot", false);
    }
}
