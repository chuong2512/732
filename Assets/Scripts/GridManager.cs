using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
     Transform referenceTransform;
    public Material gridMaterial;
    Vector3 offsetPosition;
    public float movementSpeedOffset = 0.2f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Plane.instance == null) return;

        if (referenceTransform == null)
        {
            referenceTransform = Plane.instance.transform;
            if (referenceTransform == null) return;
            offsetPosition = transform.position - referenceTransform.position;
        }
        transform.position = referenceTransform.position + offsetPosition;
        Vector3 dir = referenceTransform.forward;
        Vector2 direction = new Vector2(dir.x, dir.z); //new Vector2(referenceTransform.position.x, referenceTransform.position.z);
        direction = -direction*(Time.deltaTime* movementSpeedOffset) + gridMaterial.GetTextureOffset("_MainTex");
        gridMaterial.SetTextureOffset("_MainTex", direction);
	}
}
