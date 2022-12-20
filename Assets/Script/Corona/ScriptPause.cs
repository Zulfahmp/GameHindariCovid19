using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptPause : MonoBehaviour
{
    public GameObject popUp;
    public bool aktif;

    public void Lanjut()
    {
        popUp.SetActive(aktif);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
