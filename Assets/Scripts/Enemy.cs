using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private Rigidbody2D rb;
    private Transform player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<PlayerController>().transform;
    }

    private void Update()
    {
        if (!player)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsPlayer();
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void RotateTowardsPlayer()
    {
        Vector2 playerDirection = player.position - transform.position;
        float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotationSpeed);
    }

    private void GetTarget()
    {
        player = GameObject.FindAnyObjectByType<PlayerController>().transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
