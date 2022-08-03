using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public static ColourOption currentColorOption;
    
    private static Button _closeColourOptionButton;
    private static ScrollRect _scrollRect;
    private static Scrollbar _scrollbar;
    
    [SerializeField] private Canvas _colorPickerCanvas;
    

    // [SerializeField] private TMP_Dropdown colourModeDropdown;
    
    public void Awake()
    {
        _closeColourOptionButton = transform.GetChild(0).GetChild(2).GetComponent<Button>();
        _scrollRect = transform.GetChild(0).GetChild(3).GetComponent<ScrollRect>();
        // _scrollbar = _scrollRect.transform.GetChild(1).GetComponent<Scrollbar>();
        
        // print(colourModeDropdown);
        // colourModeDropdown.onValueChanged.AddListener(delegate
        // {
        //     print("Colormode changed");
        //     ColorModeChange(colourModeDropdown);
        // });
    }

    // private void ColorModeChange(TMP_Dropdown change)
    // {
    //     print(change.value);
    //     print("Changing value");
    // }

    public static void EnableFullscreenColourWheelCloseButton(ColourOption activeColorOption)
    {
        currentColorOption = activeColorOption;
        _closeColourOptionButton.onClick.AddListener(currentColorOption.CloseColourWheel);
        _closeColourOptionButton.GetComponent<Image>().raycastTarget = true;

        // Disables scrolling after having opened the colour picker - also enables closure of the colour picker by
        // pressing anywhere on the UI canvas
        // DisableSettingsScrolling();
    }

    public static void DisableFullscreenColourWheelCloseButton()
    {
        _closeColourOptionButton.GetComponent<Image>().raycastTarget = false;
        _closeColourOptionButton.onClick.RemoveAllListeners();
        
        // EnableSettingsScrolling();
    }
    
    public static void ChangeColour(Color newColour)
    {
        currentColorOption.transform.GetChild(1).GetComponent<Image>().color = newColour;
        
        // TODO - Update the material colour as well
    }
    
    // private static void DisableSettingsScrolling()
    // {
    //     _scrollRect.enabled = false;
    //     _scrollbar.interactable = false;
    // }
    //
    // public static void EnableSettingsScrolling()
    // {
    //     _scrollRect.enabled = true;
    //     _scrollbar.interactable = true;
    //     
    // }

}
