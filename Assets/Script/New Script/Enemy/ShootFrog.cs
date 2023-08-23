using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFrog : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
            frogShooting();
        }
    }

    void frogShooting()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
