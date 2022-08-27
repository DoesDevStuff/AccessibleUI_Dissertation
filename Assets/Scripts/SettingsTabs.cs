using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsTabs : MonoBehaviour
{
    [BoxGroup("Buttons")]
    [SerializeField] private Button controlTabButton;
    [BoxGroup("Buttons")]
    [SerializeField] private Button colorSettingsTabButton;

    [BoxGroup("Sprites")]
    [SerializeField] private Sprite activeButtonSprite;
    [BoxGroup("Sprites")]
    [SerializeField] private Sprite inactiveButtonSprite;

    [BoxGroup("GameObjects")]
    [SerializeField] private GameObject controlImage;
    [BoxGroup("GameObjects")]
    [SerializeField] private GameObject colorSettings;

    [SerializeField] private ColorModeSetting _colorModeSetting;
    

    private readonly Color _blackColor = new Color(20, 20, 20);
    
    private void Awake()
    {
        controlTabButton.onClick.AddListener(OpenControlImage);
        colorSettingsTabButton.onClick.AddListener(OpenColorSettings);
    }

    private void OpenControlImage()
    {
        controlImage.SetActive(true);
        colorSettings.SetActive(false);

        controlTabButton.GetComponent<Image>().sprite = activeButtonSprite;
        colorSettingsTabButton.GetComponent<Image>().sprite = inactiveButtonSprite;
        
        controlTabButton.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
        colorSettingsTabButton.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;
    }

    private void OpenColorSettings()
    {
        
        controlImage.SetActive(false);
        colorSettings.SetActive(true);

        if (!_colorModeSetting.assignedColorOptions)
        {
            _colorModeSetting.AssignColorOptions();
        }
        
        if (_colorModeSetting.shouldUpdateColorOptions)
        {
            _colorModeSetting.ChangeColorMode();
            _colorModeSetting.shouldUpdateColorOptions = false;
        }
        
        controlTabButton.GetComponent<Image>().sprite = inactiveButtonSprite;
        colorSettingsTabButton.GetComponent<Image>().sprite = activeButtonSprite;
        
        controlTabButton.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;
        colorSettingsTabButton.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
    }
}
