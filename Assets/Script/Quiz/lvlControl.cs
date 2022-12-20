using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lvlControl : MonoBehaviour
{
    public Button Lvl2, Lvl3;
    int levelPassed;

    // Start is called before the first frame update
    void Start()
    {
        //untuk membuka level selanjutnya ketika level satu selesai
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        //agar tidak bisa clik di awal scene
        Lvl2.interactable = false;
        Lvl3.interactable = false;

        switch (levelPassed)
        {
            case 1:
                Lvl2.interactable = true;
                break;
            case 2:
                Lvl2.interactable = true;
                Lvl3.interactable = true;
                break;
        }
    }

    public void levelToLoad(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void resetPlayerPrefs()
    {
        Lvl2.interactable = false;
        Lvl3.interactable = false;
        PlayerPrefs.DeleteAll();
    }
}
