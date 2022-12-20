using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUp : MonoBehaviour {
    public GameObject popup;
    public AudioSource klik;
    public bool aktif;
	// Use this for initialization

    public void PopUpSeting()
    {
        klik.PlayOneShot(klik.clip);
        popup.SetActive(aktif);
    }
	
}
