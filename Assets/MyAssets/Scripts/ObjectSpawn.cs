using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectSpawn : MonoBehaviour
{

    public GameObject[] VFX; //Array of gameobjects to spawn
    private GameObject _instance; //

    /******* SPAWN POINT INFORMATION *******/
    public GameObject spawnpoint_ABOVEGROUND;
    public GameObject spawnpoint_GROUNDED;
    private Transform transform_ABOVEGROUND;
    private Transform transform_GROUNDED;
 


    void Start()
    {
        transform_ABOVEGROUND = spawnpoint_ABOVEGROUND.transform;
        transform_GROUNDED = spawnpoint_GROUNDED.transform;
      
        //transform_FACECAM = spawnpoint_FACECAM.transform;
    }

    /************************* EFFECT CALLS *************************/

    public void CallEffect00()
    {
        ///ARCANE BLAST
        GarbageCollector(spawnpoint_ABOVEGROUND, spawnpoint_GROUNDED);
        InstanceCreation(VFX[0], spawnpoint_GROUNDED);
        VFX[0].SetActive(true);  
    }

    public void CallEffect01()
    {
        //SPARKS SPRAY
        GarbageCollector(spawnpoint_ABOVEGROUND, spawnpoint_GROUNDED);
        InstanceCreation(VFX[1], spawnpoint_ABOVEGROUND);
        VFX[1].SetActive(true);
    }


    public void CallEffect02()
    {
        //simple vfx graph
        GarbageCollector(spawnpoint_ABOVEGROUND, spawnpoint_GROUNDED);
        InstanceCreation(VFX[2], spawnpoint_ABOVEGROUND);
        VFX[2].SetActive(true);
    }

    public void CallEffect03()
    {
        //hexagonal shield
        GarbageCollector(spawnpoint_ABOVEGROUND, spawnpoint_GROUNDED);
        GameObject ins = InstanceCreation(VFX[3], spawnpoint_GROUNDED);
        //Rotate 180deg because for some reason the prefab likes to spawn facing away from the camera
        ins.transform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
        VFX[3].SetActive(true);
    }

    public void CallEffect04()
    {
        //dissolving text
        GarbageCollector(spawnpoint_ABOVEGROUND, spawnpoint_GROUNDED);
        InstanceCreation(VFX[4], spawnpoint_ABOVEGROUND);
        _instance.transform.localRotation = Quaternion.Euler(12.209f, 0, 0);
        VFX[4].SetActive(true);

        while(VFX[4].activeSelf == true)
        {
            Reload(VFX[4], spawnpoint_ABOVEGROUND);
        }
    }

    public void CallEffect05()
    {
        //water shader
        GarbageCollector(spawnpoint_ABOVEGROUND, spawnpoint_GROUNDED);
        InstanceCreation(VFX[5], spawnpoint_ABOVEGROUND);
        //_instance.transform.localRotation = Quaternion.Euler(-68.375f, 0, 0);
        VFX[5].SetActive(true);
    }

    public void CallEffect06()
    {
        //swarm effect
        GarbageCollector(spawnpoint_ABOVEGROUND, spawnpoint_GROUNDED);
        InstanceCreation(VFX[2], spawnpoint_ABOVEGROUND);
        VFX[2].SetActive(true);
    }

    /************************* FUNCTIONS TO HANDLE BACKGROUND PROCESSES *************************/


    //Create an instance of the gameobject and parent it to the spawn point of the scene
    public GameObject InstanceCreation(GameObject toSpawn, GameObject parent)
    {
        _instance = Instantiate(toSpawn, parent.transform.position, parent.transform.rotation);
        _instance.transform.parent = GameObject.Find(parent.name).transform;
        return _instance;
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

        /*
        else if (parent3.transform.childCount > 0)
        {
            foreach (Transform child in parent3.transform)
            {
                Destroy(child.gameObject);
            }
        }
        */
        else
        {
            return;
        }
    }
    
    public void Reload(GameObject vfx, GameObject parent)
    {
        while(parent.transform.childCount == 1){

            Debug.Log("Chlld exists:" + vfx);

        }
    }
}
