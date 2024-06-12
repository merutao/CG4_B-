using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    private float moveSpeed;

    float distance = 0.6f;

    private bool isBlock = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalScript.isGameClear == false)
        {
            Vector3 v = rb.velocity;
            moveSpeed = 9;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                v.x = moveSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                v.x = -moveSpeed;
            }
            else
            {
                v.x = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isBlock == true)
            {
                v.y = moveSpeed;
            }
            rb.velocity = v;
        }

        //プレイヤーの下方向レイ
        Vector3 rayPosition = transform.position;
        Ray ray = new Ray(rayPosition, Vector3.down);

        Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);

        isBlock = Physics.Raycast(ray, distance);

        if (isBlock == true) 
        {
            Debug.DrawRay(rayPosition, Vector3.down*distance, Color.red);
        }
        else
        {
            Debug.DrawRay(rayPosition,Vector3.down*distance, Color.yellow);
        }
    }
}
