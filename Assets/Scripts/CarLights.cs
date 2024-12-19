using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour {
   public SpriteRenderer blue;
   public SpriteRenderer red;
    public float alternateTime = 0.5f;
	// Use this for initialization
	void Start () {
        StartCoroutine(AnimationRoutine());
	}
	
IEnumerator AnimationRoutine()
    {
        blue.enabled = true;
        red.enabled = false;

        while (true)
        {
            blue.enabled = !blue.enabled;
            red.enabled = !red.enabled;
            yield return new WaitForSeconds(alternateTime);
        }
    }
}
