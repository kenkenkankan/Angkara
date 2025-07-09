using System;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : Menu, IDataPersistence
{
    // [SerializeField] private TMP_Dropdown resolutionDropdown;
    [Header("Menu Navigation")]
    [SerializeField] private Menu otherMenu;
    private PauseMenu pauseMenu;

    private int calledIndex;

    private Resolution[] resolutions;

    public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    // void Awake()
    // {   
    //     resolutions = Screen.resolutions;
    //     List<string> options = new();
    //     resolutionDropdown.ClearOptions();

    //     int currentResolutionIndex = 0;

    //     // Read pc resolution list
    //     foreach(var resolution in resolutions.
    //     Select((value, index) => new {value, index})) {
    //         string option = resolution.value.width + " x " + resolution.value.height;
    //         options.Add(option);

    //         if(resolution.value.width == Screen.currentResolution.width &&
    //         resolution.value.height == Screen.currentResolution.height) {
    //             currentResolutionIndex = resolution.index;
    //         }
    //     }

    //     if(!PlayerPrefs.HasKey("resolution")) {
    //         SetResolution(currentResolutionIndex);
    //     } else {
    //         currentResolutionIndex = PlayerPrefs.GetInt("resolution");
    //         SetResolution(currentResolutionIndex);
    //     }

    //     resolutionDropdown.AddOptions(options);
    //     resolutionDropdown.value = currentResolutionIndex;
    //     resolutionDropdown.RefreshShownValue();
    //     if(!PlayerPrefs.HasKey("fullscreen")) {
    //         SetFullscreen(true);
    //     } else {
    //         bool fullscreen = PlayerPrefs.GetInt("fullscreen") == 1;
    //         SetFullscreen(fullscreen);
    //     }

    //     gameObject.SetActive(false);
    // 

    void Start()
    {
        if (otherMenu is PauseMenu ps && pauseMenu == null)
            pauseMenu = ps;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolution", resolutionIndex);
    }
    
    /// <summary>
    /// Audio Sliders' use this method
    /// </summary>
    /// <param name="val"></param>
    public void SetAudio(float val)
    {
        AudioManager.Instance.SetAudioVolume(val, calledIndex);
    }

    public void SetSliderIndex(int index)
    {
        calledIndex = index;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        FindAnyObjectByType<Toggle>().isOn = isFullscreen;
        PlayerPrefs.SetInt("fullscreen", isFullscreen ? 1 : 0);
    }

    public override void DeactivateMenu()
    {
        base.DeactivateMenu();
        if (pauseMenu != null)
            pauseMenu.ActivateMenu(false);
    }

    public void LoadData(GameData data)
    {
        for (int i = 0; i < 2; i++)
        {
            SetSliderIndex(i);
            SetAudio(0);
        }
    }

    public void SaveData(GameData data)
    {
    }
}
