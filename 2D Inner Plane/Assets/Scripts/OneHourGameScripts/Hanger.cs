using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanger : MonoBehaviour
{
    [SerializeField] private ColorIndicator CurrentHangerColor;
    // Start is called before the first frame update
    void Start()
    {
        switch (CurrentHangerColor)
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

    public ColorIndicator GetCurrentHangerColor()
    {
        return CurrentHangerColor;
    }
    
    public void UpdateCurrentHangerColor(ColorIndicator NewEnum)
    {
        CurrentHangerColor = NewEnum;
    }
}
