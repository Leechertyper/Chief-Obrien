using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionAndMovement : MonoBehaviour
{
    protected float moveSpeed = 2f;
    protected float gridSize = 1f;
    protected enum Orientation
    {
        Horizontal,
        Vertical
    };
    protected Vector2 input;
    protected bool isMoving = false;
    protected bool wasMoving = false;
    protected Vector3 startPosition;
    protected Vector3 endPosition;
    protected float t;
    protected float factor;
    protected bool validMovement;
    public int[] playerPosition;
    protected int[,] tileContents;
    protected int width = 11;
    protected int height = 9;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        playerPosition = new int[] {5, 8};
        tileContents =new int[,] { { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                   { 0, 4, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0 },
                                   { 0, 4, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0 },
                                   { 0, 4, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0 },
                                   { 0, 4, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0 },
                                   { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                   { 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0 },
                                   { 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0 },
                                   { 3, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0 },
                                   { 3, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0 },
                                   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }};
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        /**
         * When the player is not already moving input can be taken in, it then deals with ambiguities/player trying to input both directions
         * simultaneously, checks if there is an interaction or movement involved with the input, and then starts a coroutine for movement
         */
        if(wasMoving && !isMoving){
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0;
            }
            else
            {
                input.x = 0;
            }
            if(input.y == 0 && input.x == 0)
            {
                wasMoving = false;
            }
        }

        if (!isMoving && !wasMoving)
        {
            validMovement = false;
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0;
            }
            else
            {
                input.x = 0;
            }

            CheckMovementInteractions();

            if (input != Vector2.zero && validMovement)
            {
                wasMoving = true;
                StartCoroutine(move(transform));
            }
        }
    }


    /**
     * Determines if any interactions occur due to the players input, including allowing movement,  picking up orders, placing orders
     * picking up food, dropping off food, and clean tables. It sends the respective messages if neccessary
     * @return void
     */
    protected virtual void CheckMovementInteractions()
    {
        void CheckEastwardInteractions()
        {
            if (input.x > 0 && playerPosition[0] + 1 < width)
            {
                    validMovement = true;
                    playerPosition[0] += 1;
                    GetComponent<Animator>().SetBool("Walking", true);
            }
        }

        void CheckWestwardInteractions()
        {
            if (input.x < 0 && playerPosition[0] > 0)
            {
                    validMovement = true;
                    playerPosition[0] -= 1;
                    
                    GetComponent<Animator>().SetBool("Walking", true);
            }
        }
        
        void CheckNorthwardInteractions()
        {
            if (input.y > 0 && playerPosition[1] > 0 )
            {
                    validMovement = true;
                    playerPosition[1] -= 1;
                    GetComponent<Animator>().SetBool("Walking", true);
            }
        }
        
        void CheckSouthwardInteractions()
        {
            if (input.y < 0 && playerPosition[1] + 1 < height)
            {
                    validMovement = true;
                    playerPosition[1] += 1;
                    GetComponent<Animator>().SetBool("Walking", true);
            }
        }

        CheckEastwardInteractions();
        CheckWestwardInteractions();
        CheckNorthwardInteractions();
        CheckSouthwardInteractions();
    }

    /**
     * Given the position to move the player character sprite, gradually increment the player sprite position until it arrives
     * at the given position. IEnumerator act over a time period without interrupting other game processes
     * @param transform the position the player sprite is moving to
     * @return nothing
     */
    public virtual IEnumerator move(Transform transform)
    {
        isMoving = true;
        startPosition = transform.position;
        t = 0;
        
        endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize, startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
        factor = 1f;
        while (t < 1f)
        {
            t += Time.deltaTime * (moveSpeed / gridSize) * factor;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
        isMoving = false;
        GetComponent<Animator>().SetBool("Walking", false);
        yield return 0;
    }

}