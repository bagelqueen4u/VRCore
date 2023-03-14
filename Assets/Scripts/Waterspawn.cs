using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class Waterspawn : MonoBehaviour
{
    [SerializeField] bool toggle = false;
    [SerializeField] ParticleSystem _particleSystem;
    // change your serial port
    SerialPort sp = new SerialPort("COM3", 9600);
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 100; // In my case, 100 was a good amount to allow quite smooth transition. 
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
        if (sp.IsOpen)
        {
            try
            {
                // When left button is pushed
                if (sp.ReadByte() == 48 && toggle)
                {
                    if (_particleSystem.isPlaying)
                    {
                        toggle = false;
                        _particleSystem.Stop();
                    }
                }
                // When right button is pushed
                if (sp.ReadByte() == 49 && !toggle)
                {
                    if (!_particleSystem.isPlaying)
                    {
                        toggle = true;
                        _particleSystem.Play();
                    }
                }
            }
            catch (System.Exception)
            {

            }

        }
    }
}
