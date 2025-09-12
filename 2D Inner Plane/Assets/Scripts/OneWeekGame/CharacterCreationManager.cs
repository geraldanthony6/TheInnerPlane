using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCreationManager : MonoBehaviour
{
    public GameObject Player;

    public GameObject ColorPanel;

    public bool isColorPanelOpen;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor(int NewColorID)
    {
        Image PlayerRenderer = Player.GetComponent<Image>();

        switch (NewColorID)
        {
            case 1:
                PlayerRenderer.color = Color.red;
                CharacterDataManager.Instance.CharacterColor = Color.red;
            break;
            case 2:
                PlayerRenderer.color = Color.green;
                CharacterDataManager.Instance.CharacterColor = Color.green;
            break; 
            case 3:
                PlayerRenderer.color = Color.yellow;
                CharacterDataManager.Instance.CharacterColor = Color.yellow;
            break;
            case 4:
                PlayerRenderer.color = Color.blue;
                CharacterDataManager.Instance.CharacterColor = Color.blue;
            break;    
            case 5:
                PlayerRenderer.color = new Color(1, 0.35f, 0, 255);
                CharacterDataManager.Instance.CharacterColor = new Color(1, 0.35f, 0, 255);
            break;    
            case 6:
                PlayerRenderer.color = new Color(.66f, 0, 1, 255);
                CharacterDataManager.Instance.CharacterColor = new Color(.66f, 0, 1, 255);
            break;    
            default: 
            break;    
        }
    }

    public void OpenColorPanel()
    {
        if (!isColorPanelOpen)
        {
            ColorPanel.SetActive(true);
            isColorPanelOpen = true;
        } else if (isColorPanelOpen)
        {
            ColorPanel.SetActive(false);
            isColorPanelOpen = false;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Test");
    }

}
