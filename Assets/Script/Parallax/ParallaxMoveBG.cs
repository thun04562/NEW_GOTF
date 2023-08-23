using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ParallaxMoveBG : MonoBehaviour
{
    [SerializeField]
    private float parallaxSpeed;

    private Transform cameraTransform;
    private float startPositionX;
    private float spriteSizeX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        startPositionX = transform.position.x;
        spriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float relativeDist = cameraTransform.position.x * parallaxSpeed;
        transform.position = new Vector3(startPositionX + relativeDist, transform.position.y, transform.position.z);


        //loop
        float relativeCameraDist = cameraTransform.position.x * (1 - parallaxSpeed);
        if(relativeCameraDist > startPositionX + spriteSizeX)
        {
            startPositionX += spriteSizeX;
        }

        else if (relativeCameraDist < startPositionX - spriteSizeX)
        {
            startPositionX -= spriteSizeX;
        }
    }

    /*private float lenght;
    private float startPos;
    private GameObject cam;
    [SerializeField] private float parallaxEffect;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("CM vcam1");
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if(temp > startPos + lenght)
        {
            startPos += lenght;
        }
        else if (temp < startPos - lenght)
        {
            startPos -= lenght;
        }
    }*/

}
