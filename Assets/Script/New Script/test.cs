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
        var _redArrow = redArrow_Prefab.GetComponent<ArrowShoot>();
        currentArrow = _redArrow;
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

            if (Path.Combine(Application.persistentDataPath, "/" + _arrowScript.ID + ".json") != null)
                LoadData(_arrowScript.ID, Path.Combine(Application.persistentDataPath, "/" + _arrowScript.ID + ".json"));
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
        SaveData(_arrowShoot);
    }

    private void SaveData(ArrowShoot _arrow)
    {
        string _filePath = Path.Combine(Application.persistentDataPath, "/" + _arrow.ID + ".json");
        if (!Directory.Exists(Application.streamingAssetsPath))
            Directory.CreateDirectory(Application.streamingAssetsPath);

        File.WriteAllText(_filePath, _arrow.ID);
    }

    private void LoadData(string _arrowID, string _path)
    {
        Debug.Log(_path);
        string _data = File.ReadAllText(_path);
        stringIDs.Add(_data);

    }

    void ChangeArrow()
    {
        if (index < arrows.Count)
        {
            currentArrow = arrows[index].GetComponent<ArrowShoot>();
            ArrowUIController.instane.changeImageGun(currentArrow.gun);
            arrowController.ChangeArrowAnimation(currentArrow.name);
            index++;
        }
        else
        {
            currentArrow = arrows[0].GetComponent<ArrowShoot>();
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
