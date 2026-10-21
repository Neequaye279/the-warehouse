using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsPanel;
    public string gameSceneName = "warehouse";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(gameSceneName);
    }

    public void ShowControls()
    {
        controlsPanel.SetActive(true);
    }

    public void HideControls()
    {
        controlsPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
