using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;

public class RockGameManager : MonoBehaviour
{
    public static RockGameManager Instance { get; private set; }

    public TextMeshProUGUI RockPurityText;
    
    public TextMeshProUGUI PlayerScoreText;

    [SerializeField]private List<Rock> RocksInCrate;

    [SerializeField] private List<GameObject> SpawnedRocks;
    
    [SerializeField]private float _playerScore;

    [SerializeField] private GameObject[] RockTypesForSpawning;

    [SerializeField] private Transform[] LocationsForRockSpawns;

    public UnityEvent m_AddNewRocks;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        m_AddNewRocks ??= new UnityEvent();

        m_AddNewRocks.AddListener(SpawnNewRocks);

        m_AddNewRocks.Invoke();
    }

    private void GenerateRocks(int NumberOfRocksToSpawn)
    {
        for (int i = 0; i < NumberOfRocksToSpawn; i++)
        {
            GameObject tempRock = null;
            int RandomRockNumber = UnityEngine.Random.Range(0, RockTypesForSpawning.Length);
            int RandomRockPosNumber = UnityEngine.Random.Range(0, LocationsForRockSpawns.Length);
            
            tempRock = Instantiate(RockTypesForSpawning[RandomRockNumber], LocationsForRockSpawns[RandomRockPosNumber].position, Quaternion.identity);
            SpawnedRocks.Add(tempRock);
        }
    }

    public void CalculateRockPurity(float ValueToCheck)
    {
        RockPurityText.text = ((ValueToCheck / 1000.0f)).ToString();
    }

    public void AddRockToList(Rock RockToAdd)
    {
        RocksInCrate.Add(RockToAdd);
    }
    
    public void RemoveRockFromList(GameObject RockToRemove)
    {
        SpawnedRocks.Remove(RockToRemove);
    }

    public void SellRock(Rock RockInCrate)
    {
        _playerScore += (RockInCrate.RockPurityLevel * 10 * RockInCrate.RockData.MineralMultiplier);
        PlayerScoreText.text = _playerScore.ToString();
        RockInCrate.DestroyRock();

        if (SpawnedRocks.Count == 0)
        {
            m_AddNewRocks.Invoke();
        }
    }

    private void SpawnNewRocks()
    {
        GenerateRocks(5);
    }
}
