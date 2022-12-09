using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overcraft : MonoBehaviour
{
    public List<GameObject> springs;
    public Rigidbody rb;
    public GameObject prop;
    public GameObject cm;
    private void Start()
    {
        rb.centerOfMass = cm.transform.localPosition;

    }

    private void Update()
    {
        rb.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical") * 400f, prop.transform.position);
        rb.AddTorque(Time.deltaTime * transform.TransformDirection(Vector3.up) * Input.GetAxis("Horizontal") * 300f);
        Debug.Log(Input.GetAxis("Vertical"));
        foreach (GameObject spring in springs)
        {
            RaycastHit hit;
            if(Physics.Raycast(spring.transform.position, transform.TransformDirection(Vector3.down), out hit, 3f))
            {
                rb.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.up) * Mathf.Pow(3f - hit.distance, 2) / 3f * 250f, spring.transform.position);
            }
            //Debug.Log(hit.distance);
        }
        rb.AddForce(-Time.deltaTime * transform.TransformVector(Vector3.right) * transform.InverseTransformVector(rb.velocity).x * 5f);
    }
}
