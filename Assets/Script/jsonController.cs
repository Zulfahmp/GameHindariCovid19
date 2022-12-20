using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class jsonController : MonoBehaviour
{
    string URL = "https://gamecovidta.000webhostapp.com/TA/getVarian.php";

    public AudioSource audioSC1, audioSC2, audioSC3, audioSC4, audioSC5, audioSC6, audioSC7;

    public Text a;

    // Start is called before the first frame update
    void Start()
    {
        //startcorotine memulai method
        StartCoroutine(getData());
    }

    //ienumerator transaksi data, database
    IEnumerator getData()
    {
        //untuk mengambil data dari database dengan url
        //www adalah method
        WWW _www = new WWW(URL);
        yield return _www;

        //jika www tidak error/ errornya null
        if (_www.error == null)
        {
            //maka ini di proses
            processJsonData(_www.text);
        }
        else
        {
            //ini jika ada erronya
            Debug.Log("Ada Yang Error Nih");
        }
    }

    private void processJsonData(string _url)
    {
        jsonDataClass jsnData = JsonUtility.FromJson<jsonDataClass>(_url);

        GameObject scrollView = transform.GetChild(0).gameObject;
        GameObject objectnya;

        //perulangan sebanyak data pada database
        foreach (varianList x in jsnData.result)
        {
            //method untuk membuat list baru/object baru
            objectnya = Instantiate(scrollView, transform);
            
            objectnya.transform.GetChild(0).GetComponent<Text>().text = "Jenis Varian : " + x.jenis_varian;
            objectnya.transform.GetChild(1).GetComponent<Text>().text = "Versi Varian : " + x.versi_varian;
            objectnya.transform.GetChild(2).GetComponent<Text>().text = "Tanggal : " + x.tanggal;
            objectnya.transform.GetChild(3).GetComponent<Text>().text = "Negara : " + x.negara;
            objectnya.transform.GetChild(4).GetComponent<Text>().text = "Gejala : " + x.gejala;

            StartCoroutine(GetAudio1(x.audio));       
        }
        Destroy(scrollView);
    }

    //download audio
    IEnumerator GetAudio1(string url)
    {
        
        UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV);
        yield return request.Send();

        if (request.isNetworkError)
        {
            Debug.Log("error getAudio");
        }
        else
        {
            audioSC1.clip = ((DownloadHandlerAudioClip)request.downloadHandler).audioClip;
            Debug.Log("aaa " + audioSC1.clip.ToString());
            audioSC2.clip = ((DownloadHandlerAudioClip)request.downloadHandler).audioClip;
            audioSC3.clip = ((DownloadHandlerAudioClip)request.downloadHandler).audioClip;
            audioSC4.clip = ((DownloadHandlerAudioClip)request.downloadHandler).audioClip;
            audioSC5.clip = ((DownloadHandlerAudioClip)request.downloadHandler).audioClip;
            audioSC6.clip = ((DownloadHandlerAudioClip)request.downloadHandler).audioClip;
            audioSC7.clip = ((DownloadHandlerAudioClip)request.downloadHandler).audioClip;
        }
        request.Dispose();
    }
}
