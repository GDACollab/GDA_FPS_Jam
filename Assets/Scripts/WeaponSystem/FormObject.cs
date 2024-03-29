using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using NaughtyAttributes;

public class FormObject : MonoBehaviour
{
    [Tooltip("[IMPORTANT] The weapon ID for this weapon. This should match the 'id' in the weapon_info.json file in your weapon's folder.")]
    public string weaponID;
    [Expandable]
    [Tooltip("The primary form for this weapon. Attempts to run it's FormAction() on left click.")]
    public BaseForm primaryForm;
    [Expandable]
    [Tooltip("[OPTIONAL] The optional secondary form for this weapon. Attempts to run it's FormAction() on middle mouse button.")]
    public BaseForm secondaryForm;
    [Tooltip("The virtual camera that the weapon camera will swap to when the user aims down sights (right click).")]
    public CinemachineVirtualCamera ADSVirtualCamera;
    [Tooltip("The amount of FOV added or removed when aiming down sights on this weapon.")]
    public float ADSZoomModifier = 1;
    [Tooltip("The transform this weapon will spawn projectiles from.")]
    public Transform barrelSpawn;
    



    [HideInInspector] public float _currentPrimaryCooldown = 0;
    [HideInInspector] public float _currentSecondaryCooldown = 0;

    [HideInInspector] public float _currentPrimaryEnergy = 0;
    [HideInInspector] public float _currentSecondaryEnergy = 0;

    [HideInInspector] public float _currentPrimaryEnergyRegenTimer = 0;
    [HideInInspector] public float _currentSecondaryEnergyRegenTimer = 0;

    [HideInInspector] public bool _regenPrimaryEnergy = false;
    [HideInInspector] public bool _regenSecondaryEnergy = false;

    private bool _bothFormsShareEnergy = false;

    [Tooltip("The Cinemachine impulse source for this weapon. I wouldn't mess with this.")]
    [SerializeField] private CinemachineImpulseSource impulseSource;

    private void Start()
    {
        if(primaryForm != null)
        {
            InitializePrimaryEnergy();
        }

        if(secondaryForm != null)
        {
            InitializeSecondaryEnergy();
        }
    }

    private void Update()
    {
        DecrementTimers();
        RegenerateEnergy();
    }

    public void UpdateUI()
    {

    }

    void InitializePrimaryEnergy()
    {
        if (_bothFormsShareEnergy)
        {
            return;
        }

        if (primaryForm.shareEnergyWithOtherForm)
        {
            _bothFormsShareEnergy = true;
        }

        _currentPrimaryEnergy = primaryForm.energyMax;
        if(primaryForm.energyRegenType == BaseForm.EnergyRegenerationType.EmptyFullFill)
        {
            _regenPrimaryEnergy = false;
        }
        else
        {
            _regenPrimaryEnergy = true;
        }
    }

    void InitializeSecondaryEnergy()
    {
        if (_bothFormsShareEnergy)
        {
            return;
        }

        if (secondaryForm.shareEnergyWithOtherForm)
        {
            _bothFormsShareEnergy = true;
        }

        _currentSecondaryEnergy = secondaryForm.energyMax;
        if (secondaryForm.energyRegenType == BaseForm.EnergyRegenerationType.EmptyFullFill)
        {
            _regenSecondaryEnergy = false;
        }
        else
        {
            _regenSecondaryEnergy = true;
        }
    }

    bool CheckValidEnergy(int formIndex)
    {
        if(formIndex == 1 && _bothFormsShareEnergy)
        {
            formIndex = 2;
        }

        switch (formIndex)
        {
            case 0:

                if(primaryForm.energyType == BaseForm.EnergyUsage.Unlimited)
                {
                    return true;
                }

                if (_currentPrimaryEnergy - primaryForm.energyCost < 0)
                {
                    return false;
                }
                else
                {
                    _currentPrimaryEnergy -= primaryForm.energyCost;
                    WeaponPanelUIController.Instance.UpdateCurrentWeaponAmmoUI(this);

                    if (primaryForm.energyRegenType == BaseForm.EnergyRegenerationType.EmptyFullFill)
                    {
                        _regenPrimaryEnergy = (_currentPrimaryEnergy <= 0);
                    }

                    if (primaryForm.energyRegenType == BaseForm.EnergyRegenerationType.ConstantIncremental)
                    {
                        _currentPrimaryEnergyRegenTimer = primaryForm.energyRegenCooldown;
                    }

                    return true;
                }
            case 1:

                if (secondaryForm.energyType == BaseForm.EnergyUsage.Unlimited)
                {
                    return true;
                }

                if (_currentSecondaryEnergy - secondaryForm.energyCost < 0)
                {
                    return false;
                }
                else
                {
                    _currentSecondaryEnergy -= secondaryForm.energyCost;
                    WeaponPanelUIController.Instance.UpdateCurrentWeaponAmmoUI(this);

                    if (secondaryForm.energyRegenType == BaseForm.EnergyRegenerationType.EmptyFullFill)
                    {
                        _regenSecondaryEnergy = (_currentSecondaryEnergy <= 0);
                    }

                    if (secondaryForm.energyRegenType == BaseForm.EnergyRegenerationType.ConstantIncremental)
                    {
                        _currentSecondaryEnergyRegenTimer = secondaryForm.energyRegenCooldown;
                    }

                    return true;
                }
            case 2:

                if (primaryForm.energyType == BaseForm.EnergyUsage.Unlimited)
                {
                    return true;
                }

                if (_currentPrimaryEnergy - secondaryForm.energyCost < 0)
                {
                    return false;
                }
                else
                {
                    _currentPrimaryEnergy -= secondaryForm.energyCost;
                    WeaponPanelUIController.Instance.UpdateCurrentWeaponAmmoUI(this);

                    if (primaryForm.energyRegenType == BaseForm.EnergyRegenerationType.EmptyFullFill)
                    {
                        _regenPrimaryEnergy = (_currentPrimaryEnergy <= 0);

                    }

                    if(primaryForm.energyRegenType == BaseForm.EnergyRegenerationType.ConstantIncremental)
                    {
                        _currentPrimaryEnergyRegenTimer = primaryForm.energyRegenCooldown;
                    }

                    return true;
                }
            default:
                return false;
        }

        
    }

    void RegenerateEnergy()
    {
        if (_regenPrimaryEnergy)
        {
            switch (primaryForm.energyRegenType) {
                case BaseForm.EnergyRegenerationType.ConstantFullFill:
                    WeaponPanelUIController.Instance.UpdateCurrentWeaponAmmoUI(this);
                    break;
                case BaseForm.EnergyRegenerationType.ConstantIncremental:
                    _currentPrimaryEnergy += primaryForm.energyRegenRate * Time.deltaTime;
                    _currentPrimaryEnergy = Mathf.Clamp(_currentPrimaryEnergy, 0, primaryForm.energyMax);
                    WeaponPanelUIController.Instance.UpdateCurrentWeaponAmmoUI(this);
                    break;
                case BaseForm.EnergyRegenerationType.EmptyFullFill:
                    StartCoroutine(FillEnergy(0));
                    _regenPrimaryEnergy = false;
                    break;
            
            }
            
        }

        if (primaryForm.shareEnergyWithOtherForm || secondaryForm.shareEnergyWithOtherForm)
        {
            return;
        }

        if (_regenSecondaryEnergy)
        {
            switch (secondaryForm.energyRegenType)
            {
                case BaseForm.EnergyRegenerationType.ConstantFullFill:
                    WeaponPanelUIController.Instance.UpdateCurrentWeaponAmmoUI(this);
                    break;
                case BaseForm.EnergyRegenerationType.ConstantIncremental:
                    _currentSecondaryEnergy += secondaryForm.energyRegenRate * Time.deltaTime;
                    _currentSecondaryEnergy = Mathf.Clamp(_currentSecondaryEnergy, 0, secondaryForm.energyMax);
                    WeaponPanelUIController.Instance.UpdateCurrentWeaponAmmoUI(this);
                    break;
                case BaseForm.EnergyRegenerationType.EmptyFullFill:
                    StartCoroutine(FillEnergy(1));
                    _regenSecondaryEnergy = false;
                    break;

            }
        }
    }

    IEnumerator FillEnergy(int formIndex)
    {
        switch (formIndex) {
            case 0:
                yield return new WaitForSeconds(primaryForm.energyRegenCooldown);
                _currentPrimaryEnergy = primaryForm.energyMax;
                
                break;
            case 1:
                yield return new WaitForSeconds(secondaryForm.energyRegenCooldown);
                _currentSecondaryEnergy = secondaryForm.energyMax;
                
                break;
        }

        WeaponPanelUIController.Instance.UpdateCurrentWeaponAmmoUI(this);

        yield return new WaitForSeconds(1);
    }

    public bool UsePrimaryAction(float context)
    {
        if(primaryForm == null)
        {
            return false;
        }

        if (_currentPrimaryCooldown > 0 || !CheckValidEnergy(0))
        {
            return false;
        }

        if (primaryForm.firingType == BaseForm.FireType.Auto)
        {
            _currentPrimaryCooldown = primaryForm.actionCooldown;
            primaryForm.FormAction(context);

        }
        else if (primaryForm.firingType == BaseForm.FireType.Semi)
        {
            _currentPrimaryCooldown = primaryForm.actionCooldown;
            primaryForm.FormAction(context);
        }
        else if (primaryForm.firingType == BaseForm.FireType.Hold)
        {
            _currentPrimaryCooldown = primaryForm.actionCooldown;
            primaryForm.FormAction(context);

        }


        GeneratePrimaryImpulse();

        return true;

    }



    public bool UseSecondaryAction(float context)
    {
        if(secondaryForm == null)
        {
            return false;
        }

        if (_currentSecondaryCooldown > 0 || !CheckValidEnergy(1))
        {
            return false;
        }

        if (secondaryForm.firingType == BaseForm.FireType.Auto)
        {
            _currentSecondaryCooldown = secondaryForm.actionCooldown;
            secondaryForm.FormAction(context);
        }
        else if (secondaryForm.firingType == BaseForm.FireType.Semi)
        {
            _currentSecondaryCooldown = secondaryForm.actionCooldown;
            secondaryForm.FormAction(context);
        }
        else if (secondaryForm.firingType == BaseForm.FireType.Hold)
        {
            _currentSecondaryCooldown = secondaryForm.actionCooldown;
            secondaryForm.FormAction(context);
        }

        GenerateSecondaryImpulse();

        return true;
    }

    void GeneratePrimaryImpulse()
    {
        if (primaryForm.screenShakeImpulseDirection == Vector3.zero)
        {
            impulseSource.GenerateImpulse(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * primaryForm.screenShakeImpulseMagnitude);
        }
        else
        {
            impulseSource.GenerateImpulse(primaryForm.screenShakeImpulseDirection * primaryForm.screenShakeImpulseMagnitude);
        }
    }

    void GenerateSecondaryImpulse()
    {
        if (secondaryForm.screenShakeImpulseDirection == Vector3.zero)
        {
            impulseSource.GenerateImpulse(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * secondaryForm.screenShakeImpulseMagnitude);
        }
        else
        {
            impulseSource.GenerateImpulse(secondaryForm.screenShakeImpulseDirection * secondaryForm.screenShakeImpulseMagnitude);
        }
    }
    void DecrementTimers()
    {
        if (_currentPrimaryCooldown > 0)
        {
            _currentPrimaryCooldown -= Time.deltaTime;
        }

        if (_currentSecondaryCooldown > 0)
        {
            _currentSecondaryCooldown -= Time.deltaTime;
        }

        if (_currentPrimaryEnergyRegenTimer > 0)
        {
            _currentPrimaryEnergyRegenTimer -= Time.deltaTime;
            _regenPrimaryEnergy = (_currentPrimaryEnergyRegenTimer < 0);
        }

        if (_currentSecondaryEnergyRegenTimer > 0)
        {
            _currentSecondaryEnergyRegenTimer -= Time.deltaTime;
            _regenSecondaryEnergy = (_currentSecondaryEnergyRegenTimer < 0);
        }


    }






}
