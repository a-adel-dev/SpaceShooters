using System;
using Game;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;


namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private ConfigDataReader _configDataReader;
        public Ship[] ships;
        [SerializeField] private GameObject playerObject;

        [SerializeField] private GameObject PlayerProjectileObject;
        private void Awake()
        {
            _configDataReader = new ConfigDataReader();
            _configDataReader.LoadJson();
            InitializePlayerBulletPool();

            SetCurrentPlayerShip(ships[0]);
        }

        private void Update()
        {
        }

        private void InitializePlayerBulletPool()
        {
            PlayerProjectilePool.Initialize(PlayerProjectileObject);
        }

        private void SetCurrentPlayerShip(Ship ship)
        {
            //clear old Components if there were any
            var playerOld = playerObject.GetComponent<Player>();
            if(playerOld) Destroy(playerOld);

            var spriteRenderersOld = playerObject.GetComponents<SpriteRenderer>();
            foreach (var spriteRenderer in spriteRenderersOld)        
            {
                Destroy(spriteRenderer);
            }
            
            //adds a player script and assign a ship class to it
            Player player = playerObject.AddComponent<Player>();
            player.CurrentShip = ship;
            
            //adds ship sprite gameObject
            GameObject shipSprite = new GameObject {name = player.CurrentShip.shipClass.ToString()};
            shipSprite.transform.parent = playerObject.transform;
            SpriteRenderer shipSpriteRenderer = shipSprite.AddComponent<SpriteRenderer>();
            shipSpriteRenderer.sprite = player.CurrentShip.ShipSprite;
            
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