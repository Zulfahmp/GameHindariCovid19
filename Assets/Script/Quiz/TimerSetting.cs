using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSetting : MonoBehaviour
{

    public Text TextTimer;
    public float Waktu = 100; // 01:30


    public bool GameAktif = true;
    public GameObject CanvasKalah, Selesai;

    private void Start()
    {
        
    }

    void SetText ()
    {
        int Menit = Mathf.FloorToInt(Waktu / 60); // 01
        int Detik = Mathf.FloorToInt(Waktu % 60); // 30
        TextTimer.text = "TIME : " + Menit.ToString("00") + ":" + Detik.ToString("00");
    }

    float s;

    private void Update()
    {
        //Selesai.SetActive(true);
        if (GameAktif)
         {
             s += Time.deltaTime;
        if( s >= 1)
        {
            Waktu --;
            s = 0;
        }

        }

        if (GameAktif && Waktu <= 0)
        {
            Debug.Log("Game Kalah");
            CanvasKalah.SetActive(true);
            GameAktif = false;
        }
        SetText();

        Selesai = GameObject.Find("Finish");
        //Selesai.SetActive(true);
        if (Selesai)
        {
            GameAktif = false;
        }
    }

}
