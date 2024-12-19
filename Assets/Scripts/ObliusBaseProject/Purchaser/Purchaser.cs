using System;
using System.Collections.Generic;
using UnityEngine;



// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class Purchaser : MonoBehaviour
{


	public static Purchaser instance;


	// Product identifiers for all products capable of being purchased: "convenience" general identifiers for use with Purchasing, and their store-specific identifier counterparts
	// for use with and outside of Unity Purchasing. Define store-specific identifiers also on each platform's publisher dashboard (iTunes Connect, Google Play Developer Console, etc.)

	public Purchasable[] purchaseItems;
	public GameObject waitingResponseOverlay;

                                                                                                    
	void Awake ()
	{
		if (instance != null) {
			Destroy (gameObject);
			return;
		}

		instance = this;
		DontDestroyOnLoad (gameObject);
	}

	void Start ()
	{
		// If we haven't set up the Unity Purchasing reference
		
	}

	public void BuyNonConsumable(string generalProductID)
	{
	}

	public void RestorePurchases()
	{
	}
}
