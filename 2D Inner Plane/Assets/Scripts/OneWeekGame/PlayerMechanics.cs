using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    [SerializeField]private Transform _leftHandPosition;

    [SerializeField] private Transform _rightHandPosition;

    [SerializeField] private bool _isNearTwig;

    [SerializeField] private GameObject _currentTwigBeingHovered;

    [SerializeField] private GameObject _itemInLeftHand;
    [SerializeField] private GameObject _itemInRightHand;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isNearTwig && Input.GetKeyDown(KeyCode.Q))
        {
            if (!_itemInLeftHand && !_currentTwigBeingHovered.GetComponent<TwigMechanics>().GetIsInHand())
            {
                //Move the twig to the left hand transform
                _itemInLeftHand = _currentTwigBeingHovered;
                _itemInLeftHand.transform.SetParent(_leftHandPosition);
                _itemInLeftHand.transform.SetPositionAndRotation(_leftHandPosition.position, _leftHandPosition.rotation);
                _currentTwigBeingHovered.GetComponent<TwigMechanics>().SetIsInHand(true);
                _currentTwigBeingHovered = null;
                _isNearTwig = false;
            }
        } else if (_itemInLeftHand && Input.GetKeyDown(KeyCode.Q))
        {
            _leftHandPosition.DetachChildren();
            _itemInLeftHand.GetComponent<TwigMechanics>().SetIsInHand(false);
            _itemInLeftHand = null;
        }

        if (_isNearTwig && Input.GetKeyDown(KeyCode.E))
        {
            if (!_itemInRightHand && !_currentTwigBeingHovered.GetComponent<TwigMechanics>().GetIsInHand())
            {
                //Move the twig to the right hand transform
                _itemInRightHand = _currentTwigBeingHovered;
                _itemInRightHand.transform.SetParent(_rightHandPosition);
                _itemInRightHand.transform.SetPositionAndRotation(_rightHandPosition.position, _rightHandPosition.rotation);
                _currentTwigBeingHovered.GetComponent<TwigMechanics>().SetIsInHand(true);
                _currentTwigBeingHovered = null;
                _isNearTwig = false;
            } 
        } else if (_itemInRightHand && Input.GetKeyDown(KeyCode.E))
        {
            _rightHandPosition.DetachChildren();
            _itemInRightHand.GetComponent<TwigMechanics>().SetIsInHand(false);
            _itemInRightHand = null;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Twig") && !other.GetComponent<TwigMechanics>().GetIsInHand())
        {
            Debug.Log("Near Twig");
            _isNearTwig = true;
            _currentTwigBeingHovered = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Twig") && !other.GetComponent<TwigMechanics>().GetIsInHand())
        {
            _isNearTwig = false;
            _currentTwigBeingHovered = null;
        }
    }
}
