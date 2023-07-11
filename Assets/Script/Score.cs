using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    Text score_object;
    public void Start()
    {
        score_object.text = "あなたのスコアは" + TimeCountController._score.ToString() + "点です";
    }
}
