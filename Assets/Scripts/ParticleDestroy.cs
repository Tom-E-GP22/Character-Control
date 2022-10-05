using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    private ParticleSystem partSys;
    private int frame = 0;
    void Start()
    {
        partSys = GetComponent<ParticleSystem>();   
    }

    void Update()
    {
        frame++;
        frame %= 6;
        if(frame %6 == 0)
        {
            if (!partSys.isPlaying)
                Destroy(gameObject);
        }
    }
}
