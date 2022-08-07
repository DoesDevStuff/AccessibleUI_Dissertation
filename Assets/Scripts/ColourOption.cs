using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColourOption : MonoBehaviour
{
    [SerializeField] private Button colourButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private TMP_Text optionText;
    
    

    private void Start()
    {
        colourButton.onClick.AddListener(ColourOptionClick);
        resetButton.onClick.AddListener(ResetColour);
    }
    
    private void ColourOptionClick()
    {
        if (SettingsManager.CurrentColorOption == null)
        {
            print("Opening a colour wheel");
            OpenColourWheel();
        }
        else if (SettingsManager.CurrentColorOption != this)
        {
            print("Selecting another colour option while another is already open");
        }
        else
        {
            print("Selecting the same colour option");
        }
    }

    private void OpenColourWheel()
    {
        // Sets the current colour options button as the game object in the settings manager
        SettingsManager.CurrentColorOption = null;
        SettingsManager.EnableFullscreenColourWheelCloseButton(this);
        
        colourButton.onClick.RemoveAllListeners();
        colourButton.onClick.AddListener(CloseColourWheel);

        transform.GetComponent<Image>().color = Color.black;
        optionText.color = Color.white;
        
        // TODO - Save Colours to persist across play instances
        // TODO - Change colour of the game prefabs 
    }

    public void CloseColourWheel()
    {
        SettingsManager.CurrentColorOption = null;
        SettingsManager.DisableFullscreenColourWheelCloseButton();

        transform.GetComponent<Image>().color = Color.clear;
        optionText.color = Color.black;
        
        colourButton.onClick.AddListener(ColourOptionClick);
    }
    
    private void ResetColour()
    {
        // TODO - Reset colour and revert the above to the initial colours    
    }

}
