using UnityEngine;

public class Webcam : MonoBehaviour {
	void Start () {
        WebCamTexture webcamTexture = new WebCamTexture(1280,720);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }
}
