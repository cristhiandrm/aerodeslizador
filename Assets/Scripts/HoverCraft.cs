using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverCraft : MonoBehaviour
{
    public float thrusterstrength;
    public float thrusterDistance;
    private float thrusterstrengthOn;
    private float thrusterDistanceOn;
    public Rigidbody rigidbody;
    public Transform[] Thrusters;
    [SerializeField] private bool engine;
    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        engine = false;
        thrusterstrengthOn = thrusterstrength;
        thrusterDistanceOn = thrusterDistance;
        thrusterstrength = 0;
        thrusterDistance = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            thrusterstrength = 0;
            thrusterDistance = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            thrusterstrength = thrusterstrengthOn;
            thrusterDistance = thrusterDistanceOn;
        }
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        foreach (Transform thruster in Thrusters)
        {
            Vector3 downwardForce;
            float distancePercentage;
            if (Physics.Raycast(thruster.position, thruster.up * -1, out hit, thrusterDistance)) 
            {
                distancePercentage = 1 - (hit.distance / thrusterDistance);
                downwardForce = transform.up * thrusterstrength * distancePercentage;
                downwardForce = downwardForce * Time.deltaTime * rigidbody.mass;
                rigidbody.AddForceAtPosition(downwardForce, thruster.position);
            }
        }
    }
}
