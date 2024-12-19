using UnityEngine;
using System.Collections;

public class CloudsSpawner : MonoBehaviour {
    public GameObject[] cloudsList;
     int numberOfCloudsToSpawnEachTime = 35000;
     float maxDistanceToSpawnNewClouds = 500f;
     float cloudsSpawnRadius = 800f;
    GameObject[] lastSpawnedCloudsCompound;
    
    // Use this for initialization
	void Start () {
       
        SpawnClouds();
        StartCoroutine(CloudSpawnerRoutine());
	}

    void SpawnClouds() {

        GameObject[] spawnedClouds = new GameObject[numberOfCloudsToSpawnEachTime];
        for (int i = 0; i < spawnedClouds.Length; i++) {
            GameObject newCloud =(GameObject) Instantiate(cloudsList[Random.Range(0, cloudsList.Length)], Vector3.zero, Quaternion.identity);
         spawnedClouds[i] = newCloud;
        }
        MoveCloudsInACircle(spawnedClouds);
        lastSpawnedCloudsCompound = spawnedClouds;
    }

    void MoveCloudsInACircle(GameObject[] clouds) {

        foreach (GameObject cloud in clouds) {
            Vector3 randomizedCircle = Random.insideUnitSphere * cloudsSpawnRadius;
            randomizedCircle.y = 0;
            Vector3 targetPosition = CarMovementManager.instance.transform.position + randomizedCircle;
            cloud.transform.position = targetPosition;
            cloud.transform.Rotate(90, 0, 0);
            cloud.transform.position += Vector3.up;
            cloud.transform.parent = this.transform;
        }

    }

    void MoveCloudsCompound() {
        transform.position = CarMovementManager.instance.transform.position;


    }


    IEnumerator CloudSpawnerRoutine() {

        Vector3 savedPlanePosition = CarMovementManager.instance.transform.position;
        while (true) {
            if (CarMovementManager.instance == null) yield break;
            Vector3 currentPlanePosition = CarMovementManager.instance.transform.position;

            if (Vector3.Distance(currentPlanePosition, savedPlanePosition) > maxDistanceToSpawnNewClouds) {
                savedPlanePosition = currentPlanePosition;
                MoveCloudsCompound();
            }





            yield return new WaitForEndOfFrame();


        }


    }


}
