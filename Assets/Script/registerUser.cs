using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class registerUser : MonoBehaviour
{
    string URL = "https://gamecovidta.000webhostapp.com/TA/insertPlayer.php";
    string URLUpdateNama = "http://localhost/covid_game/updateNama.php";

    //deklarasi variabel
    public InputField namaField;

    public GameObject popUpSukses;
    public GameObject popUpFailed;
    public GameObject popUpInputName;

    public Text berhasil;
    public Text failed;

    public Button submitButton;

    // Start is called before the first frame update
    void Start()
    {
        if (DBUser.Username == "")
        {
            popUpInputName.SetActive(true);
        }
    }

    //yg pertama di load
    public void CallRegister()
    {
        popUpSukses.SetActive(false);
        popUpFailed.SetActive(false);
        StartCoroutine(Register());
    }

    //IEnumerator untuk manipulasi data di database
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("nama", namaField.text);

        WWW www = new WWW(URL, form);
        yield return www;

        if (www.text == "0")
        {
            PlayerPrefs.SetString("name1", namaField.text);

            Debug.Log("Nama Berhasil Dibuat");
            popUpSukses.SetActive(true);
            popUpFailed.SetActive(false);
            popUpInputName.SetActive(false);
            berhasil.text = "Nama Berhasil Dibuat";
            SceneManager.LoadScene("HindariCovid");
            Time.timeScale = 1;
        }
        else
        {
            Debug.Log(www.text);
            popUpSukses.SetActive(false);
            popUpFailed.SetActive(true);
            failed.text = www.text;
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (namaField.text.Length >= 5);
        if (namaField.text.Length > 15)
        {
            submitButton.interactable = false;
        }
    }

}
