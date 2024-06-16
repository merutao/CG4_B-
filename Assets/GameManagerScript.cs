using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;
    public GameObject Goal;
    public GameObject coin;
    public GameObject goalParticle;

    public TextMeshProUGUI scoreText;
    public static int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        Screen.SetResolution(1920, 1080, false);

        Vector3 position = Vector3.zero;

        int[,] blockmap =
        {
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1},    
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1},    
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 3, 0, 0, 0, 0, 0, 0,  0, 2, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1},    
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 1, 1, 1,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1},    
                {1, 0, 0, 0, 0, 0, 0, 3, 0, 0,  0, 1, 1, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1},    
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1},    
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 1, 1, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1},    
                {1, 0, 0, 0, 0, 0, 3, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 3, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1},    
                {1, 0, 0, 0, 0, 1, 1, 1, 0, 0,  0, 0, 0, 0, 0, 0, 1, 1, 1, 1,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1},    
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1},             
        };


        int lenY = blockmap.GetLength(0); 
        int lenX = blockmap.GetLength(1); 

        for (int x = 0; x < lenX; x++)
        {
            for(int y = 0; y < lenY ; y++) 
            {
                position.y = -y + 5;
                if (blockmap[y, x] == 1)
                {
                    Instantiate(block, position, Quaternion.identity);
                }

                //GoalˆÊ’u
                if (blockmap[y, x] == 2)
                {
                    Instantiate(Goal, position, Quaternion.identity);
                    Goal.transform.position = position;
                    goalParticle.transform.position = position;
                }
                
                if (blockmap[y, x] == 3)
                {
                    Instantiate(coin, position, Quaternion.identity);
                }
                
            }
            position.x = x;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
       if(GoalScript.isGameClear == true) 
       {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
            }
       }

        scoreText.text = "SCORE " + score;
    }
}
