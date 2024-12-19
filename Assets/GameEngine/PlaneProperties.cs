using UnityEngine;
using System.Collections;

public class PlaneProperties : MonoBehaviour {
    public Plane plane;
    public CarMovementManager carController;
    public SpriteRenderer planeSprite;
    ShopItem savedShopItem;
    // Use this for initialization
    private void Start()
    {
        StartCoroutine(takeShopItem());

    }

    private void OnEnable()
    {
        StartCoroutine(takeShopItem());

    }
    void Update() {

        if (ObliusGameManager.instance.gameState == ObliusGameManager.GameState.shop)
        {
            planeSprite.enabled = false;
        }
        else
        {
            planeSprite.enabled = true;
        }
        if (savedShopItem != ShopHandler.instance.shopItemToUse) {
                
                    }
    }

    IEnumerator takeShopItem()
    {
        while (true)
        {
            
            ShopItem current = null;

            while (current == null)
            {
                current = ShopHandler.instance.shopItemToUse;
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();
            ShopItemProperties currentProperties = current.gameObject.GetComponent<ShopItemProperties>();


            carController.speed = currentProperties.SpeedMultiplier;

            carController.sensivityModifier = currentProperties.steeringPower;

            savedShopItem = current;

            planeSprite.sprite = currentProperties.spriteImage;


        }
    }

}
