using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AturanSkor : MonoBehaviour
{
    public GameObject berhasil, gagal;
    public GameObject btnBack;
    Text text;
    int skor;

    // Start is called before the first frame update
    void Start()
    {
        skor = PlayerPrefs.GetInt("skor");
    }

    // Update is called once per frame
    void Update()
    {
        //jika scor kurang dari 70 maka tidak bisa nek level
        if (skor >= 70)
        {
            //scor 70 dan lebih
            gagal.SetActive(false);
            berhasil.SetActive(true);
            btnBack.SetActive(false);
        }
        else
        {
            //scor kurang dari 70
            gagal.SetActive(true);
            berhasil.SetActive(false);
            btnBack.SetActive(false);
        }
    }
}
