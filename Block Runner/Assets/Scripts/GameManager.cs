using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public float restartDelay = 1f;
    public float slowness = 20f;
    public GameObject completeLevelUI;


    public void endGame()
    {
        if(!gameEnded)
        {
            Debug.Log("GAME OVER");
            gameEnded = true;
            StartCoroutine(restartGame());
        }
    }

    public void completeLevel()
    {
        Debug.Log("Level complete!");
        completeLevelUI.SetActive(true);
    }

    IEnumerator restartGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(1f);
        Debug.Log("Slow game down");

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
