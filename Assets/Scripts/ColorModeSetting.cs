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

    public bool shouldUpdateColorOptions;
    public bool assignedColorOptions;
    
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
            ChangeColorMode();
        });
    }

    public void AssignColorOptions()
    {
        /****************************
        Finds all the color options in the settings menu
        ****************************/
        var colorOptionsFound = FindObjectsOfType<ColorOption>();
        foreach (ColorOption colorOption in colorOptionsFound)
        {
            _colorOptionButtonDic.Add(colorOption.colorOptionName, colorOption.colorButton.GetComponent<Image>());
        }

        print("Assigned " + _colorOptionButtonDic.Count + " coloroptions");
        assignedColorOptions = true;
    }

    public void ChangeColorMode()
    {
        ColorModeSO colorModeSO = colorModes[dropdown.value];

        if (_colorOptionButtonDic.Count == 0)
        {
            shouldUpdateColorOptions = true;
            AssignNewColor(playerMaterial, colorModeSO.playerColor);
            AssignNewColor(enemyMaterial, colorModeSO.enemyColor);
            AssignNewColor(itemsHealthMaterial, colorModeSO.itemsHealthColor);
            AssignNewColor(itemsAttackBuffMaterial, colorModeSO.itemsAttackBuffColor);
            AssignNewColor(itemsSpeedBuffMaterial, colorModeSO.itemsSpeedBuffColor);
            AssignNewColor(wallMaterial, colorModeSO.wallColor);
            AssignNewColor(doorMaterials, colorModeSO.doorColor);
        }
        else if(shouldUpdateColorOptions)
        {
            print("Assigning colors to color options");
            AssignNewColor(_colorOptionButtonDic[ColorOption.ColorOptionEnum.Player], colorModeSO.playerColor);
            AssignNewColor(_colorOptionButtonDic[ColorOption.ColorOptionEnum.Enemy], colorModeSO.enemyColor);
            AssignNewColor(_colorOptionButtonDic[ColorOption.ColorOptionEnum.ItemHealth], colorModeSO.itemsHealthColor);
            AssignNewColor(_colorOptionButtonDic[ColorOption.ColorOptionEnum.ItemAttack], colorModeSO.itemsAttackBuffColor);
            AssignNewColor(_colorOptionButtonDic[ColorOption.ColorOptionEnum.ItemSpeed], colorModeSO.itemsSpeedBuffColor);
            AssignNewColor(_colorOptionButtonDic[ColorOption.ColorOptionEnum.Wall], colorModeSO.wallColor);
            AssignNewColor(_colorOptionButtonDic[ColorOption.ColorOptionEnum.Door], colorModeSO.doorColor);
        }
        else
        {
            AssignNewColor(playerMaterial, _colorOptionButtonDic[ColorOption.ColorOptionEnum.Player],
                colorModeSO.playerColor);
            AssignNewColor(enemyMaterial, _colorOptionButtonDic[ColorOption.ColorOptionEnum.Enemy],
                colorModeSO.enemyColor);
            AssignNewColor(itemsHealthMaterial, _colorOptionButtonDic[ColorOption.ColorOptionEnum.ItemHealth],
                colorModeSO.itemsHealthColor);
            AssignNewColor(itemsAttackBuffMaterial, _colorOptionButtonDic[ColorOption.ColorOptionEnum.ItemAttack],
                colorModeSO.itemsAttackBuffColor);
            AssignNewColor(itemsSpeedBuffMaterial, _colorOptionButtonDic[ColorOption.ColorOptionEnum.ItemSpeed],
                colorModeSO.itemsSpeedBuffColor);
            AssignNewColor(wallMaterial, _colorOptionButtonDic[ColorOption.ColorOptionEnum.Wall],
                colorModeSO.wallColor);
            AssignNewColor(doorMaterials, _colorOptionButtonDic[ColorOption.ColorOptionEnum.Door],
                colorModeSO.doorColor);
        }
    }

    private static void AssignNewColor(Material material, Color newColor)
    {
        material.color = newColor;
    }
    
    private static void AssignNewColor(Image colorOption, Color newColor)
    {
        colorOption.color = newColor;
    }
    
    private static void AssignNewColor(Material material, Image colorOption, Color newColor)
    {
        material.color = newColor;
        colorOption.color = newColor;
    }
}