using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RockGameManager : MonoBehaviour
{
    public static RockGameManager Instance { get; private set; }

    public TextMeshProUGUI RockPurityText;

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

    public void UpdateLevelScore()
    {
        
    }

    public void GenerateRocks()
    {
        
    }

    public void CalculateRockPurity(float ValueToCheck)
    {
        RockPurityText.text = ((ValueToCheck / 1000.0f)).ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
