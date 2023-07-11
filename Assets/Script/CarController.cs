using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float position_X;
    [SerializeField] float position_Y;
    [SerializeField] List<GameObject> enemyList;
    [SerializeField] float interval = 1800;
    float _flame = 0;
    private void Start()
    {
        
    }
    void Update()
    {
        _flame++;
        if (_flame > interval)
        {
            int _index = Random.Range(0, enemyList.Count);
            Instantiate(enemyList[_index], new Vector3(position_X,position_Y,0 ), Quaternion.identity);
            _flame = 0;
        }
    }
}
