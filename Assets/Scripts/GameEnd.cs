using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameEnd : MonoBehaviour
{
    private float bestTime;
    private float time;
    Timer timer;
    


    [SerializeField] GameObject winScreen;
    [SerializeField] TMP_Text bestTimeText;
    [SerializeField] TMP_Text currentTimeText;
    [SerializeField] GameObject newRecordPopUp;


    [SerializeField] GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name))
        {
            bestTime = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame(bool win)
    {
        Time.timeScale = 0;
        if (win)
        {
            if (time > bestTime)
            {
                newRecordPopUp.SetActive(true);
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name,time);
            }
            winScreen.SetActive(true);
        }
        else //if end is caused by death 
        {
            deathScreen.SetActive(true);
        }
    }

    public void ToTitle()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    void getTime()
    {
        time = timer.GetTime();
    }

}
