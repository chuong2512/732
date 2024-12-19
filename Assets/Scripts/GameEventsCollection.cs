using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsCollection : MonoBehaviour {
    public static GameEventsCollection instance;
    public TargetFollow cameraTargetFollow;

    void Awake()
    {
        instance = this;
    }
}
