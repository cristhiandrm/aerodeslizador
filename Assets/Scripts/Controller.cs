using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float aceleration;
    public float rotationRate;

    public float turnRotationAngle;
    public float turnRotationSeekSpeed;

    private float rotationVelocity;
    private float GroundAngleVelocity;

    public Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dash"))
        {
            Debug.Log("aceleration time");
            aceleration += 5000;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dash"))
        {
            Debug.Log("desaceleration time");
            aceleration -= 5000;
        }
    }
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.up * -1, 3f))
        {
            rigidbody.drag = 1;
            Vector3 forwardForce = transform.forward * aceleration * Input.GetAxis("Vertical");

            rigidbody.AddForce(forwardForce);
        }else 
        {
            rigidbody.drag = 0;
        }

        Vector3 turnTorque=Vector3.up*rotationRate*Input.GetAxis("Horizontal");
        turnTorque = turnTorque * Time.deltaTime * rigidbody.mass;
        rigidbody.AddTorque(turnTorque);

        Vector3 newRotation = transform.eulerAngles;
        newRotation.z = Mathf.SmoothDampAngle(newRotation.z, Input.GetAxis("Horizontal") + -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
        transform.eulerAngles = newRotation;
    }
}
