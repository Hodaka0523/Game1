using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _jumpPower = 5f;
    [SerializeField] float _movePower = 0.01f;
    [SerializeField] bool m_flipX = false;
    [SerializeField] Sprite _jumpSprite;
    [SerializeField] Sprite _dushSprite;
    Rigidbody2D _rb;
    SpriteRenderer _spriteRenderer;
    GameObject _enemy;
    float m_h;
    float m_scaleX;
    int _count = 0;
    bool _isground = false;

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //ジャンプ
        if (Input.GetButtonDown("Jump") && _count < 2)
        {
            Vector3 force = new Vector3(0.0f, _jumpPower, 0.0f);
            _rb.AddForce(force, ForceMode2D.Impulse);
            _spriteRenderer.sprite = _jumpSprite;
            _count++;
        }
        m_h = Input.GetAxisRaw("Horizontal");
        //左右切り替え
        if (m_flipX)
        {
            FlipX(m_h);
        }
        if (_rb.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }
    void FlipX(float horizontal)
    {
        m_scaleX = this.transform.localScale.x;

        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
    //横方向の移動
    private void FixedUpdate()
    {
        this.transform.Translate(_movePower * m_h, 0f, 0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _count = 0;
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

    }

    //接地判定
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _isground = true;
            if (_isground == true)
            {
                 _spriteRenderer.sprite = _dushSprite;
            }
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(this.gameObject);
            }
    }
        private void OnTriggerExit2D(Collider2D collision)
        {
            _isground = false;
        }
}
