using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlashLight : MonoBehaviour
{
    // Start is called before the first frame update
    bool toggle = false;
    public GameObject flashLight;
    void Start()
    {
        flashLight.SetActive(toggle);
    }

    // Update is called once per frame
    void Update()
    {
        if(UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            toggle = !toggle;
        }
        flashLight.SetActive(toggle);
    }
}
