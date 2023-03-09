using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBlades : MonoBehaviour
{
    [SerializeField] float fanRotationSpeed = 100f;
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(fanRotationSpeed * Time.fixedDeltaTime, 0f, 0f));
    }
}
