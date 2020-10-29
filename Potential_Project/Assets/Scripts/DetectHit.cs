using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectHit : MonoBehaviour
{
    public Slider healthbar;
    Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        healthbar.value -= 20;
        
        if (healthbar.value <= 0)
        {
            anim.SetBool("die", true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
