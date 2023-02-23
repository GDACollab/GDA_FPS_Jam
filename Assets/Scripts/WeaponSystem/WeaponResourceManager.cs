using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.PlayerSettings;

[System.Serializable]
public class WeaponInfo
{
    public string id;
    public string weaponPrefabPath;
    public string meshPath;
    public string displayName;
    public string description;

    public WeaponInfo(string _id, string _weaponPrefabPath, string _meshPath, string _displayName, string _description)
    {
        this.id = _id;
        this.weaponPrefabPath = _weaponPrefabPath;
        this.meshPath = _meshPath;
        this.displayName = _displayName;
        this.description = _description;
    }
}

public class WeaponResourceManager : UnitySingleton<WeaponResourceManager>
{

    public List<WeaponInfo> allFoundWeaponsInfo = new List<WeaponInfo>();
    [SerializeField] private GameObject interactableWeaponSwapPrefab;
    private Vector3 latestWeaponSwapPosition = Vector3.zero;
    [SerializeField] private Vector3 offset = Vector3.zero;

    [SerializeField] private float radius = 3f;
    [SerializeField] private float angleRateOfChange = 3f;
    private float angleOfSpawn = 0f;

    public override void Awake()
    {
        base.Awake();
        FindAllResourceWeapons();
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnInteractableResourceWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FindAllResourceWeapons()
    {
        var allWeaponInfo = Resources.LoadAll("", typeof(TextAsset)).Cast<TextAsset>().ToArray();
        foreach (var t in allWeaponInfo)
        {
            if(t.name == "weapon_info")
            {
                allFoundWeaponsInfo.Add(JsonUtility.FromJson<WeaponInfo>(t.text));
            }
            
        }
            
    }

    void SpawnInteractableResourceWeapons()
    {
        foreach(WeaponInfo w in allFoundWeaponsInfo)
        {
            Vector3 newSpawnPoint = Vector3.zero;

            newSpawnPoint.x = (radius * Mathf.Cos(angleOfSpawn / (180f / Mathf.PI)));
            newSpawnPoint.y = transform.position.y;
            newSpawnPoint.z = (radius * Mathf.Sin(angleOfSpawn / (180f / Mathf.PI)));

            GameObject newSwapper = Instantiate(interactableWeaponSwapPrefab, transform);
            newSwapper.transform.localPosition = newSpawnPoint;
            angleOfSpawn += angleRateOfChange;

            newSwapper.GetComponent<PickupWeapon>().currentWeaponInfo = w;
            newSwapper.GetComponent<PickupWeapon>().weaponPrefab = (Resources.Load(w.weaponPrefabPath, typeof(GameObject)) as GameObject);
            newSwapper.GetComponent<PickupWeapon>().SetMesh((Resources.Load(w.meshPath, typeof(GameObject)) as GameObject));
        }
    }

    public WeaponInfo FindWeaponInfoByID(string id)
    {
        foreach (WeaponInfo w in allFoundWeaponsInfo)
        {
            if(w.id == id)
            {
                return w;
            }
        }

        return null;
    }

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.up, radius);
    }
}
