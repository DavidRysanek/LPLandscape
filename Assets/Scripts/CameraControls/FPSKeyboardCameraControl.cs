using UnityEngine;


public class FPSKeyboardCameraControl : MonoBehaviour
{
    float sensitivity = 15f;


    void LateUpdate()
    {
        float dz = 0;

        if (Input.GetKey(KeyCode.W)) {
            dz = Time.deltaTime * sensitivity;
        }
        if (Input.GetKey(KeyCode.S)) {
            dz = -Time.deltaTime * sensitivity;
        }

        if (System.Math.Abs(dz) > 0) {
            // Transalte camera in camera facing direction
            transform.Translate(transform.forward * dz, Space.World);
        }


        float dx = 0;

        if (Input.GetKey(KeyCode.A)) {
            dx = -Time.deltaTime * sensitivity;
        }
        if (Input.GetKey(KeyCode.D)) {
            dx = Time.deltaTime * sensitivity;
        }

        if (System.Math.Abs(dx) > 0) {
            // Translate camera left/right
            transform.Translate(transform.right * dx, Space.World);
        }


        float dy = 0;

        if (Input.GetKey(KeyCode.Q)) {
            dy = -Time.deltaTime * sensitivity;
        }
        if (Input.GetKey(KeyCode.E)) {
            dy = Time.deltaTime * sensitivity;
        }

        if (System.Math.Abs(dy) > 0) {
            // Translate camera up/down
            transform.Translate(transform.up * dy, Space.World);
        }
    }
}
