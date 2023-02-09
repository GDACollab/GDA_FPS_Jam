using UnityEngine;
using UnityEngine.VFX;
using System.Collections;

public class VFX_SPAWN : MonoBehaviour
{
    public bool IsPlaying = true;
    public bool loadingStarted = true;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsPlaying = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsPlaying = false;
        }

        if (IsPlaying && FormController.Instance.FiredGun &&!FormController.Instance._isReloading)
        {
            GetComponent<VisualEffect>().Play();
        }
        else
        {
            GetComponent<VisualEffect>().Stop();
        }
    }
}