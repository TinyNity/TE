using UnityEngine;

public class Movement : MonoBehaviour
{

    // SerilizedField
    [SerializeField] private float speedTmp;
    [SerializeField] private float speed;
    [SerializeField] private Dir myDir = Dir.Down;
    [SerializeField] private bool isMoving = false;

    // Enum
    public enum Dir { Up, Down, Left, Right };

    // Variables
    private bool isLock = false;
    private Dir lastMoveDir;

    public void Move(Vector3 moveValue)
    {
        if (isLock)
        {
            return;
        }
        transform.Translate(speed * Time.fixedDeltaTime * moveValue);

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

        if (isMoving)
        {
            lastMoveDir = myDir;
        }
        else
        {
            myDir = lastMoveDir;
        }
    }

    public void ModifySpeed(float newSpeed)
    {
        speed = newSpeed;
    }


    public float GetSpeedTmp
    {
        get { return speedTmp; }
    }

    public float GetSpeed
    {
        get { return speed; }
        set { speed = value; }
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

    public bool GetIsLock
    {
        get { return isLock; }
        set { isLock = value; }
    }

}
