using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public List<GameObject> arrows = new List<GameObject>();
    public GameObject currentArrow;

    public GameObject redArrow_Prefab;
    public GameObject greenArrow_Prefab;
    public GameObject blueArrow_Prefab;
    public GameObject yellowArrow_Prefab;
    private int index;
    PlayerAnimationArrowController arrowController;

    public Transform shootingPoint;



    public enum ArrowType
    {
        RedArrow,
        GreenArrow,
        BlueArrow,
        YellowArrow
    }

    public ArrowType type;

    private void Start()
    {
        currentArrow = redArrow_Prefab;
        arrowController = FindObjectOfType<PlayerAnimationArrowController>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeArrow();
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void BUYArrow(GameObject gameObject)
    {
        arrows.Add(gameObject);
    }

   

    void ChangeArrow()
    {

        if (index < arrows.Count)
        {
            currentArrow = arrows[index];
            arrowController.ChangeArrowAnimation(currentArrow.name);
            index++;
        }
        else
        {
            currentArrow = arrows[0];
            arrowController.ChangeArrowAnimation(currentArrow.name);
            index = 0;
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(currentArrow);
        bullet.transform.position = shootingPoint.position;
        bullet.transform.localRotation = shootingPoint.rotation;
        bullet.GetComponent<ArrowShoot>().Initialized();
    }
}