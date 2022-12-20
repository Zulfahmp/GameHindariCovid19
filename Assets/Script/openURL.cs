using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openURL : MonoBehaviour
{
    public void URL()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.mobile.legends&hl=in&gl=US");
    }

    public void Keluar()
    {
        Application.Quit();
    }
}
