using UnityEngine;
using System.Collections;

public class DirectorScript : MonoBehaviour {

    public GameObject playerChar;
    public GameObject cam;
    public short mode;

    //iso camera
    public float cam_speed;
    public float cam_rotSpeed;
    public Vector3 cam_minBound;
    public Vector3 cam_maxBound;

    private Quaternion startRot;

	// Use this for initialization
	void Start () {
        if(mode == 0) {
            transform.parent = playerChar.GetComponent<Transform>();
            Cursor.lockState = CursorLockMode.Locked; //lock mouse to center of screen on load - * * * * * CURRENTLY NO DISABLE, MUST BE IMPLEMENTED PRIOR TO SUBMISSION * * * * *
            startRot = transform.rotation; //starting rotation of transform
        }
        else if (mode == 1) {
            transform.parent = null;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (mode == 0) {
            float hor, fwd, vert, rot;
            bool running = false;

            if (Input.GetKey(KeyCode.LeftAlt)) {
                transform.Rotate(0.0f, Input.GetAxis("Mouse X"), 0.0f, Space.World); //rotate camera based on mouse movement ONLY WHILE LALT HELD
                rot = Input.GetAxis("Horizontal"); //when LALT HELD - rotational movement of character based on A/D <-/->
            }
            else {
                transform.rotation = Quaternion.Slerp(transform.rotation, startRot, 0.1f); //when LALT NOT HELD - return to default camera position
                rot = Input.GetAxis("Mouse X"); //when LALT NOT HELD - rotational movement of character based on mouse X
                hor = Input.GetAxis("Horizontal"); //when LALT NOT HELD - strafing movement of character based on A/D <-/->
            }

            fwd = Input.GetAxis("Vertical"); //vertical input (forward/back) W / S  ^ / V
            if (Input.GetKeyDown(KeyCode.Space)) { //spacebar press (jump)
                vert = 1.0f;
            }
            else {
                vert = 0.0f;
            }
            if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                running = true;
            }
            if(Input.GetKeyDown(KeyCode.Escape)) {
                if(Cursor.lockState == CursorLockMode.Locked) {
                    Cursor.lockState = CursorLockMode.None;
                }
                else {
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
            //CHARACTER.move(hor, fwd, vert, rot, running); - TO BE IMPLEMENTED
        }
        else if(mode == 1) {
            if(Input.GetButton("Fire2")) {
                OrderMove();
            }
            cam_CheckBounds();
        }
	}

    void FixedUpdate() {
        if(mode == 1) {
            if (Input.GetButton("Fire3")) {
                transform.Rotate(0.0f, Input.GetAxis("Mouse X") * cam_rotSpeed, 0.0f, Space.World);
                transform.Rotate(-Input.GetAxis("Mouse Y") * cam_rotSpeed, 0.0f, 0.0f);
            }
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * 0.01f * cam_speed, Input.GetAxis("Mouse ScrollWheel") * 0.05f * cam_speed, Input.GetAxis("Vertical") * 0.01f * cam_speed);
            transform.Translate(movement.x * cam_speed, 0.0f, movement.z * cam_speed);
            transform.Translate(0.0f, movement.y * cam_speed, 0.0f, Space.World);
        }
    }

    private void OrderMove() {
        Vector3 targetPos;
        Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit)) {
            targetPos = hit.point;
        }
        else targetPos = new Vector3(0, 0, 0);
        //playerChar.move(Vector3 target); - TO BE IMPLEMENTED
    }

    private void cam_CheckBounds() {
        if (transform.position.x < cam_minBound.x) {
            transform.position = new Vector3(cam_minBound.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y < cam_minBound.y) {
            transform.position = new Vector3(transform.position.x, cam_minBound.y, transform.position.z);
        }
        if (transform.position.z < cam_minBound.z) {
            transform.position = new Vector3(transform.position.x, transform.position.y, cam_minBound.z);
        }
        if (transform.position.x > cam_maxBound.x) {
            transform.position = new Vector3(cam_maxBound.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y > cam_maxBound.y) {
            transform.position = new Vector3(transform.position.x, cam_maxBound.y, transform.position.z);
        }
        if (transform.position.z > cam_maxBound.z) {
            transform.position = new Vector3(transform.position.x, transform.position.y, cam_maxBound.z);
        }
    }

}
