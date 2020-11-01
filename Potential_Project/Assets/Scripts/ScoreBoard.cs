using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    // FA20Test Real Branch change
    [SerializeField] int gold = 0;
    Text goldText;

    private void Start()
    {
        goldText = GetComponent<Text>();
        goldText.text = gold.ToString();
    }
    public void ScoreHit(int scoreIncrease)
    {
        gold += scoreIncrease;
        goldText.text = gold.ToString();
    }
}
