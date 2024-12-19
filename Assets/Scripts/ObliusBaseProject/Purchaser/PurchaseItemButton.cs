using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseItemButton : MonoBehaviour {

	public int productToPurchaseIndex;


	public void OnClick(){

		Purchasable productToPurchase = Purchaser.instance.purchaseItems [productToPurchaseIndex];
		
	}

}
