using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button buttonStart;
    public Button buttonQuit;

    void Start()
    {
        buttonStart.onClick.AddListener(StartGame);
        buttonQuit.onClick.AddListener(Quit);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Maze");
    }

    void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
