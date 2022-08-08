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
    
    private static RectTransform _colorPickerCanvas;
    private static Vector2 _colorPickerCanvasPosition;
    

    public void Awake()
    {
        _closeColourOptionButton = transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Button>();
        _scrollRect = transform.GetChild(0).GetChild(3).GetChild(1).GetComponent<ScrollRect>();
        _colorPickerCanvas = transform.GetChild(0).GetChild(3).GetChild(2).GetComponent<RectTransform>();
        _colorPickerCanvasPosition = _colorPickerCanvas.anchoredPosition;

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
        
        _colorPickerCanvas.gameObject.SetActive(true);

        // Disables scrolling after having opened the colour picker - also enables closure of the colour picker by
        // pressing anywhere on the UI canvas
        DisableSettingsScrolling();
    }

    public static void DisableFullscreenColourWheelCloseButton()
    {
        CurrentColorOption = null;
        _closeColourOptionButton.GetComponent<Image>().raycastTarget = false;
        _closeColourOptionButton.onClick.RemoveAllListeners();
        
        _colorPickerCanvas.gameObject.SetActive(false);

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
