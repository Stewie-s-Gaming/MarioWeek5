using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] string sceneName;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneName);    // Input can either be a serial number or a name; here we use name.
    }
}
