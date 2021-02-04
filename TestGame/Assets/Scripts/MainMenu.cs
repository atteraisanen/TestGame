using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private Text bestTimeText;
    private void Start()
    {
        GameData data = SaveSystem.LoadGame();
        if(data != null)
        {
            bestTimeText.text = "BEST TIME: " + data.bestTime.ToString("F2");
        } else
        {
            bestTimeText.text = "BEST TIME: 0";
        }
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
