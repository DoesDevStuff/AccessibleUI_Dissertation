using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static ColourOption currentColorOption;
    
    private static Button _closeColourOptionButton;
    private static ScrollRect _scrollRect;
    private static Scrollbar _scrollbar; 

    public void Awake()
    {
        _closeColourOptionButton = transform.GetChild(0).GetChild(2).GetComponent<Button>();
        _scrollRect = transform.GetChild(0).GetChild(3).GetComponent<ScrollRect>();
        _scrollbar = _scrollRect.transform.GetChild(1).GetComponent<Scrollbar>();
    }

    public static void EnableFullscreenColourWheelCloseButton(ColourOption activeColorOption)
    {
        currentColorOption = activeColorOption;
        _closeColourOptionButton.onClick.AddListener(currentColorOption.CloseColourWheel);
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
