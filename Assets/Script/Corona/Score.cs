using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score;
    public Text scoreUI;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Virus")){
            score += 1;
            scoreUI.text = score.ToString();
            Destroy(collision.collider.gameObject);
        }
    }
}
