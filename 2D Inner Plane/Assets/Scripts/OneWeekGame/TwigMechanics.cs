using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwigMechanics : MonoBehaviour
{
    [SerializeField] private bool isInHand;

    public bool GetIsInHand()
    {
        return isInHand;
    }
    
    public void SetIsInHand(bool NewBool)
    {
        isInHand = NewBool;
    }
}
