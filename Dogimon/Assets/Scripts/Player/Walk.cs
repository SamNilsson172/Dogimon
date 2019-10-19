using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public bool moveAllowance = true;
    public bool isMoving;
    public float distanceToMove; //set how big area the grid you move along is
    public float walkSpeed = 0;

    bool facingRight = false; //know what direction to flip

    private bool moveToPoint = false;
    private Vector3 endPosition;

    private void Start()
    {
        endPosition = transform.position;
    }

    // Update is called once per frame
    void Update() //moving grid based was "inspired" by https://forum.unity.com/threads/need-help-with-grid-based-movement-in-c.276793/
    {
        if (moveAllowance) //if you're allowed to move, which is when battle scene is loaded
        {
            if (!isMoving) //if not already moving, so you can't spam a button and keep going forward after you clicked
            {
                float moveX = Input.GetAxisRaw("Horizontal"); //get input
                float moveY = Input.GetAxisRaw("Vertical");
                if (moveX < -0.5)//if you click left
                {
                    endPosition = new Vector3(endPosition.x - distanceToMove, endPosition.y, endPosition.z);//set a position to move towards
                    moveToPoint = true; //tell it to move
                    isMoving = true; //you are now moving and can not change your position until you've moved
                    if (facingRight) //Flip to left
                    {
                        Flip();
                        facingRight = false;
                    }
                }
                else if (moveX > 0.5)//right
                {
                    endPosition = new Vector3(endPosition.x + distanceToMove, endPosition.y, endPosition.z);
                    moveToPoint = true;
                    isMoving = true;
                    if (!facingRight) //Flip to right
                    {
                        Flip();
                        facingRight = true;
                    }
                }
                else if (moveY > 0.5)//up
                {
                    endPosition = new Vector3(endPosition.x, endPosition.y + distanceToMove, endPosition.z);
                    moveToPoint = true;
                    isMoving = true;
                }
                else if (moveY < -0.5)//down
                {
                    endPosition = new Vector3(endPosition.x, endPosition.y - distanceToMove, endPosition.z);
                    moveToPoint = true;
                    isMoving = true;
                }
            }
        }
    }


    void Flip() //stolen from plattform base in dig01
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void FixedUpdate()
    {
        if (moveToPoint)
            transform.position = Vector3.MoveTowards(transform.position, endPosition, walkSpeed * Time.deltaTime); //move to en point
        if (transform.position == endPosition) //lets you move again if endpos reached
            isMoving = false;
    }

    private void OnCollisionStay2D(Collision2D collision) //if you hit a wall
    {
        float xDir = 1;
        float yDir = 1;
        if (transform.position.x < 0)
            xDir = -1;
        if (transform.position.y < 0)
            yDir = -1;
        bool positiveY = transform.position.y >= 0;
        transform.position = new Vector2(Mathf.Abs((int)transform.position.x + (distanceToMove / 2 * xDir)) * xDir, Mathf.Abs((int)transform.position.y + (distanceToMove / 2 * yDir)) * yDir); //cast to int and add half of distance to move to addhear to tile walk grid, abs for negative values

        endPosition = transform.position;
    }
}
