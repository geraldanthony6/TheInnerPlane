using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hat : MonoBehaviour
{
    [SerializeField] private Hanger HoveredHanger;

    [SerializeField] private ColorIndicator CurrentHatColor;

    private bool isPlacedOnHanger;
    // Start is called before the first frame update
    void Start()
    {
        switch (CurrentHatColor)
        {
            case ColorIndicator.Red:
                gameObject.GetComponent<SpriteRenderer>().color = Color.red; 
            break;   
            case ColorIndicator.Blue:
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue; 
            break;      
            case ColorIndicator.Green:
                gameObject.GetComponent<SpriteRenderer>().color = Color.green; 
            break;    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCurrentHatColor(ColorIndicator NewEnum)
    {
        CurrentHatColor = NewEnum;
    }

    private void OnMouseDrag()
    {
        if (!isPlacedOnHanger)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            transform.position = worldPosition;
        }
    }

    private void OnMouseUp()
    {
        if (HoveredHanger && !isPlacedOnHanger)
        {
            GameManager.Instance.UpdateScore(1);
            isPlacedOnHanger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hanger") && other.gameObject.GetComponent<Hanger>().GetCurrentHangerColor() == CurrentHatColor)
        {
            HoveredHanger = other.gameObject.GetComponent<Hanger>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hanger"))
        {
            HoveredHanger = null;
        }
    }
}
