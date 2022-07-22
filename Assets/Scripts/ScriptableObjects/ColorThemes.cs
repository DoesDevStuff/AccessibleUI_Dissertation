using UnityEngine;
using static UnityEngine.Color;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ColorTheme.asset", menuName = "ColorTheme")]
    public class ColorThemes : ScriptableObject
    {
        public enum ColorThemesEnum
        {
            Default,
            Deuteranomaly,
            Trichromacy,
            Monochromacy
        }

        public ColorThemesEnum colorTheme;
    
        public Color playerColor = white;
        public Color enemyColor = white;
        public Color itemsHealthColor = white;
        public Color itemsSpeedBuffColor = white;
        public Color itemsAttackBuffColor = white;
        public Color doorColor = white;
        public Color wallColor = white;
    }
}
