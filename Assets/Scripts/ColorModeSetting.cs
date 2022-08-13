using System;
using System.Collections.Generic;
using NaughtyAttributes;
using ScriptableObjects;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ColorModeSetting : MonoBehaviour
{
    // Character Materials
    [BoxGroup("Characters")]
    [SerializeField] private Material playerMaterial;
    [BoxGroup("Characters")]
    [SerializeField] private Material enemyMaterial;
    
    // Items Materials
    [BoxGroup("Items")]
    [SerializeField] private Material itemsHealthMaterial;
    [BoxGroup("Items")]
    [SerializeField] private Material itemsSpeedBuffMaterial;
    [BoxGroup("Items")]
    [SerializeField] private Material itemsAttackBuffMaterial;
    
    // Environment Materials
    [BoxGroup("Environment")]
    [SerializeField] private Material doorMaterials;
    [BoxGroup("Environment")]
    [SerializeField] private Material wallMaterial;

    [ReorderableList]
    [SerializeField] private ColorModeSO[] colorModes;

    [SerializeField] private TMP_Dropdown dropdown;
    
    private readonly List<string> _dropdownOptions = new List<string>();
    private readonly Dictionary<ColorOption.ColorOptionEnum, Image> _colorOptionButtonDic = new Dictionary<ColorOption.ColorOptionEnum, Image>();

    private void Awake()
    {
        /****************************
	    Assigns the dropdown values
        ****************************/
        foreach (ColorModeSO colorMode in colorModes)
        {
            _dropdownOptions.Add(colorMode.name);
        }
        dropdown.AddOptions(_dropdownOptions);
        dropdown.onValueChanged.AddListener(delegate
        {
            ChangeColourMode();
        });
        
        /****************************
        Finds all the color options in the settings menu
        ****************************/
        var colorOptionsFound = FindObjectsOfType<ColorOption>();
        foreach (ColorOption colorOption in colorOptionsFound)
        {
            // _colorOptionsList.Add(colorOption);
            _colorOptionButtonDic.Add(colorOption.colorOptionName, colorOption.colorButton.GetComponent<Image>());
        }
    }

    private void ChangeColourMode()
    {
        ColorModeSO colorModeSO = colorModes[dropdown.value];
        
        AssignNewColor(playerMaterial, _colorOptionButtonDic[ColorOption.ColorOptionEnum.Player], colorModeSO.playerColor);
        AssignNewColor(enemyMaterial, _colorOptionButtonDic[ColorOption.ColorOptionEnum.Enemy], colorModeSO.enemyColor);
        AssignNewColor(itemsHealthMaterial, _colorOptionButtonDic[ColorOption.ColorOptionEnum.ItemHealth], colorModeSO.itemsHealthColor);
        AssignNewColor(itemsAttackBuffMaterial, _colorOptionButtonDic[ColorOption.ColorOptionEnum.ItemAttack], colorModeSO.itemsAttackBuffColor);
        AssignNewColor(itemsSpeedBuffMaterial, _colorOptionButtonDic[ColorOption.ColorOptionEnum.ItemSpeed], colorModeSO.itemsSpeedBuffColor);
        AssignNewColor(wallMaterial, _colorOptionButtonDic[ColorOption.ColorOptionEnum.Wall], colorModeSO.wallColor);
        AssignNewColor(doorMaterials, _colorOptionButtonDic[ColorOption.ColorOptionEnum.Door], colorModeSO.doorColor);
    }

    private static void AssignNewColor(Material material, Image colorOption, Color newColor)
    {
        material.color = newColor;
        colorOption.color = newColor;
    }
}