using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [NonSerialized] public List<GameObject> snakeBody = new List<GameObject>();  //lists to store snake parts they're moving in

    public PlayerMovement playerMovement; //reference input c class and actions inside it

    public UnityEvent StartOfGame, OnCollectibleConsumed,OnGameOver, PauseGame, ResumeGame;

    //stores head properties
    private Vector3 headMoveDirection = Vector3.right;
    private Vector3 snakeHeadRotation;
    
    //move direction used by fixed update, used to prevent rapid move change buggy behavior by ignoring multiple inputs in one fixedupdate cycle
    private Vector3 activeMoveDirection =  Vector3.right;

    //play area extent from each side to do wraparound
    [field:SerializeField] public int PlayAreaExtent { get; private set; }
    [SerializeField] private float playerSpeed;

    [NonSerialized] public bool gameIsPaused = false;

    [SerializeField] private GameObject collidableWalls;

    private void Awake()
    {
        //configure input reading
        playerMovement = new PlayerMovement();
        playerMovement.Movement.Enable();
        playerMovement.PauseResume.Enable();

        //configure game tick rate
        Time.fixedDeltaTime = 1 / playerSpeed;

        //check if wrap around is toggled or not
        if(PlayerPrefs.GetInt("togglewalls") == 0)
        {
            collidableWalls.SetActive(false);
        }
        else
        {
            collidableWalls.SetActive(true);

        }
    }


    private void Start()
    {
        StartOfGame.Invoke();
    }


    //read inputs on update
    private void Update()
    {
        //disables movement register in H/V direction if player moving in same direction
        if (playerMovement.Movement.Horizontalmovement.WasPerformedThisFrame() && activeMoveDirection.x ==0)
        {
            float moveXValue = playerMovement.Movement.Horizontalmovement.ReadValue<float>();
            headMoveDirection = new Vector3(moveXValue, 0);
            snakeHeadRotation = (moveXValue == 1) ? Vector3.zero : new Vector3(0, 0, 180);
        }
        else if (playerMovement.Movement.Verticalmovement.WasPerformedThisFrame() & activeMoveDirection.y ==0)
        {
            float moveYValue = playerMovement.Movement.Verticalmovement.ReadValue<float>();
            headMoveDirection = new Vector3(0, moveYValue);
            snakeHeadRotation = (moveYValue == 1) ? new Vector3(0, 0, 90) : new Vector3(0, 0, -90);
        }

        //pauses/resumes game
        if(playerMovement.PauseResume.PauseButton.WasPerformedThisFrame())
        {
            if(!gameIsPaused)
            {
                
                PauseGame.Invoke();
            }
            else
            {               
                ResumeGame.Invoke();
            }
        }
    }


    //move snake on fixed update
    private void FixedUpdate()
    {
        activeMoveDirection = headMoveDirection;
        //rotate head
        snakeBody[0].transform.eulerAngles = snakeHeadRotation;

        Vector2 destinationPosition, initialPosition = Vector2.zero;

        
        //when moving,save initial position of head, move head to destination, use initial position as destination of next part and so on
        for (int i = 0; i < snakeBody.Count; i++)
        {
            destinationPosition = (i == 0) ? snakeBody[i].transform.position + activeMoveDirection : initialPosition;
            initialPosition = snakeBody[i].transform.position;

            snakeBody[i].transform.position = destinationPosition;
        }
        
        //check if snake head moves out of bounds if so do a wraparound, only do this if wrap set to true
        //Horizontal
        if(PlayerPrefs.GetInt("togglewalls") ==0)
        {
            if (snakeBody[0].transform.position.x > PlayAreaExtent)
            {
                snakeBody[0].transform.position = new Vector2(-PlayAreaExtent, snakeBody[0].transform.position.y);
            }
            else if (snakeBody[0].transform.position.x < -PlayAreaExtent)
            {
                snakeBody[0].transform.position = new Vector2(PlayAreaExtent, snakeBody[0].transform.position.y);
            }
            //Vertical
            if (snakeBody[0].transform.position.y > PlayAreaExtent)
            {
                snakeBody[0].transform.position = new Vector2(snakeBody[0].transform.position.x, -PlayAreaExtent);
            }
            else if (snakeBody[0].transform.position.y < -PlayAreaExtent)
            {
                snakeBody[0].transform.position = new Vector2(snakeBody[0].transform.position.x, PlayAreaExtent);
            }
        }
        

    }
}
