using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpPause : MonoBehaviour
{
    public GameObject popUp;
    public bool aktif;
    
    public void PopUpSetting()
    {
        popUp.SetActive(aktif);
        Time.timeScale = 0;
    }

}
