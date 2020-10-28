using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    [SerializeField] bool moveUp = true;
    [SerializeField] float MaxAngle = 25;
    [SerializeField] float angleStep = 0.1f;
    float currentAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveUp)
        {
            currentAngle += angleStep;
            if (currentAngle > MaxAngle)
            {
                moveUp = false;
            }
        }
        else 
        {
            currentAngle -= angleStep;
            if(currentAngle < -MaxAngle )
            {
                moveUp = true;
            }
        }
        transform.rotation = Quaternion.Euler(currentAngle,
                                              -currentAngle,
                                              transform.rotation.x);
    }
}
