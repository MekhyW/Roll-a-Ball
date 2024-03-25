using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float remaining_time = 60.0f;
    public Text timeText;
    public Text winText;
    public GameObject player;

    void Start()
    {
        timeText = GameObject.FindGameObjectWithTag("TimeText").GetComponent<Text>();
    }

    void Update()
    {
        remaining_time -= Time.deltaTime;
        UpdateTimeText();
        if (winText.text != "" && winText.text != "Too Bad...") { timeText.text = ""; }
        else if (remaining_time <= 0.0f) {
            player.SetActive(false);
            timeText.text = "";
            winText.text = "Too Bad...";
            if (remaining_time <= -7.0f) { SceneManager.LoadScene("MainMenu"); }
        }
    }

    void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(remaining_time / 60);
        int seconds = Mathf.FloorToInt(remaining_time % 60);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeText.text = "Time: " + timeString;
    }
}
