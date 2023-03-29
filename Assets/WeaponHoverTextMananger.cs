using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponHoverTextMananger : MonoBehaviour
{

    public TextMeshProUGUI weaponNameText;
    public TextMeshProUGUI weaponDescriptionText;
    public TextMeshProUGUI weaponCreatorsText;

    public LayerMask interactableLayers;

    public GameObject backdrop;

    // Start is called before the first frame update
    void Start()
    {
        backdrop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit info;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out info, 2, interactableLayers))
        {
            if (LayerMask.LayerToName(info.transform.gameObject.layer) == "Interactable" || LayerMask.LayerToName(info.transform.gameObject.layer) == "InteractableNoPlayerCollide")
            {

                if (info.collider.gameObject.tag == "WeaponHoverStand")
                {
                    backdrop.SetActive(true);

                    WeaponInfo weaponInfo = info.collider.gameObject.GetComponent<PickupWeapon>().currentWeaponInfo;
                    weaponNameText.text = weaponInfo.displayName;
                    weaponDescriptionText.text = weaponInfo.description;
                    if (weaponInfo.credits != null) { 
                        weaponCreatorsText.text = weaponInfo.credits.Replace("*", System.Environment.NewLine);
                    }
                    else
                    {
                        weaponCreatorsText.text = "Anonymous";
                    }
                }
                else
                {
                    backdrop.SetActive(false);
                }
            }
            else
            {
                backdrop.SetActive(false);
            }   
        }
        else
        {
            backdrop.SetActive(false);
        }
    }
}
