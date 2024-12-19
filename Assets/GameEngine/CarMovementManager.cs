using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementManager : MonoBehaviour {
    public SteeringWheel wheel;
    public float sensivityModifier = 1;
    public float speed = 1;
    public static CarMovementManager instance;
    public GameObject tireParticles;
	// Use this for initialization
	void Awake () {
        instance = this;
	}

    float previousAngle;
    float currentAngle;
    // Update is called once per frame
    float difference;
    bool canMove = false;
    private void Start()
    {
        wheel = SteeringWheel.instance;
        StartCoroutine(canMoveRoutine());

    }
    IEnumerator canMoveRoutine()
    {
   
        GameEventsCollection.instance.cameraTargetFollow.enabled = true;
        canMove = true;
        yield return null;
    
    }
    void FixedUpdate () {
        if (SteeringWheel.instance == null) return;
        if (wheel == null)
        {
            wheel = SteeringWheel.instance;

            return;
        }
        tireParticles.SetActive(true);

        currentAngle = wheel.wheelAngle;

            currentAngle = Mathf.Clamp(currentAngle, -260, 260);

        transform.Rotate(0, (currentAngle * sensivityModifier) * Time.deltaTime, 0);

        previousAngle = currentAngle;
       
        transform.position += transform.forward * speed * Time.deltaTime *5;
        }

}
