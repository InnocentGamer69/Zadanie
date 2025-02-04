using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public bool DestroySphere = false;
    public bool isPooling = false;
    private float timeToShrink = 5f;
    private float destroySzie = 0.1f;
    private GameObject sphere;
    private Vector3 startingScale = new Vector3(2,2,2);


    private void Start()
    {
        sphere = this.gameObject;
        startingScale = sphere.transform.localScale;
    }

    private void Update()
    {
        if(DestroySphere == true)
        {
            sphere.transform.localScale -= Vector3.one * timeToShrink * Time.deltaTime;
            if (transform.localScale.x <= destroySzie)
            {
                DestroySphere = false;
                if(!isPooling)
                    Destroy(sphere);
                else if (isPooling)
                {
                    sphere.transform.localScale = startingScale;
                    sphere.SetActive(false);
                }
            }
        }
    }
}
