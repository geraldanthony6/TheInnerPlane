using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectActionManager : MonoBehaviour
{
    public GameObject ActionCanvas;

    public GameObject Object;

    public GameObject Player;
    
    public bool isCurrentlyBeingInteractedWith;

    public List<ObjectAction> AvailableActions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region PlayerActions
    public void PerformActionOne()
    {
        SpriteRenderer PlayerSprite = GetComponent<SpriteRenderer>();
        PlayerSprite.color = Color.blue;
    }

    public void PerformActionTwo()
    {
        Object.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
    }

    public void PerformActionThree()
    {
        Object.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        SpriteRenderer PlayerSprite = GetComponent<SpriteRenderer>();
        PlayerSprite.color = Color.white;
    }
    #endregion

    #region RandomObjectActions

    public void PerformObjectActionOne()
    {
        SpriteRenderer ObjectSprite = GetComponent<SpriteRenderer>();
        ObjectSprite.color = Color.green;
    }
    
    public void PerformObjectActionTwo()
    {
        SpriteRenderer PlayerSprite = Player.GetComponent<SpriteRenderer>();
        PlayerSprite.color = Color.red;
    }

    public void PerformObjectActionThree()
    {
        SpriteRenderer ObjectSprite = GetComponent<SpriteRenderer>();
        ObjectSprite.color = Color.white;
        SpriteRenderer PlayerSprite = Player.GetComponent<SpriteRenderer>();
        PlayerSprite.color = Color.white;
    }

    #endregion

    private void OnMouseDown()
    {
        Debug.Log("Clicked object, open the menu for the object if player and randomly select if NPC");
        if (!isCurrentlyBeingInteractedWith)
        {
            isCurrentlyBeingInteractedWith = true;
            ActionCanvas.SetActive(true);
            Player.GetComponent<ObjectActionManager>().isCurrentlyBeingInteractedWith = true;
        } else if (isCurrentlyBeingInteractedWith)
        {
            isCurrentlyBeingInteractedWith = false;
            ActionCanvas.SetActive(false);
            Player.GetComponent<ObjectActionManager>().isCurrentlyBeingInteractedWith = false;
        }
    }
}
