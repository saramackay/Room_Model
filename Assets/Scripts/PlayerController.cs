using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public Camera camera;

    [Header("Configurations")]
    public float walkSpeed;
    public float runSpeed;

    [Header("Runtime")]
    Vector3 newVelocity;


    //Start is called before the first frame update
    void Start()  {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        //Horizontal rotation
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);  //adjust the multiplier for different rotation speed
   
        newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;

        rb.velocity = transform.TransformDirection(newVelocity);
    
    }
    void LateUpdate() { 
        //Vertical rotation
        Vector3 e = head.eulerAngles;
        e.x -=Input.GetAxis("Mouse Y") * 2f;  //Edit the multiplier to adjust the rotate speed
        e.x = RestrictAngle(e.x, -85f, 85f);  // This is clamped to 85 degrees. you may edit this.
        head.eulerAngles = e;
    }

    // A helper function
    //Clamp the vertical head rotation (prevent bending backwards)
    public static float RestrictAngle(float angle, float angleMin, float angleMax) {
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;

        return angle;
    }

}
