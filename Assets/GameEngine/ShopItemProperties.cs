using UnityEngine;
using System.Collections;

public class ShopItemProperties : MonoBehaviour {

    public SpriteRenderer sprite;
    public float SpeedMultiplier = 1;
    public float steeringPower = 1;
    [HideInInspector]
    public Sprite spriteImage;
    void Awake()
    {
        spriteImage = sprite.sprite;

    }





}
