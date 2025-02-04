using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
//using Unity.VisualScripting;
using UnityEngine;
// UnityEngine.Pool;
//using static UnityEngine.GraphicsBuffer;

public class Task2 : MonoBehaviour
{

    [SerializeField] private GameObject sphere;
    [SerializeField] private GameObject cube;

    [SerializeField] private List<GameObject> listOfSpheresToSpawn;
    [SerializeField] private List<GameObject> listOfSpawnedSpheres;

    [SerializeField] private IsPooling isPooling;

    private bool isPoolingBool;

    private Vector3 randomSpherePosition;

    private GameObject sphereInstance;

    private float waitToSpawn = 1f;
    private float timeToSpawn = 0f;
    private float waitToDelete = 3f;
    private float timeToDelete = 0f;
    void Start()
    {
        listOfSpheresToSpawn = new List<GameObject>();
        sphereInstance = Instantiate(sphere);
        sphereInstance.GetComponent<Sphere>().isPooling = isPoolingBool;
        sphereInstance.SetActive(false);
        listOfSpheresToSpawn.Add(sphereInstance);
        isPoolingBool = isPooling.IsPoolingBool;
    }

    void Update()
    {
        timeToSpawn += Time.deltaTime;
        timeToDelete += Time.deltaTime;

        //Code if without using SpherePooling
        if (!isPoolingBool)
        {
            if (timeToSpawn >= waitToSpawn)
            {
                timeToSpawn = 0f;
                spawnSphere();
            }

            if (timeToDelete >= waitToDelete)
            {
                timeToDelete = 0f;
                deleteSphere();
            }
        }
        //Code if using SpherePooling
        if (isPoolingBool)
        {
            if (timeToSpawn >= waitToSpawn)
            {
                timeToSpawn = 0f;
                spawnSphereWithPool();
            }

            if (timeToDelete >= waitToDelete)
            {
                timeToDelete = 0f;
                deleteSphereWithPool();
            }
        }
    }
    //Code for spawning without pooling
    private Vector3 scale = new Vector3(2,2,2);
    private void spawnSphere()
    {
        if (listOfSpheresToSpawn != null)
        {
            randomSpherePosition = new Vector3(Random.Range(-25, 26), 5, Random.Range(-25, 26));
            sphereInstance = Instantiate(listOfSpheresToSpawn[0], randomSpherePosition, Quaternion.identity);
            sphereInstance.GetComponent<Sphere>().isPooling = isPoolingBool;
            listOfSpawnedSpheres.Add(sphereInstance);
            sphereInstance.SetActive(true);
        }

    }

    private void deleteSphere()
    {
        if (listOfSpawnedSpheres != null)
        {
            int i = Random.Range(0, listOfSpawnedSpheres.Count);
            Debug.LogError("randome range: " + i);
            sphereInstance = listOfSpawnedSpheres[i];
            listOfSpawnedSpheres.Remove(sphereInstance);
            sphereInstance.GetComponent<Sphere>().DestroySphere = true;
        }
    }

    //Code for spawning by using pooling

    private void spawnSphereWithPool()
    {
        randomSpherePosition = new Vector3(Random.Range(-25, 26), 5, Random.Range(-25, 26));
        GameObject sphere = SpherePooling.SpherePool.GetSphereToSpawn();
        if (sphere != null)
        {
            sphere.transform.position = randomSpherePosition;
            sphere.SetActive(true);
            sphere.GetComponent<MeshRenderer>().enabled = true;
            sphere.gameObject.SetActive(true);
        }

    }

    private void deleteSphereWithPool()
    {
        GameObject sphere = SpherePooling.SpherePool.GetSphereToDespawn();
        if (sphere != null)
            sphere.GetComponent<Sphere>().DestroySphere = true;
    }


}
