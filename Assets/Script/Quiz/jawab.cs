using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class jawab : MonoBehaviour
{
    public static jawab instance = null;
    public GameObject levelSign, feed_benar, feed_salah, lanjut, gagal;
    int sceneIndex, levelPassed, levelulang;
    
    public AudioSource buttonSound;
    // Start is called before the first frame update
    void Start()
    {
        
        levelSign = GameObject.Find("LevelNumber");
                
        //untuk mengaktifkan soal berikutnya
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        levelulang = PlayerPrefs.GetInt("LevelUlang");
    }

    public void jawaban(bool jawab){
        if (jawab)
        {
            //jika jawaban benar maka scor nambah dan feed_benar aktif
            feed_benar.SetActive(false);
            feed_benar.SetActive(true);
            int skor = PlayerPrefs.GetInt("skor") + 20;
            PlayerPrefs.SetInt("skor", skor);
        }else
        {
            //jawaban salah dam feed_salah aktif
            feed_salah.SetActive(false);
            feed_salah.SetActive(true);
        }
        //soal1 bakal
        gameObject.SetActive(false);
        //soal berikutnya aktif
        transform.parent.GetChild(gameObject.transform.GetSiblingIndex() + 1).gameObject.SetActive(true);
    }

    //percobaan
    public void lvlSelanjutnya()
    {
        if (levelPassed < sceneIndex)
        PlayerPrefs.SetInt("LevelPassed", sceneIndex);
        Invoke("loadNextLevel", 1f);
    }

    //percobaan
    public void ulang()
    {
        if (levelPassed < sceneIndex)
        PlayerPrefs.SetInt("LevelUlang", sceneIndex);
        Invoke("loadagainLevel", 1f);
    }

    void loadNextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }

    void loadagainLevel()
    {
        SceneManager.LoadScene(sceneIndex +1);
    }

    public void kembali(string scenename)
    {
        buttonSound.PlayOneShot(buttonSound.clip);
        SceneManager.LoadScene(scenename);
        if (levelPassed < sceneIndex)
        PlayerPrefs.SetInt("LevelPassed", sceneIndex);
        
    }

    void loadQuizLvl()
    {
        SceneManager.LoadScene("QuizLvl");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
