﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectSpawn : MonoBehaviour
{

    public GameObject[] VFX; //Array of gameobjects to spawn
    private GameObject VFX_instance; //

    /******* SPAWN POINT INFORMATION *******/
    public GameObject spawnpoint_ABOVEGROUND;
    private Transform transform_ABOVEGROUND;
    private GameObject spawnPoint_GROUNDED;
    private Transform spawnTransform_GROUNDED;


    void Start()
    {
        spawnPoint_GROUNDED = this.gameObject;
        spawnTransform_GROUNDED = spawnPoint_GROUNDED.transform;
        transform_ABOVEGROUND = spawnpoint_ABOVEGROUND.transform;
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public void CallEffect00()
    {
        ///ARCANE BLAST
        GarbageCollector(spawnpoint_ABOVEGROUND, spawnPoint_GROUNDED);
        InstanceCreation(VFX[0], spawnPoint_GROUNDED);
        VFX[0].SetActive(true);  
    }

    public void CallEffect01()
    {
        //SPARKS SPRAY
        GarbageCollector(spawnpoint_ABOVEGROUND, spawnPoint_GROUNDED);
        InstanceCreation(VFX[1], spawnpoint_ABOVEGROUND);
        VFX[1].SetActive(true);
    }


    public void CallEffect02()
    {
        //default vfx graph
        GarbageCollector(spawnpoint_ABOVEGROUND, spawnPoint_GROUNDED);
        InstanceCreation(VFX[2], spawnpoint_ABOVEGROUND);
        VFX[2].SetActive(true);
    }

    public void CallEffect03()
    {
        //hexagonal shield
        GarbageCollector(spawnpoint_ABOVEGROUND, spawnPoint_GROUNDED);
        InstanceCreation(VFX[3], spawnpoint_ABOVEGROUND);
        VFX[3].SetActive(true);
    }

    public void CallEffect04()
    {
        //default vfx graph
        GarbageCollector(spawnpoint_ABOVEGROUND, spawnPoint_GROUNDED);
        InstanceCreation(VFX[4], spawnpoint_ABOVEGROUND);
        VFX[4].SetActive(true);
    }

    public void CallEffect05()
    {
        //default vfx graph
        GarbageCollector(spawnpoint_ABOVEGROUND, spawnPoint_GROUNDED);
        InstanceCreation(VFX[5], spawnpoint_ABOVEGROUND);
        VFX[5].SetActive(true);
    }



    /************************* FUNCTIONS TO HANDLE BACKGROUND PROCESSES *************************/


    //Create an instance of the gameobject and parent it to the spawn point of the scene
    public void InstanceCreation(GameObject toSpawn, GameObject parent)
    {
        GameObject _instance = Instantiate(toSpawn, parent.transform.localPosition, Quaternion.identity);
        _instance.transform.parent = GameObject.Find(parent.name).transform;
    }

    //check the parent and destroy any instances of children in it
    public void GarbageCollector(GameObject parent1, GameObject parent2)
    {
        if(parent1.transform.childCount > 0)
        {
            foreach(Transform child in parent1.transform)
            {
                Destroy(child.gameObject);
            }
        }

        else if (parent2.transform.childCount > 0)
        {
            foreach (Transform child in parent2.transform)
            {
                Destroy(child.gameObject);
            }
        }

        else
        {
            return;
        }
    }
}
