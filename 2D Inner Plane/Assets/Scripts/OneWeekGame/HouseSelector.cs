using System;
using UnityEngine;

public class HouseSelector : MonoBehaviour
{
    public enum HouseType
    {
        HOUSEONE,
        HOUSETWO,
        HOUSETHREE
    }

    [SerializeField] private HouseType _CurrentHouseType;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        switch (_CurrentHouseType)
        {
            case HouseType.HOUSEONE:
                CharacterDataManager.Instance.HouseTypeSelected = HouseType.HOUSEONE;
            break;
            case HouseType.HOUSETWO:
                CharacterDataManager.Instance.HouseTypeSelected = HouseType.HOUSETWO;
            break;
            case HouseType.HOUSETHREE:
                CharacterDataManager.Instance.HouseTypeSelected = HouseType.HOUSETHREE;
            break;    
        }
    }
}
