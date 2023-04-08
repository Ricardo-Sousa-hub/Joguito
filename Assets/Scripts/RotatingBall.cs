using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBall : MonoBehaviour
{
    private float rotZ;
    public bool sentido;
    public float rotationSpeed;
    public List<GameObject> balls;
    public int number;
    public bool single;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!single)
        {
            switch (number)
            {
                case 0:
                    balls[0].SetActive(false);
                    balls[1].SetActive(false);
                    balls[2].SetActive(false);
                    balls[3].SetActive(false);
                    break;
                case 1:
                    balls[0].SetActive(true);
                    break;
                case 2:
                    balls[0].SetActive(true);
                    balls[1].SetActive(true);
                    break;
                case 3:
                    balls[0].SetActive(true);
                    balls[1].SetActive(true);
                    balls[2].SetActive(true);
                    break;
                case 4:
                    balls[0].SetActive(true);
                    balls[1].SetActive(true);
                    balls[2].SetActive(true);
                    balls[3].SetActive(true);
                    break;
            }
        }

        if (!sentido)
        {
            rotZ += Time.deltaTime * rotationSpeed;
        }
        else
        {
            rotZ += -Time.deltaTime * rotationSpeed;
        }
        


        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
