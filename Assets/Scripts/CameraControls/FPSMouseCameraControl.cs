using UnityEngine;

public class FPSMouseCameraControl : MonoBehaviour {

    float sensitivity = 2f;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            // Rotation around X axis (up/down)
            float pitch = Input.GetAxis("Mouse Y") * sensitivity;
            transform.Rotate(-pitch * Vector3.right, Space.Self);

            // Rotation around Y axis (left/right)
            float yaw = Input.GetAxis("Mouse X") * sensitivity;
            transform.Rotate(yaw * Vector3.up, Space.World);
        }
    }
}
