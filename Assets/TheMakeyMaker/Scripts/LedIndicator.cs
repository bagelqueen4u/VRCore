using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LedIndicator : MonoBehaviour
{
    public MakeyManager.Key respondTo;
    private Image _image;
    
    void Start()
    {
        _image = GetComponent<Image>();
    }
    void Update()
    {
        if (MakeyManager.Instance.GetKey(respondTo))
        {
            _image.color = Color.green;
        }
        else
        {
            _image.color = Color.black;
        }
    }
}
