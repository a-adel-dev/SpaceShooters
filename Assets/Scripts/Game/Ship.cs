using UnityEngine;
using Core;

namespace Game
{
    [CreateAssetMenu(fileName = "ShipType", menuName = "Ship", order = 0)]
    public class Ship : ScriptableObject
    {
        public ShipType shipClass;
        public float rotationSpeed;
        public float thrustSpeed;
        public float maxMovementThrottle;
        public float movementThrottleMultiplier;
        public float brakeMultiplier;

        public Sprite ShipSprite;
        public Sprite ExhaustSprite;

        public bulletType bulletType;
    }

    public enum bulletType
    {
        laser
    }
}