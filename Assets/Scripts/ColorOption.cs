using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorOption : MonoBehaviour
{
    [SerializeField] private Button colorButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private TMP_Text optionText;
    
    private void Start()
    {
        colorButton.onClick.AddListener(ColorOptionClick);
        resetButton.onClick.AddListener(ResetColor);
    }
    
    private void ColorOptionClick()
    {
        if (SettingsManager.CurrentColorOption == null)
        {
            OpenColorWheel();
        }
        // else
        // {
        //     print("Changing color");
        //     ResetCurrentColorOption();
        //     OpenColorWheel();
        //     print("New color option is");
        //     print(SettingsManager.CurrentColorOption.gameObject.name);
        // }
    }

    public void CloseColorWheel()
    {
        ResetCurrentColorOption();
        SettingsManager.CurrentColorOption = null;
        SettingsManager.DisableFullscreenColorWheelCloseButton();
    }
    private void OpenColorWheel()
    {
        // Sets the current color options button as the game object in the settings manager
        SettingsManager.EnableFullscreenColorWheelCloseButton(this);
        
        colorButton.onClick.RemoveAllListeners();
        colorButton.onClick.AddListener(CloseColorWheel);

        transform.GetComponent<Image>().color = Color.black;
        optionText.color = Color.white;
    }

    private void ResetCurrentColorOption()
    {
        // Resets the previous color option button
        SettingsManager.CurrentColorOption.transform.GetComponent<Image>().color = Color.clear;
        SettingsManager.CurrentColorOption.optionText.color = Color.black;
        SettingsManager.CurrentColorOption.colorButton.onClick.RemoveAllListeners();
        SettingsManager.CurrentColorOption.colorButton.onClick.AddListener(ColorOptionClick);
    }
    
    private void ResetColor()
    {
        // TODO - Reset color and revert the above to the initial colors    
    }

}
