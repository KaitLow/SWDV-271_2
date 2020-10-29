using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectHit : MonoBehaviour
{
    [SerializeField] GameObject deathFX; // deaths effect for enemy ships
    [SerializeField] Transform parent;  // placeholder to destroy deathFX when done
    [SerializeField] int goldIncrease = 10;
    [SerializeField] int hits = 3;

    ScoreBoard goldBoard;
    public Slider healthbar;
    //Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        //AddNonTriggerBoxCollider();
        goldBoard = FindObjectOfType<ScoreBoard>();
    }
    //private void AddNonTriggerBoxCollider()
    //{
    //    Collider boxCollider = gameObject.AddComponent<BoxCollider>();
    //    boxCollider.isTrigger = false;
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (--hits <= 1)
        {
            KillEnemy();
        }
    }
    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        goldBoard.ScoreHit(goldIncrease);

        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
