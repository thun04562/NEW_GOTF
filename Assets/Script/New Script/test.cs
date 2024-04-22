using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class test : MonoBehaviour
{
    public List<GameObject> arrows = new List<GameObject>();
    public ArrowShoot currentArrow;

    public GameObject redArrow_Prefab;
    public GameObject greenArrow_Prefab;
    public GameObject blueArrow_Prefab;
    public GameObject yellowArrow_Prefab;
    private int index;
    PlayerAnimationArrowController arrowController;

    public Transform shootingPoint;

    private float timeBtwShots;
    private JSONNode jsonObject;
    public float startTimeBtwShots;

    private Dictionary<string, GameObject> arrowDataTable = new Dictionary<string, GameObject>();
    private List<string> stringIDs = new List<string>();

    private void OnValidate()
    {
        if (arrows.Count <= 0)
            arrows.Add(redArrow_Prefab);
    }

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
        currentArrow = arrows[0].GetComponent<ArrowShoot>();
        ArrowUIController.instane.changeImageGun(currentArrow.gun);
        arrowController = FindObjectOfType<PlayerAnimationArrowController>();

        arrowDataTable = GetData();

        InitData();
    }

    private void InitData()
    {
        foreach (GameObject _arrow in arrowDataTable.Values)
        {
            var _arrowScript = _arrow.GetComponent<ArrowShoot>();
            var _path = Application.persistentDataPath + "/" + _arrowScript.ID;
            
            LoadData(_path);
        }

        foreach (string _id in stringIDs)
        {
            if (arrowDataTable.ContainsKey(_id))
            {
                var _arrow = arrowDataTable[_id];
                arrows.Add(_arrow);
            }
        }

    }

    private Dictionary<string, GameObject> GetData()
    {
        Dictionary<string, GameObject> _arrowDataTable = new Dictionary<string, GameObject>();

        _arrowDataTable.Add("Red", redArrow_Prefab);
        _arrowDataTable.Add("Blue", blueArrow_Prefab);
        _arrowDataTable.Add("Green", greenArrow_Prefab);
        _arrowDataTable.Add("Yellow", yellowArrow_Prefab);

        return _arrowDataTable;
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

    public void BUYArrow(GameObject gameObject)
    {
        arrows.Add(gameObject);
        var _arrowShoot = gameObject.GetComponent<ArrowShoot>();
        Debug.Log(_arrowShoot.ID);

        SaveData(_arrowShoot);
    }

    private void SaveData(ArrowShoot _arrow)
    {
        string _filePath = Application.persistentDataPath + "/" + _arrow.ID;

        ArrowData _arrowData = new ArrowData();
        _arrowData.ID = _arrow.ID;



        string _json = JsonUtility.ToJson(_arrowData);
        File.WriteAllText(_filePath, _json);
    }

    private void LoadData(string _path)
    {
        if (File.Exists(_path))
        {
            string _jsonData = File.ReadAllText(_path);
            ArrowData _arrowData = JsonUtility.FromJson<ArrowData>(_jsonData);
            string _id = _arrowData.ID;

            Debug.Log(_id);
            arrows.Add(arrowDataTable[_id]);
        }
    }

    void ChangeArrow()
    {
        if (arrows.Count > 0)
        {
            index = index % arrows.Count;
            currentArrow = arrows[index].GetComponent<ArrowShoot>();
            ArrowUIController.instane.changeImageGun(currentArrow.gun);
            arrowController.ChangeArrowAnimation(currentArrow.name);
            index++;
        }
        else
        {
            Debug.LogError("No arrows in the list.");
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

public class ArrowData
{
    public string ID;
}

/*[System.Serializable]
class GunData
{
    public List<ArrowShoot> arrow;

}*/
