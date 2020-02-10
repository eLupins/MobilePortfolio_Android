using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideMenu : MonoBehaviour
{

    private bool isHidden = false;
    private IEnumerator coroutine;
    public float timer = 2f;
    Vector3 startPos, hidePos;
    public Button hideButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
