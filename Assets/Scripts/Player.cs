using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {  get; private set; }
    [SerializeField] private float speed;
    public event EventHandler OnWing;

    private Rigidbody2D rb;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        HandleMovement();

    }

    private void HandleMovement()
    {
        float velocity = 5.0f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * velocity;
            OnWing?.Invoke(this, EventArgs.Empty);
        }
    }

    private void FixedUpdate()
    {
        float rotationSpeed = 10.0f;
        float rotationZ = rb.velocity.y * rotationSpeed;
        //if(rotationZ <)
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }
    public float GetSpeed()
    {
        return speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FlappyBirdGameManager.Instance.GameOver();
    }
}
