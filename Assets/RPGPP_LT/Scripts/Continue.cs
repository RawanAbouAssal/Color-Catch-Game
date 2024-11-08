using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Continue : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        // Load the scene with index 2, typically used for transitioning to the next level or menu
        SceneManager.LoadScene(2);
    }
}
