using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FSMControllerLes12;

public class NewCharacterMove : CharacterMove
{
    [SerializeField]
    protected float _speedRun = 20;
    [SerializeField]
    protected float _speedCrawl = 5;
    [SerializeField]
    protected string _clipRun;
    [SerializeField]
    protected string _clipCrawl;

    private Dictionary<MovementType, IMoving> _movementStrategies;
    private IMoving _currentMove;

    public override void Enter()
    {
        InitializeMovementStrategies();
        SetMovement(MovementType.Wall);
    }

    public override void Do()
    {
        float moveInput = Input.GetAxis(nameV) * Time.deltaTime;

        if (moveInput == 0)
        {
            GetComponentInParent<FSMControllerLes12>().SwitchState(NewCharacterState.Idle);
            return;
        }

        HandleMovementInput();
        _currentMove.Move(moveInput);
    }

    private void InitializeMovementStrategies()
    {
        _movementStrategies = new Dictionary<MovementType, IMoving>
        {
            { MovementType.Wall, new WallMove(_speedWallkin, transform, _animator, _clip) },
            { MovementType.Run, new RunMove(_speedRun, transform, _animator, _clipRun) },
            { MovementType.Crawl, new CrawlMove(_speedCrawl, transform, _animator, _clipCrawl) }
        };
    }

    private void HandleMovementInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
        {
            SetMovement(MovementType.Run);
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift))
        {
            SetMovement(MovementType.Crawl);
        }
        else if ((Input.GetKeyUp(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift)) ||
                 (!Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.LeftShift)))
        {
            SetMovement(MovementType.Wall);
        }
    }

    private void SetMovement(MovementType type)
    {
        if (_movementStrategies.TryGetValue(type, out IMoving move))
        {
            _currentMove = move;
            _currentMove.PlayClip();
        }
        else
        {
            Debug.LogError($"Movement type {type} not found!");
        }
    }

    private enum MovementType
    {
        Wall,
        Run,
        Crawl
    }
}


