using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("JoystickButton3") && (SceneManager.GetActiveScene().name == "GameOver"))
        {
            Application.Quit();
        }
    }

    public void end()
    {
        
    }
}
