using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float ShakeAmount;

    public bool isBeingHeld;

    public Vector3 PositionBeforeShake;

    public Vector3 PositionAfterShake;

    public Vector3 Velocity;

    public GameObject[] SandParticles;

    public float ShakeCalcTimer;

    public float MaxCleanAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld && ShakeCalcTimer > 0.0f && ShakeAmount != MaxCleanAmount)
        {
            CalculateShakeAmount();
        }

        if (isBeingHeld && ShakeCalcTimer <= 0.0f)
        {
            ShakeCalcTimer = 2.0f;
        }

        if (ShakeCalcTimer > 0.0f)
        {
            ShakeCalcTimer -= Time.deltaTime;
        }
    }

    private void CalculateShakeAmount()
    {
        if (Velocity.magnitude > 100.0f)
        {
            UpdateShakeAmount(1.0f);
        }
    }

    private void UpdateShakeAmount(float ValueToAdd)
    {
        ShakeAmount += ValueToAdd;

        switch (ShakeAmount)
        {
            case 250.0f:
                Destroy(SandParticles[0]);    
            break;    
            case 500.0f:
                Destroy(SandParticles[1]);    
            break;     
            case 1000.0f:
                Destroy(SandParticles[2]);  
            break;    
        }
    }

    private void OnMouseDown()
    {
        isBeingHeld = true;
        ShakeCalcTimer = 0.3f;
    }

    private void OnMouseDrag()
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        touchPosition.z = transform.position.z; // Ensure the z-coordinate matches the object's position

        // Calculate velocity
        Velocity = (touchPosition - PositionAfterShake) / Time.deltaTime;

        // Update the object's position
        transform.position = touchPosition;

        // Update the last position
        PositionAfterShake = touchPosition;
        
        Debug.Log(Velocity.magnitude);
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ShakeWall"))
        {
            UpdateShakeAmount(1);
        }

        if (other.CompareTag("Crate"))
        {
            RockGameManager.Instance.UpdateLevelScore();
            Debug.Log("Placed rock in crate");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Crate"))
        {
            Debug.Log("Placed rock in crate");
            RockGameManager.Instance.CalculateRockPurity(ShakeAmount);
        }
    }
}
