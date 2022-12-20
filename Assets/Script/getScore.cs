using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class getScore : MonoBehaviour
{
    string URL = "https://gamecovidta.000webhostapp.com/TA/getScore.php";

    public GameObject Loading;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getScores());
        Loading.SetActive(true);
    }

    IEnumerator getScores()
    {
        WWW www = new WWW(URL);
        yield return www;

        if(www.error == null)
        {
            processJsonData(www.text);
            Debug.Log(www.text);
            Loading.SetActive(false);
        }
        else
        {
            Debug.Log("Ada yang error nih!!!");
        }
    }

    private void processJsonData(string _url)
    {
        jsonDataClass jsonData = JsonUtility.FromJson<jsonDataClass>(_url);

        GameObject scrollView = transform.GetChild(0).gameObject;
        GameObject objectnya;

        foreach(scoreList x in jsonData.resultScore)
        {
            objectnya = Instantiate(scrollView, transform);

            objectnya.transform.GetChild(1).GetComponent<Text>().text = x.nama;
            objectnya.transform.GetChild(2).GetComponent<Text>().text = ""+x.score;

        } 
        Destroy(scrollView);

    }
}
