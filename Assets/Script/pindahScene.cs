using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pindahScene : MonoBehaviour
{
    public AudioSource klik;

    public void LoadScene(string namaScene)
    {
        klik.PlayOneShot(klik.clip);
        SceneManager.LoadScene(namaScene);
        Time.timeScale = 1;
    }
}
