using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpherePooling : MonoBehaviour
{
    public static SpherePooling SpherePool;
    public GameObject SphereObject;
    public List<GameObject> listOfSpheresToSpawn;

    private int amountToSpawn = 30;
    private int attemptsInt = 0;
    private int maxAttemptsInt;
    private int amountOfSpawnedSpheres;



    [SerializeField] private IsPooling isPooling;
    private bool isPoolingBool;

    private void Awake()
    {
        SpherePool = this;
        isPoolingBool = isPooling.IsPoolingBool;
    }

    void Start()
    {
        if (isPoolingBool == true)
        {
            listOfSpheresToSpawn = new List<GameObject>();
            GameObject sphere;
            for (int i = 0; i < amountToSpawn; i++)
            {
                sphere = Instantiate(SphereObject);
                sphere.SetActive(false);
                sphere.GetComponent<Sphere>().isPooling = isPoolingBool;
                listOfSpheresToSpawn.Add(sphere);
            }
            maxAttemptsInt = listOfSpheresToSpawn.Count;
        }
    }

    public GameObject GetSphereToSpawn()
    {
        checkIfNeedToAddSpheres();
        while (attemptsInt < maxAttemptsInt)
        {
            int i = Random.Range(0, listOfSpheresToSpawn.Count);
            if (!listOfSpheresToSpawn[i].activeInHierarchy)
            {
                return listOfSpheresToSpawn[i];
            }
        }
        return null;
    }
    public GameObject GetSphereToDespawn()
    {
        while (attemptsInt < maxAttemptsInt)
        {
            int i = Random.Range(0, listOfSpheresToSpawn.Count);
            if (listOfSpheresToSpawn[i].activeInHierarchy)
            {
                return listOfSpheresToSpawn[i];
            }
        }
        return null;
    }

    private void checkIfNeedToAddSpheres()
    {
        amountOfSpawnedSpheres = 0;
        for (int i =0; i< maxAttemptsInt; i++)
        {
            if (!listOfSpheresToSpawn[i].activeInHierarchy)
            {
                amountOfSpawnedSpheres++;
            }
        }
        if(amountOfSpawnedSpheres <=1)
        {
            IfAllSpheresActive();
        }
    }
    public void IfAllSpheresActive()
    {
        for (int i = 0; i < listOfSpheresToSpawn.Count; i++)
        {
            listOfSpheresToSpawn[i].SetActive(false);
        }
    }

}
