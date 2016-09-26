using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float speed;
    public float rotSpeed;

    public Vector3 minBound;
    public Vector3 maxBound;

	// Use this for initialization
	void Start () {
	}
	
    void Update() {
        CheckBounds();
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetButton("Fire3")) {
            transform.Rotate(0.0f, Input.GetAxis("Mouse X") * rotSpeed, 0.0f, Space.World);
            transform.Rotate(-Input.GetAxis("Mouse Y") * rotSpeed, 0.0f, 0.0f);
        }
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * 0.01f * speed, Input.GetAxis("Mouse ScrollWheel") * 0.05f * speed, Input.GetAxis("Vertical") * 0.01f * speed);
        transform.Translate(movement.x * speed, 0.0f, movement.z * speed);
        transform.Translate(0.0f, movement.y * speed, 0.0f, Space.World);
	}

    private void CheckBounds() {
        if (transform.position.x < minBound.x) {
            transform.position = new Vector3(minBound.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y < minBound.y) {
            transform.position = new Vector3(transform.position.x, minBound.y, transform.position.z);
        }
        if (transform.position.z < minBound.z) {
            transform.position = new Vector3(transform.position.x, transform.position.y, minBound.z);
        }
        if (transform.position.x > maxBound.x) {
            transform.position = new Vector3(maxBound.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y > maxBound.y) {
            transform.position = new Vector3(transform.position.x, maxBound.y, transform.position.z);
        }
        if (transform.position.z > maxBound.z) {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxBound.z);
        }
    }
}
