using System;
using UnityEngine;
using UnityEngine.UI;

public class ColourOption : MonoBehaviour
{
    [SerializeField] private Button colourButton;
    [SerializeField] private Button resetButton;


    private void Start()
    {
        colourButton.onClick.AddListener( () => openColourWheel());
        resetButton.onClick.AddListener( () => resetColour());
    }
    
    private void openColourWheel()
    {
        print("Open colour wheel");
        
        // TODO - Save Colours to persist across play instances
        // TODO - Change colour of the button
        // TODO - Change colour of the game prefabs
    }
    
    private void resetColour()
    {
        // TODO - Reset colour and revert the above to the initial colours    
    }
    
}
