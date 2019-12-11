using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOfLight : MonoBehaviour
{
    public ParticleSystem PS_StartingSystem;
    public float Ball_ChargeTime;
    public float Ball_MaxSize;
    public float Ball_DropSpeed;
    public Vector3 EndDrop;
    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = gameObject;
        ball.transform.localScale = new Vector3(0f, 0f, 0f);
        ball.SetActive(true);
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position, Vector3.up);
        StartCoroutine(ScaleOverTime(Ball_ChargeTime, Ball_DropSpeed));      
    }

    IEnumerator ScaleOverTime(float time, float droptime)
    {
        Vector3 originalScale = ball.transform.localScale;
        Vector3 endScale = new Vector3(Ball_MaxSize, Ball_MaxSize, Ball_MaxSize);
        float curTime = 0f;

        Vector3 original_Y = new Vector3(-0.026f, 0f, 0.85f);
        //float destination_Y = 0f;
        

        do
        {
            ball.transform.localScale = Vector3.Lerp(originalScale, endScale, curTime / time);
            ball.transform.localPosition = Vector3.Lerp(ball.transform.localPosition, EndDrop, curTime / droptime);
            curTime += Time.deltaTime;
            yield return null;


        } while (curTime <= time);

        ball.SetActive(false);

    }
}
