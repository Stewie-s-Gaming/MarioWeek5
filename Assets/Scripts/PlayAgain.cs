using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    [SerializeField] 
    string sceneName;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            SceneManager.LoadScene(sceneName);    // Input can either be a serial number or a name; here we use name.
        }
    }
}
