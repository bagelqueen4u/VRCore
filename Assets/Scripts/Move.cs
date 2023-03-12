using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    // change your serial port
    SerialPort sp = new SerialPort("COM4", 9600);

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
                print(sp.ReadByte());
                // When left button is pushed
                if (sp.ReadByte() == 1)
                {
                    print(sp.ReadByte());
                    transform.Translate(Vector3.left * Time.deltaTime * 5);
                }
                // When right button is pushed
                if (sp.ReadByte() == 50)
                {
                    print(sp.ReadByte());
                    transform.Translate(Vector3.right * Time.deltaTime * 5);
                }
            }
            catch (System.Exception)
            {

            }

        }
    }
}
