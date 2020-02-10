using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Shield : MonoBehaviour
{
    public float x_Pos;
    public float z_Pos;
    public float height;
    public float speed;
    private Vector3 pos;
    private float new_Y;
    private GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        sphere = gameObject;
        pos = sphere.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float new_Y = Mathf.Sin(Time.time * speed);
        sphere.transform.position = new Vector3(x_Pos, new_Y, z_Pos) * height;
    }
}
