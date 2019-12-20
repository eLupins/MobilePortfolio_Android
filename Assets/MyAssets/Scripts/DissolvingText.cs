using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolvingText : MonoBehaviour
{

    public GameObject TextToDissolve;
    public ParticleSystem dissolvingParticles;
    public int particleCount = 2000;
    public float timer = 3.0f;

    private void Start()
    {       
        StartCoroutine(DissolvePause(timer));
    }

    IEnumerator DissolvePause(float time)
    {
        yield return new WaitForSeconds(time);
        Play();
    }

    void Play()
    {
        dissolvingParticles.Clear();
        TextToDissolve.gameObject.SetActive(false);
        dissolvingParticles.Emit(particleCount);
    }
}
