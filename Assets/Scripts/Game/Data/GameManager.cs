using Game.Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Game.Data
{
    public class GameManager : MonoBehaviour
    {
        //private ConfigDataReader _configDataReader;
        public Ship[] ships;
        [SerializeField] private GameObject playerObject;

        [FormerlySerializedAs("PlayerProjectileObject")] [SerializeField] private GameObject playerProjectileObject;
        [SerializeField] private GameObject asteroidPrefab;
        [SerializeField] private UnityEvent newGame;
        private void Awake()
        {
            newGame?.Invoke();
            SetCurrentPlayerShip(ships[0]);
        }

        private void SetCurrentPlayerShip(Ship ship)
        {
            //clear old Components if there were any
            var playerOld = playerObject.GetComponent<Player.Player>();
            if(playerOld) Destroy(playerOld);

            var spriteRenderersOld = playerObject.GetComponents<SpriteRenderer>();
            foreach (var spriteRenderer in spriteRenderersOld)        
            {
                Destroy(spriteRenderer);
            }
            
            //adds a player script and assign a ship class to it
            Player.Player player = playerObject.AddComponent<Player.Player>();
            player.CurrentShip = ship;
            
            //adds ship sprite gameObject
            GameObject shipSprite = new GameObject {name = player.CurrentShip.shipClass.ToString()};
            shipSprite.transform.parent = playerObject.transform;
            SpriteRenderer shipSpriteRenderer = shipSprite.AddComponent<SpriteRenderer>();
            shipSpriteRenderer.sprite = player.CurrentShip.ShipSprite;
            shipSpriteRenderer.sortingOrder = 3;
            
            //adds ship exhaust sprite gameObject
            GameObject shipExhaustSprite = new GameObject {name = $"{player.CurrentShip.shipClass}Exhaust"};
            shipExhaustSprite.transform.parent = playerObject.transform;
            SpriteRenderer shipExhaustSpriteRenderer = shipExhaustSprite.AddComponent<SpriteRenderer>();
            shipExhaustSpriteRenderer.sprite = player.CurrentShip.ExhaustSprite;

            //assigns a ship to playerController script and sets the exhaustRenderer
            PlayerController playerController = playerObject.GetComponent<PlayerController>();
            playerController.currentShip = ship;
            playerController.ExhaustSpriteRenderer = shipExhaustSpriteRenderer;
        }
    }
}