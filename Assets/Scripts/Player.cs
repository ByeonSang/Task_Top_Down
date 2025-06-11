using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private PlayerAC _playerAC;
    private Vector2 _dir;

    private bool _isRight = true;
    private int _facingDir = 1;

    
    public Vector2 Dir
    {
        get => _dir;
        private set
        {
            ApplyFacing(value.x);
            _dir = value;
        }
    }
    public Transform Center { get; private set; }

    // ** Facing **
    public bool isRight { get; private set; } = true;


    private void Awake()
    {
        #region InputAction
        _playerAC = new();
        _playerAC.Player.Move.performed += context => Dir = context.ReadValue<Vector2>();
        _playerAC.Player.Move.canceled += context => Dir = Vector2.zero;
        #endregion

        Center = GetComponentInChildren<SpriteRenderer>().transform;
    }

    private void OnEnable()
    {
        _playerAC.Enable();
    }

    private void OnDisable()
    {
        _playerAC.Disable();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void OnMove()
    {
        Vector2 nextPoint = (Vector2)transform.position + Dir * _moveSpeed * Time.fixedDeltaTime;
        transform.position = Vector2.Lerp(transform.position, nextPoint, Time.fixedDeltaTime * 19f);
    }

    private void ApplyFacing(float x)
    {
        if(x != 0f)
        {
            Quaternion newQuater = transform.rotation;
            newQuater = Quaternion.Euler(0f, (x>0f) ? 0 : 180f, 0f);
            transform.rotation = newQuater;
        }
    }
}
