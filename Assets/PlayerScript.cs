using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject bombParticle;

    private float moveSpeed;

    float distance = 0.6f;

    private bool isBlock = true;

    private AudioSource audioSource;

    private Animator animator;

  

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        transform.rotation = Quaternion.Euler(0, 90, 0);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float stick = Input.GetAxis("Horizontal");

        if (GoalScript.isGameClear == false)
        {
            Vector3 v = rb.velocity;
            moveSpeed = 9;
            if (Input.GetKey(KeyCode.RightArrow)||stick > 0)
            {
                v.x = moveSpeed;
                transform.rotation = Quaternion.Euler(0, 90, 0);
                animator.SetTrigger("walk");
            }
            else if (Input.GetKey(KeyCode.LeftArrow)||stick < 0)
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                v.x = -moveSpeed;
                animator.SetTrigger("walk");
            }
            else
            {
                v.x = 0;
            }

            if (Input.GetButtonDown("Jump") && isBlock == true)
            {
                v.y = moveSpeed;
                animator.SetTrigger("Jump");
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

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;
            Instantiate(bombParticle, transform.position, Quaternion.identity);
        }
        
    }

    

    

}
