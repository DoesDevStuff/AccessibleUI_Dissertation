using NaughtyAttributes;
using ScriptableObjects;
using UnityEngine;

public class ColourSettings : MonoBehaviour
{
    // Character Materials
    [SerializeField] private Material playerMaterial;
    [SerializeField] private Material enemyMaterial;
    
    // Items Materials
    [SerializeField] private Material itemsHealthMaterial;
    [SerializeField] private Material itemsSpeedBuffMaterial;
    [SerializeField] private Material itemsAttackBuffMaterial;
    
    // Environment Materials
    [SerializeField] private Material doorMaterials;
    [SerializeField] private Material wallMaterial;

    [SerializeField] private ColorThemes[] colorthemes;
    [Range(0, 3)]
    [SerializeField] private int activeTheme;

    private void UpdateMaterial(Material material, Color newColour)
    {
        material.color = newColour;
    }

    [Button]
    private void ChangeColourTheme()
    {
        // TODO - Replace with stored colour theme
        playerMaterial.color = colorthemes[activeTheme].playerColor;
        enemyMaterial.color = colorthemes[activeTheme].enemyColor;
        
        itemsHealthMaterial.color = colorthemes[activeTheme].itemsHealthColor;
        itemsSpeedBuffMaterial.color = colorthemes[activeTheme].itemsSpeedBuffColor;
        itemsAttackBuffMaterial.color = colorthemes[activeTheme].itemsAttackBuffColor;

        doorMaterials.color = colorthemes[activeTheme].doorColor;
        wallMaterial.color = colorthemes[activeTheme].wallColor;
    }
    
    private void ResetMaterials()
    {
        playerMaterial.color = colorthemes[activeTheme].playerColor;
        enemyMaterial.color = colorthemes[activeTheme].enemyColor;
        
        itemsHealthMaterial.color = colorthemes[activeTheme].itemsHealthColor;
        itemsSpeedBuffMaterial.color = colorthemes[activeTheme].itemsSpeedBuffColor;
        itemsAttackBuffMaterial.color = colorthemes[activeTheme].itemsAttackBuffColor;

        doorMaterials.color = colorthemes[activeTheme].doorColor;
        wallMaterial.color = colorthemes[activeTheme].wallColor;
    }
}
