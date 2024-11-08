using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void Play()
    {
        // Load the scene with index 1, typically used for transitioning to the next level or menu

        SceneManager.LoadScene(1);
    }

   
}
