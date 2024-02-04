using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class test : MonoBehaviour
{
    public List<ArrowShoot> arrows = new List<ArrowShoot>();
    public ArrowShoot currentArrow;

    public ArrowShoot redArrow_Prefab;
    public ArrowShoot greenArrow_Prefab;
    public ArrowShoot blueArrow_Prefab;
    public ArrowShoot yellowArrow_Prefab;
    private int index;
    PlayerAnimationArrowController arrowController;

    public Transform shootingPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

 

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
        ArrowUIController.instane.changeImageGun(currentArrow.gun);
        arrowController = FindObjectOfType<PlayerAnimationArrowController>();

    }

    private void Update()
    {
        if(timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeArrow();
            
        }

        /*if (Input.GetKeyDown(KeyCode.H))
        {
            SaveGun();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGun();
        }*/

        /*if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }*/
    }

    public void BUYArrow(ArrowShoot gameObject)
    {
        arrows.Add(gameObject);
    }

   

    void ChangeArrow()
    {

        if (index < arrows.Count)
        {
            currentArrow = arrows[index];
            ArrowUIController.instane.changeImageGun(currentArrow.gun);
            arrowController.ChangeArrowAnimation(currentArrow.name);
            index++;
        }
        else
        {
            currentArrow = arrows[0];
            ArrowUIController.instane.changeImageGun(currentArrow.gun);
            arrowController.ChangeArrowAnimation(currentArrow.name);
            index = 0;
        }



    }

    
    void Shoot()
    {
        var bullet = Instantiate(currentArrow);
        bullet.transform.position = shootingPoint.position;
        bullet.transform.localRotation = shootingPoint.rotation;
        bullet.GetComponent<ArrowShoot>().Initialized();
        
        timeBtwShots = startTimeBtwShots;
    }


    /*public void SaveGun()
    {
        GunData data = new GunData();
        data.arrow = arrows;

        ///
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText("/arrowData", jsonData);
        Debug.Log("gun data saved" + Application.persistentDataPath);
    }

    public void LoadGun()
    {
        if (File.Exists("/arrowData"))
        {
            string jsonData = File.ReadAllText("/arrowData");
            GunData data = JsonUtility.FromJson<GunData>(jsonData);
            arrows = data.arrow;

        }
        else
        {
            Debug.LogWarning("mai dai No data found");
        }
    }*/

}

/*[System.Serializable]
class GunData
{
    public List<ArrowShoot> arrow;

}*/
