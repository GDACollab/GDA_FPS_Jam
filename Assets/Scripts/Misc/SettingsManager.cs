using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SettingsManager : MonoBehaviour
{
    // Settings
    public float Volume;
    public float FOV;
    public float Sensitivity;

    // Trackers
    public bool settingsOpen = false;
    float oldTimeScale;

    // Dependenices 
    public PlayerController player;
    public GameObject settingsUICanvas;
    public AudioMixer audioMixer;
    public GameObject volumeSlider;
    public GameObject fovSlider;
    public GameObject sensitivitySlider;

    TextMeshProUGUI volumeText;
    TextMeshProUGUI fovText;
    TextMeshProUGUI sensitivityText;

    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    private void Start()
    {
        settingsUICanvas.SetActive(false);
        volumeText = volumeSlider.GetComponent<TextMeshProUGUI>();
        fovText = fovSlider.GetComponent<TextMeshProUGUI>();
        sensitivityText = sensitivitySlider.GetComponent<TextMeshProUGUI>();

        // Set default Volume
        audioMixer.SetFloat("MasterVolume", (Mathf.Log10(Volume)*20));
        volumeText.text = (Volume*100).ToString("0")+"%";
        volumeSlider.GetComponent<Slider>().value = Volume;

        // Set default FOV
        fovText.text = FOV.ToString("0");
        fovSlider.GetComponent<Slider>().value = FOV;

        // Set default sensitivity
        sensitivityText.text = Sensitivity.ToString("0");
        sensitivitySlider.GetComponent<Slider>().value = Sensitivity;
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            toggleUI();
        }
    }

    public void SetVolume(float Volume)
    {
        audioMixer.SetFloat("MasterVolume", (Mathf.Log10(Volume) * 20));
        this.Volume = Volume;
        volumeText.text = (Volume * 100).ToString("0") + "%";
    }

    public void SetFov(float FOV)
    {
        this.FOV = FOV;
        fovText.text = FOV.ToString("0");
        if (PlayerController.Instance != null)
        {
            PlayerController.Instance.UpdateBaseFOV(this.FOV);
        }
    }

    public void SetSensitivity(float sensitivity)
    {
        this.Sensitivity = sensitivity;
        sensitivityText.text = sensitivity.ToString("0");
        if (PlayerController.Instance != null)
        {
            PlayerController.Instance.SetSensitivity((this.Sensitivity / 5) * 2);
        }

    }

    public void toggleUI()
    {
        settingsOpen = !settingsOpen;

        if (settingsOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            oldTimeScale = Time.timeScale;
            Time.timeScale = 0;
            if (player != null)
            {
                player.canControlMovement = false;
            }
            Cursor.visible = true;

            settingsUICanvas.SetActive(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = oldTimeScale;
            if (player != null)
            {
                player.canControlMovement = false;
            }
            Cursor.visible = false;

            settingsUICanvas.SetActive(false);
        }
    }
}
