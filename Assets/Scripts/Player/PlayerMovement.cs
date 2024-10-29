using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] [Range(0.05f, 1f)] private float acceleration;
    [SerializeField] [Range(0.05f, 1f)] private float decceleration;

    private Vector2 velocity;

    // referencias
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        float _xAxis = Input.GetAxisRaw("Horizontal");
        float _yAxis = Input.GetAxisRaw("Vertical");

        Vector2 _dir = new Vector2(_xAxis, _yAxis);
        if (_dir != Vector2.zero) {
            velocity = Vector2.MoveTowards(velocity, _dir.normalized * speed, acceleration);
        } else {
            velocity = Vector2.MoveTowards(velocity, Vector2.zero, decceleration);
        }
    }

    private void FixedUpdate() {
        rb.velocity = velocity;
    }
}
