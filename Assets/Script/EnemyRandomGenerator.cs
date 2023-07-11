using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemyRandomGenerator : MonoBehaviour
{
    [SerializeField] Transform position_1;
    [SerializeField] Transform position_2;
    [SerializeField] List<GameObject>enemyList;
    [SerializeField] float interval = 1800;
    float _minX,_maxX,_minY,_maxY;
    float _flame = 0;
    // Start is called before the first frame update
    void Start()
    {
        _minX = Mathf.Min(position_1.position.x, position_2.position.x);
        _maxX = Mathf.Max(position_1.position.x, position_2.position.x);
        _minY = Mathf.Min(position_1.position.y, position_2.position.y);
        _maxY = Mathf.Max(position_1.position.y, position_2.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        _flame++;
        if (_flame > interval) 
        {
            int _index = Random.Range(0,enemyList.Count);
            float _positionX = Random.Range(_minX, _maxX);
            float _positionY = Random.Range(_minY, _maxY);
            Instantiate(enemyList[_index], new Vector3(_positionX, _positionY),Quaternion.identity);
            _flame = 0;
        }
    }
}
