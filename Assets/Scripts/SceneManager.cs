using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public GameObject pauseMenu; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf == false)
            {
                // Toggle the active state of the target object
                pauseMenu.SetActive(true);
            }
            else if (pauseMenu.activeSelf == true)
            {
                // Toggle the active state of the target object
                pauseMenu.SetActive(false);
            }
           
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("Title Screen");
    }
    
    
}