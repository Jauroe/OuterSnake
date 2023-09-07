using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridMoveDirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private LevelGrid levelGrid;

    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    }
    
    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
        gridMoveTimerMax = 0.25f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);
    }

    private void Update()
    {
        HandleInput();
        HandleGridMovement();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("VerticalPos"))
        {
            if (gridMoveDirection.y != -1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = 1;
                transform.rotation = Quaternion.Euler(0 , 0, 0);
            }
        }
        if (Input.GetButtonDown("VerticalNeg"))
        {
            if (gridMoveDirection.y != 1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
                transform.rotation = Quaternion.Euler(0 , 0, -180);
            }
        }
        if (Input.GetButtonDown("HorizontalPos"))
        {
            if (gridMoveDirection.x != -1)
            {
                gridMoveDirection.x = 1;
                gridMoveDirection.y = 0;
                transform.rotation = Quaternion.Euler(0 , 0, -90);
            }
        }
        if (Input.GetButtonDown("HorizontalNeg"))
        {
            if (gridMoveDirection.x != 1)
            {
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
                transform.rotation = Quaternion.Euler(0 , 0, 90);
            }
        }
    }

    public Vector2Int GetGridPosition()
    {
        return gridPosition;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridPosition += gridMoveDirection;
            gridMoveTimer -= gridMoveTimerMax;
            transform.position = new Vector3(gridPosition.x, gridPosition.y);
            
            levelGrid.SnakeMoved(gridPosition);
        }
    }
}
