
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 2f;
    public int score = 0,bonus=200;



    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("level1Sound");
    }


    public void EndGame()
    {

        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);

        }

    }

    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

 

    public void addBonus() {

        score += bonus;
    }

}
