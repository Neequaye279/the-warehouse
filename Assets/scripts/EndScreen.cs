using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public GameObject Panel;
    public TextMeshProUGUI titleText;

    public float winDelay = 2.5f;
    public float loseDelay = 0.6f;
    bool shown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Show(bool won)
    {
        if (shown) return;
        shown = true;
        StartCoroutine(ShowRoutine(won));
    }

    IEnumerator ShowRoutine(bool won)
    {
        yield return new WaitForSeconds(won ? winDelay : loseDelay);
        titleText.text = won ? "YOU ESCAPED!" : "BUSTED!";
        Panel.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
