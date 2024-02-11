using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public Collider2D attackCollider;

    public SpriteRenderer attackSpriteRenderer;
    Vector2 rightAttackOffset;
    void Start()
    {
        attackCollider = GetComponent<Collider2D>();
        attackSpriteRenderer = GetComponent<SpriteRenderer>();
        rightAttackOffset = transform.position;

    }
    public void AttackLeft()
    {
        print("Attack Left!");
        attackCollider.enabled = true;
        attackSpriteRenderer.enabled = true;
        transform.localPosition = rightAttackOffset;
        
    }
    public void AttackRight()
    {
        print("Attack Right!");
        attackCollider.enabled = true;
        attackSpriteRenderer.enabled = true;
        transform.localPosition =  new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }
		public void StopAttack()
    {
        attackCollider.enabled = false;
        attackSpriteRenderer.enabled = false;
    }
}
