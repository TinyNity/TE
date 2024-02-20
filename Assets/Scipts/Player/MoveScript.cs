using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveScript : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;

    public enum Dir { Up, Down, Left, Right };
    [SerializeField] private Dir myDir = Dir.Down;
    [SerializeField] private bool isMoving = false;
    private GameManager manager;
    private PlayerInput inputs;
    private InputAction moveAction;
    private float timer = 0f;

    void Start()
    {
        manager = GameManager.GetInstance();
        inputs = manager.GetInputs;

        moveAction = inputs.actions["Move"];
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // récupère l'input avec inputmanager et de movement et modifier le player avec transform.translate
        // modifier myDir et isMoving ==> permettra au script MoveAnimationScript de jouer la bonne animation du player
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        transform.Translate(moveValue * moveSpeed * Time.deltaTime);
        if (moveValue.x > 0)
        {
            myDir = Dir.Right;
            isMoving = true;
        }
        else if (moveValue.x < 0)
        {
            myDir = Dir.Left;
            isMoving = true;
        }
        else if (moveValue.y > 0)
        {
            myDir = Dir.Up;
            isMoving = true;
        }
        else if (moveValue.y < 0)
        {
            myDir = Dir.Down;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    public float GetMoveSpeed
    {
        get { return moveSpeed; }
    }

    public Dir GetMyDir
    {
        get { return myDir; }
    }

    public int GetMyDirToInt()
    {

        if (myDir == Dir.Up) return 0;
        if (myDir == Dir.Right) return 1;
        if (myDir == Dir.Down) return 2;
        return 3;

    }

    public bool GetIsMove
    {
        get { return isMoving; }
    }

    public void ApplyModifier(float multiplier, float timeInSeconds) {
        timer = 0f;
        float backupMoveSpeed = moveSpeed;
        moveSpeed = moveSpeed* multiplier;
        if (timer >= timeInSeconds){
            moveSpeed = backupMoveSpeed;
            timer = 0f;
        }

    }
    private void UpdateTimer()
    {
        timer += Time.deltaTime; 
    }
    void Update()
    {
        UpdateTimer();
    }

}
