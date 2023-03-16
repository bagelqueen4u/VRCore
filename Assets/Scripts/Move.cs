using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    // change your serial port
    SerialPort sp = new SerialPort("COM4", 9600);
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveForce = 5f;
    [SerializeField] Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 100; // In my case, 100 was a good amount to allow quite smooth transition. 
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                //print(sp.ReadByte());
                // When left button is pushed
                if (sp.ReadByte() == 1)
                {
                    //print(sp.ReadByte());
                    if (null == rb)
                    {
                        return;
                    }
                    if (null == animation)
                    {
                        return;
                    }
                    rb.AddForce(transform.up * moveForce);
/*                    if(!animation.isPlaying)
                    {
                        animation.Play();
                    }*/
                    //rb.velocity = new Vector3(rb.velocity.x, moveForce, rb.velocity.z);
                    //transform.Translate(Vector3.up * Time.deltaTime * 5);
                }
                else
                {
                    if (null == animation)
                    {
                        return;
                    }
/*                    if(animation.isPlaying) 
                    {
                        animation.Stop();
                    }*/

                }
/*                // When right button is pushed
                if (sp.ReadByte() == 2)
                {
                    //print(sp.ReadByte());
                    transform.Translate(Vector3.right * Time.deltaTime * 5);
                }*/
            }
            catch (System.Exception)
            {

            }

        }
    }
}
