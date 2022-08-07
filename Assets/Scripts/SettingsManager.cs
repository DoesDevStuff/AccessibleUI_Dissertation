using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public static ColourOption CurrentColorOption;
    private static Button _closeColourOptionButton;
    private static ScrollRect _scrollRect;
    private static Scrollbar _scrollbar;
    private static TMP_Dropdown _colourModeDropdown;
    
    [SerializeField] private Canvas colorPickerCanvas;

    public void Awake()
    {
        _closeColourOptionButton = transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Button>();
        _scrollRect = transform.GetChild(0).GetChild(3).GetChild(1).GetComponent<ScrollRect>();
        _scrollbar = _scrollRect.transform.GetChild(1).GetComponent<Scrollbar>();
        _colourModeDropdown = transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<TMP_Dropdown>();

        _colourModeDropdown.onValueChanged.AddListener(delegate
        {
            print(_colourModeDropdown.options[_colourModeDropdown.value]);
        });
    }
    
    public static void EnableFullscreenColourWheelCloseButton(ColourOption activeColorOption)
    {
        CurrentColorOption = activeColorOption;
        _closeColourOptionButton.onClick.AddListener(CurrentColorOption.CloseColourWheel);
        _closeColourOptionButton.GetComponent<Image>().raycastTarget = true;

        // Disables scrolling after having opened the colour picker - also enables closure of the colour picker by
        // pressing anywhere on the UI canvas
        DisableSettingsScrolling();
    }

    public static void DisableFullscreenColourWheelCloseButton()
    {
        _closeColourOptionButton.GetComponent<Image>().raycastTarget = false;
        _closeColourOptionButton.onClick.RemoveAllListeners();
        
        EnableSettingsScrolling();
    }
    
    public static void ChangeColour(Color newColour)
    {
        CurrentColorOption.transform.GetChild(1).GetComponent<Image>().color = newColour;
        
        // TODO - Update the material colour as well
    }
    
    private static void DisableSettingsScrolling()
    {
        _scrollRect.enabled = false;
        _scrollbar.interactable = false;
    }
    
    public static void EnableSettingsScrolling()
    {
        _scrollRect.enabled = true;
        _scrollbar.interactable = true;
    }

    

}
