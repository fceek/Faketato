using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private Slider hpBar;
    [SerializeField] private float speed;
    public float currentHp;
    
    [SerializeField] private float takeDamageProtection;

    private float _lastDamageTime;

    private Vector2 _moveInstruction;

    private void Awake()
    {
        currentHp = maxHp;
        _lastDamageTime = Time.time;
        hpBar.value = 1.0f;
    }

    public void OnMoveInput(InputAction.CallbackContext ctx)
    {
        _moveInstruction = ctx.ReadValue<Vector2>();
    }

    private void Update()
    {
        if (_moveInstruction == null || _moveInstruction == Vector2.zero) return;

        transform.position = transform.position + (Vector3)_moveInstruction * (speed * Time.deltaTime);
    }

    public Transform GetNearestEnemy()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        var res = Physics2D.OverlapCircleAll(pos, 50.0f, 1024);
        if (res.Length == 0) return null;
        var nearest = res.
            OrderBy(t => (t.transform.position - transform.position).sqrMagnitude).
            FirstOrDefault().
            transform;
        return nearest;
    }

    public void TakeDamage(float amount)
    {
        if (Time.time - _lastDamageTime <= takeDamageProtection) return;
        currentHp -= amount;
        _lastDamageTime = Time.time;
        if (currentHp <= 0)
        {
            // Over
            return;
        }

        hpBar.value = currentHp / maxHp;
    }
}
