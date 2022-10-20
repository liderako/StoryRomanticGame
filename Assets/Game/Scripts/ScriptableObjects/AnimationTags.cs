using UnityEngine;

namespace Game.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SO", menuName = "SO/AnimationTags", order = 0)]
    public class AnimationTags : ScriptableObject
    {
        public string attackAnimation = "Attack";
    }
}