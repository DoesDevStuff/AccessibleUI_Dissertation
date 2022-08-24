using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public static ColorOption CurrentColorOption;
    private static Button _closeColorOptionButton;
    private static ScrollRect _scrollRect;
    private static Scrollbar _scrollbar;
    
    private static RectTransform _colorPickerCanvas;
    private static Vector2 _colorPickerCanvasPosition;

    private static ColorPickerUnityUI _colorPickerUnityUI;

    [SerializeField] private Button closeButton;


    public void Awake()
    {
        _closeColorOptionButton = transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Button>();
        _scrollRect = transform.GetChild(0).GetChild(4).GetChild(1).GetComponent<ScrollRect>();
        _colorPickerCanvas = transform.GetChild(0).GetChild(4).GetChild(2).GetComponent<RectTransform>();
        _colorPickerCanvasPosition = _colorPickerCanvas.anchoredPosition;

        _colorPickerUnityUI = _colorPickerCanvas.transform.GetChild(1).GetComponent<ColorPickerUnityUI>();

        _scrollbar = _scrollRect.transform.GetChild(1).GetComponent<Scrollbar>();

        closeButton.onClick.AddListener(CloseSettings);
    }
    
    public static void EnableFullscreenColorWheelCloseButton(ColorOption activeColorOption)
    {
        if (_colorPickerCanvas.gameObject.activeSelf) return;

        _colorPickerUnityUI.ResetTumb();
        CurrentColorOption = activeColorOption;
        _colorPickerCanvas.gameObject.SetActive(true);
        _closeColorOptionButton.GetComponent<Image>().raycastTarget = true;
        _closeColorOptionButton.onClick.AddListener(CurrentColorOption.CloseColorWheel);
        

        // Disables scrolling after having opened the color picker - also enables closure of the color picker by
        // pressing anywhere on the UI canvas
        DisableSettingsScrolling();
    }

    public static void DisableFullscreenColorWheelCloseButton()
    {
        CurrentColorOption = null;
        _closeColorOptionButton.GetComponent<Image>().raycastTarget = false;
        _closeColorOptionButton.onClick.RemoveAllListeners();
        
        _colorPickerCanvas.gameObject.SetActive(false);

        EnableSettingsScrolling();
    }
    
    public static void ChangeColor(Color newColor)
    {
        CurrentColorOption.transform.GetChild(1).GetComponent<Image>().color = newColor;
        CurrentColorOption.spriteMaterial.color = newColor;

        // TODO - Update the material color as well
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

    private void CloseSettings()
    {
        gameObject.SetActive(false);
    }
}
