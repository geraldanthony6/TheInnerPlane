using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int playerScore;
    public TextMeshProUGUI scoreText;

    public Transform[] HangerSpawnPoints;
    public Transform[] HatSpawnPoints;

    public List<GameObject> SpawnedItems;

    public GameObject HatPrefab;
    public GameObject HangerPrefab;

    public int MatchedPairs;

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
        SpawnGameItems();
    }

    private void Update()
    {
        if (MatchedPairs == 3)
        {
            StartNewRound();
        }
    }

    public void UpdateScore(int ValueToAdd)
    {
        playerScore += ValueToAdd;
        scoreText.text = playerScore.ToString();
        MatchedPairs += 1;
    }
    
    private ColorIndicator ChooseRandomColor()
    {
        ColorIndicator TempColor = ColorIndicator.Red;
        int randNum = UnityEngine.Random.Range(0, 3);
        
        switch (randNum)
        {
            case 0:
                TempColor = ColorIndicator.Red;
                break;    
            case 1:
                TempColor = ColorIndicator.Blue; 
                break;
            case 2:
                TempColor = ColorIndicator.Green;
                break;    
        }

        return TempColor;
    }

    private void SpawnGameItems()
    {
        for (int i = 0; i < 3; i++)
        {
            ColorIndicator NewColor = ChooseRandomColor();
            GameObject TempHat = Instantiate(HatPrefab, HatSpawnPoints[i].position, Quaternion.identity);
            GameObject TempHanger = Instantiate(HangerPrefab, HangerSpawnPoints[i].position, Quaternion.identity);
            SpawnedItems.Add(TempHat);
            SpawnedItems.Add(TempHanger);
            TempHat.GetComponent<Hat>().UpdateCurrentHatColor(NewColor);
            TempHanger.GetComponent<Hanger>().UpdateCurrentHangerColor(NewColor);
        }
    }

    private void StartNewRound()
    {
        MatchedPairs = 0;
        foreach (GameObject Item in SpawnedItems)
        {
            Destroy(Item);
        }
        SpawnGameItems();
    }
}
