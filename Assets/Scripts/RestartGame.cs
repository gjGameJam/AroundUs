using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class RestartGame : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(Restarting());

    }

    IEnumerator Restarting()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);

    }
}
