using System;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] private float BoatSpeed = 100.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * z * BoatSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * x * BoatSpeed * Time.deltaTime);
    }


}
