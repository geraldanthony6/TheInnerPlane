using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Rock : MonoBehaviour
{
    public float RockPurityLevel;

    public bool isBeingHeld;

    public Vector3 PositionAfterShake;

    public Vector3 Velocity;

    public GameObject[] SandParticles;

    public float ShakeCalcTimer;

    public RockSO RockData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld && ShakeCalcTimer > 0.0f && RockPurityLevel != RockData.MaxPurityLevel)
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

    public void DestroyRock()
    {
        RockGameManager.Instance.RemoveRockFromList(gameObject);
        Destroy(gameObject);
    }

    private void CalculateShakeAmount()
    {
        if (Velocity.magnitude > 70.0f)
        {
            UpdateShakeAmount(1.0f);
        }
    }

    private void UpdateShakeAmount(float ValueToAdd)
    {
        RockPurityLevel += ValueToAdd;

        switch (RockPurityLevel)
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
        
        RockGameManager.Instance.CalculateRockPurity(RockPurityLevel);
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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Crate"))
        {
            Debug.Log("Placed rock in crate");
            
            RockGameManager.Instance.SellRock(this);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Crate"))
        {
            RockGameManager.Instance.RemoveRockFromList(this.gameObject);
        }
    }
}
