using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManegerMain : MonoBehaviour
{
    public static bool _isGameover = false;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            _isGameover=true;
            SceneManager.LoadScene("Result", LoadSceneMode.Single);
        }
    }
}
