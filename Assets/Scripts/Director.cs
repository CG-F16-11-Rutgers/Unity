﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Director : MonoBehaviour {

    public GameObject mainCamera; private CameraController camCtrl;

    private List<GameObject> selectedObjects = new List<GameObject>();
    private GameObject dynamicOb;
    private bool objectMoveFocus;

	// Use this for initialization
	void Start () {
        camCtrl = mainCamera.GetComponent<CameraController>();
        objectMoveFocus = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1")) {
            SelectRay();
        }
        if (Input.GetButton("Fire2")) {
            OrderMove();
        }
        if (!objectMoveFocus) {
            MoveCamera();
        }
        else {
            dynamicOb.GetComponent<DObsticalController>().move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }

    private void MoveCamera() {
        if (Input.GetButton("Fire3")) {
            camCtrl.RotateCamera(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
        camCtrl.PanCamera(Input.GetAxis("Horizontal"), Input.GetAxis("Mouse ScrollWheel"), Input.GetAxis("Vertical"));
    }

    private void SelectRay() {
        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit)) {
            GameObject hitObject = hit.transform.gameObject;
            if(hitObject.CompareTag("Player")) {
                selectedObjects.Add(hitObject);
                hitObject.GetComponent<SingleAgentScript>().select();
            }
            else if (hitObject.CompareTag("ob")) {
                DeselectAll();
                objectMoveFocus = true;
                dynamicOb = hitObject;
                dynamicOb.GetComponent<DObsticalController>().select();
            }
            else {
                DeselectAll();
            }
        }
    }

    private void DeselectAll() {
        if (objectMoveFocus) {
            dynamicOb = null;
            objectMoveFocus = false;
        }
        for (int i = 0; i < selectedObjects.Count; i++) {
            GameObject obj = selectedObjects[i];
            if (obj.CompareTag("Player")) {
                obj.GetComponent<SingleAgentScript>().deselect();
            }
        }
        selectedObjects.Clear();
    }

    private void OrderMove() {
        Vector3 targetPos;
        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit)) {
            targetPos = hit.point;
        }
        else targetPos = new Vector3(0, 0, 0);
        for (int i=0; i<selectedObjects.Count;i++) {
            GameObject obj = selectedObjects[i];
            if(obj.CompareTag("Player")) {
                obj.GetComponent<SingleAgentScript>().moveToTarget(targetPos);
            }
        }
    }

}
