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

    public void PanCamera(float inX, float inY, float inZ) {
        Vector3 movement = new Vector3(inX * 0.01f * speed, inY * 0.1f * speed, inZ * 0.01f * speed);

        float oldRot = transform.localEulerAngles.x;
        transform.Rotate(-oldRot, 0.0f, 0.0f); //cuts out x axis rotation to allow planar movement in local space
        transform.Translate(movement.x * speed, 0.0f, movement.z * speed);
        transform.Translate(0.0f, movement.y * speed, 0.0f, Space.World);
        transform.Rotate(oldRot, 0.0f, 0.0f);
    }

    public void RotateCamera(float inX, float inY) {
        transform.Rotate(0.0f, inX * rotSpeed, 0.0f, Space.World);
        transform.Rotate(-inY * rotSpeed, 0.0f, 0.0f);
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
