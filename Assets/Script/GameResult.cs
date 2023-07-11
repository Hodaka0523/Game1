using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour
{
    // Start is called before the first frame update
    public void SwitchScean()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
