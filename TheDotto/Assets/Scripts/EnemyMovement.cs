using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] bool side; //1 - right, 0 left
    [SerializeField] float enemyMovementSpeed;
    [SerializeField] float distanceToCover;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Vector2 startingPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startingPos = transform.position;
    }

    private void Update()
    {
        GoBackToReality(transform.position);
    }

    void FixedUpdate()
    {
        if (side)
        {
        rb.velocity = new Vector2(enemyMovementSpeed, rb.velocity.y);            
        }
        else rb.velocity = new Vector2(-1 * enemyMovementSpeed, rb.velocity.y);
    }


    private float DistanceCalculator(Vector2 currentPos)
    {
        float currentX = Mathf.Abs(currentPos.x);

        return currentX - startingPos.x;
    }

    private void GoBackToReality(Vector2 currentPos)
    {
        if (distanceToCover < DistanceCalculator(currentPos))
        {
            side = !side;
            spriteRenderer.flipX = !side;
        }
    }
    
}
