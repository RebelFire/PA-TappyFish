using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] private float _speed;
    int angle;
    int maxAngle = 20;
    int minAngle = -60;
    public Score score;
    bool touchedGround;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer _sr;
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        //gameManager = GetComponent<GameManager>();

        //_rb.gravityScale = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        FishSwim();

    }

    private void FixedUpdate()
    {
        FishRotation();

    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            _rb.velocity = Vector2.zero;
            _rb.velocity = new Vector2(_rb.velocity.x, _speed);
        }
    }

    void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle += 4;

            }
        }
        else if (_rb.velocity.y < -1.2)
        {
            if (angle > minAngle)
            {
                angle -= 2;
            }
        }
        if(touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            score.Scored();
        }
        else if(collision.CompareTag("Column"))
        {
            // game over
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                // game over
                gameManager.GameOver();
                GameOver();
            }

        }
        
    }

    void GameOver()
    {
        touchedGround = true;
        _sr.sprite = fishDied;
        _animator.enabled = false;
        transform.rotation = Quaternion.Euler(0,0,-90);
    }



}
