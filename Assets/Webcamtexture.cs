using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWebCam : MonoBehaviour
{
  [SerializeField]
  private UnityEngine.UI.RawImage _rawImage;

  void Start()
  {
      WebCamDevice[] devices = WebCamTexture.devices;

      // for debugging purposes, prints available devices to the console
      for (int i = 0; i < devices.Length; i++)
      {
          print("Webcam available: " + devices[i].name);
      }

      WebCamTexture tex = new WebCamTexture(devices[0].name);

      RawImage m_RawImage;
      m_RawImage = GetComponent<RawImage>();
      m_RawImage.texture = tex;
      tex.Play();
  }
}