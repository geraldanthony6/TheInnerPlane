using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField] public GameObject _PlayerHouse;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer PlayerRenderer = GetComponent<SpriteRenderer>();
        PlayerRenderer.color = CharacterDataManager.Instance.CharacterColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
