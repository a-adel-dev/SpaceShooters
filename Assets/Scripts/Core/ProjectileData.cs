using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "NewProjectile", menuName = "ProjectileData", order = 0)]
    public class ProjectileData : ScriptableObject
    {
        //public ProjectileType type;
        public Sprite projectileSprite;
        
        public int damageValue;
    }
}