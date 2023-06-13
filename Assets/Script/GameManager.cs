using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Clear;
    public bool isGame;
    public static int Level = 1;
    public AudioSource sound;

    // Start is called before the first frame update
    public void Start()
    {
        isGame = false;
        sound = GetComponent<AudioSource>();
        AudioListener.volume = 1;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!isGame)
        {
            Clear.SetActive(false);
        }
        else
        {
            if (Level==1 && Input.GetKeyDown(KeyCode.Return))
            {
                Level = 2;
                SceneManager.LoadScene("Second");
            }
            else if (Level == 2 && Input.GetKeyDown(KeyCode.Return))
            {
                Level = 3;
                SceneManager.LoadScene("Third");
            }
            else if (Level == 3 && Input.GetKeyDown(KeyCode.Return))
            {
                Level = 4;
                SceneManager.LoadScene("Last");
            }
            else if(Level == 4 && Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
    public void EndGame()
    {
        isGame = true;
        Clear.SetActive(true);
        AudioListener.volume = 0;
    }
}
