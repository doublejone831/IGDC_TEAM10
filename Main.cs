using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
   public void PlayBtn()
    {
        SceneManager.LoadScene("Loading");
    }
}
