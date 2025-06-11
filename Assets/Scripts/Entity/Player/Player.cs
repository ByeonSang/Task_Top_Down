using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private SpriteRenderer _spr;
    private Animator _anim;
    [SerializeField] private float _moveSpeed;

    private PlayerAnimData _animData;
    private PlayerAC _playerAC;
    private Vector2 _dir;
    
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
    public PlayerAnimData AnimData => _animData;

    private void Awake()
    {
        #region InputAction
        _playerAC = new();
        _playerAC.Player.Move.performed += context => Dir = context.ReadValue<Vector2>();
        _playerAC.Player.Move.canceled += context => Dir = Vector2.zero;
        #endregion

        _spr = GetComponentInChildren<SpriteRenderer>();
        _anim = GetComponentInChildren<Animator>();

        _animData = new(_anim, this);

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

    private void Update()
    {
        AnimData.Update();
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
            _spr.flipX = x < 0f;
            isRight = !_spr.flipX;
            /*È¸Àü Quaternion newQuater = transform.rotation;
            newQuater = Quaternion.Euler(0f, (x>0f) ? 0 : 180f, 0f);
            transform.rotation = newQuater;*/
        }
    }
}
