using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Vector3 move;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(move);

    }

    // Update is called once per frame
    public void Update()
    {
       if (_rb.position.x < -13 || _rb.position.x > 18 )
        {
            Destroy(this.gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
