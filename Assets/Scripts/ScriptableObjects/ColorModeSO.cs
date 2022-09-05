using NaughtyAttributes;
using UnityEngine;
using static UnityEngine.Color;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ColorMode.asset", menuName = "ColorMode")]
    public class ColorModeSO : ScriptableObject
    {
        [BoxGroup("Character")]
        public Color playerColor = white;
        [BoxGroup("Character")]
        public Color enemyColor = white;
        [BoxGroup("Items")]
        public Color itemsHealthColor = white;
        [BoxGroup("Items")]
        public Color itemsSpeedBuffColor = white;
        [BoxGroup("Items")]
        public Color itemsAttackBuffColor = white;
        [BoxGroup("Environment")]
        public Color doorColor = white;
        [BoxGroup("Environment")]
        public Color wallColor = white;
    }
}