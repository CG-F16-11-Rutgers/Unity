using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    public GameObject mainCamera; private CameraController camCtrl;

	// Use this for initialization
	void Start () {
        camCtrl = mainCamera.GetComponent<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        UpdateCamera();
    }

    private void UpdateCamera() {
        if (Input.GetButton("Fire3")) {
            camCtrl.RotateCamera(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
        camCtrl.PanCamera(Input.GetAxis("Horizontal"), Input.GetAxis("Mouse ScrollWheel"), Input.GetAxis("Vertical"));
    }
}
