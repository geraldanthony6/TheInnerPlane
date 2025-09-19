using System;
using Unity.Cinemachine;
using UnityEngine;

public class OpenWorldPlayerGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _Player;
    
    [SerializeField] private GameObject[] _PlayerAvailableHouses;

    [SerializeField] private CinemachineCamera _PlayerCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        PlayerInitialSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerInitialSetup()
    {
        GameObject Player = null;
        switch (CharacterDataManager.Instance.HouseTypeSelected)
        {
            // Spawn the player at a specific house
            case HouseSelector.HouseType.HOUSEONE:
                Player = Instantiate(_Player, _PlayerAvailableHouses[0].transform.position, Quaternion.identity);
                _PlayerCamera.Follow = Player.transform;
                Player.GetComponent<CharacterData>()._PlayerHouse = _PlayerAvailableHouses[0];
            break;
            case HouseSelector.HouseType.HOUSETWO:
                Player = Instantiate(_Player, _PlayerAvailableHouses[1].transform.position, Quaternion.identity);
                _PlayerCamera.Follow = Player.transform;
                Player.GetComponent<CharacterData>()._PlayerHouse = _PlayerAvailableHouses[1];
            break;
            case HouseSelector.HouseType.HOUSETHREE:
                Player = Instantiate(_Player, _PlayerAvailableHouses[2].transform.position, Quaternion.identity);
                _PlayerCamera.Follow = Player.transform;
                Player.GetComponent<CharacterData>()._PlayerHouse = _PlayerAvailableHouses[2];
            break;    
        }
    }
}
