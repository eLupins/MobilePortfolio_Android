using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{

    public GameObject[] VFX;
    private GameObject VFX_instance;
    private GameObject spawnPoint;
    private Transform spawnTransform;

    /*
    void Awake()
    {
        //foreach (GameObject element in VFX) element.SetActive(false);
    }
    */
    // Start is called before the first frame update

    void Start()
    {
        spawnPoint = this.gameObject;
        spawnTransform = spawnPoint.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallEffect00()
    {

      
        /*
        foreach(GameObject element in VFX)
        {
            if(element.tag == "Portfolio_Piece" && element.activeInHierarchy==true)
            {
                Destroy(element);
            }
        }
        */
      
        //we need a garbage cleaner to remove vfx if other vfx exist in the scene and to avoid duplicates from spawning

        Instantiate(VFX[0], spawnTransform.localPosition, Quaternion.identity);
        VFX[0].SetActive(true);

       
    }

    public void CallEffect01()
    {
  
        Instantiate(VFX[1], spawnTransform.localPosition, Quaternion.identity);
        VFX[1].SetActive(true);
    }


    /*We need a garbage collector to clean out VFX when a new one is going to be loaded.
     We also need it to avoid having duplicate effects spawned into the scene. */
    public void GarbageCollector(GameObject garbage)
    {

    }
}
