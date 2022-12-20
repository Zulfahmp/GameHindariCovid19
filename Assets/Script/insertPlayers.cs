using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insertPlayers : MonoBehaviour
{
    string URL = "https://gamecovidta.000webhostapp.com/TA/insertPlayer.php";
    string URLUpdateNama = "http://localhost/covid_game/updateNama.php";

    //deklarasi variabel

    
    public GameObject popUpPlay;
    public GameObject loading;

    public Text skor;

    public Button submitButton;
    public Button submitUpdateButton;

    private void Start()
    {
        playerNameAwal.text = PlayerPrefs.GetString("name");

        if(playerNameAwal.text == "")
        {
            popUpInputName.SetActive(true);
        }
    }

    //yg pertama di load
    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    public void CallUpdateNama()
    {
        StartCoroutine(UpdateName());
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
            PlayerPrefs.SetString("name", namaField.text);

            DBManager.nama = namaField.text;
            playerNameAwal.text = PlayerPrefs.GetString("name");
            playerNameInGame.text = PlayerPrefs.GetString("name");

            loading.SetActive(false);

            Debug.Log("Nama Yang Kesimpen " + DBManager.nama);

            Debug.Log("Nama Berhasil Dibuat");
            popUpSukses.SetActive(true);
            popUpFailed.SetActive(false);
            popUpInputName.SetActive(false);
            popUpPlay.SetActive(true);
            berhasil.text = "Nama Berhasil Dibuat";
        }
        else
        {
            loading.SetActive(false);
            Debug.Log(www.text);
            popUpSukses.SetActive(false);
            popUpFailed.SetActive(true);
            failed.text = www.text;
        }
    }

    IEnumerator UpdateName()
    {
        WWWForm form = new WWWForm();
        
        form.AddField("nama", playerNameAwal.text);
        //form.AddField("nama2", "paulyang");
        form.AddField("nama2", updateNamaField.text);

        WWW www = new WWW("https://gamecovidta.000webhostapp.com/TA/updateNama.php", form);
        yield return www;

        if(www.text == "0")
        {
            Debug.Log("Berhasil Update Nama");
            loading.SetActive(false);

            popUpSukses.SetActive(true);
            popUpFailed.SetActive(false);
            berhasilUpdate.text = "Update Nama Berhasil!!!";
        }
        else
        {
            loading.SetActive(false);
            Debug.Log("Update Gagal. Error #" + www.error);

            popUpSukses.SetActive(false);
            popUpFailed.SetActive(true);
            failedUpdate.text = "Gagal Update Nama!!!";
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (namaField.text.Length >= 5);
    }

    public void VerifyInputsUpdate()
    {
        submitUpdateButton.interactable = (updateNamaField.text.Length >= 5);
    }
}
