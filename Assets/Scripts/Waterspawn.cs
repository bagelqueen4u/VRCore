using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterspawn : MonoBehaviour
{
    [SerializeField] bool toggle = false;
    [SerializeField] ParticleSystem _particleSystem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            toggle = !toggle;
        }
        SpawnParticles();
    }
    void SpawnParticles()
    {
        if(toggle)
        {
            if(!_particleSystem.isPlaying)
            {
                _particleSystem.Play();
            }
        }
        if(!toggle)
        {
            if(_particleSystem.isPlaying)
            {
                _particleSystem.Stop();
            }
        }
    }
}
