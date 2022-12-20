using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class cobaCoba : MonoBehaviour
{
    [Serializable]
    public struct Atribut
    {
        public string nama;
        public string point;
    }

    
    string URL = "http://localhost/covid_game/getData2.php";
    public string[] data;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW users = new WWW(URL);
        yield return users;
        string userDataString = users.text;
        data = userDataString.Split(',');

        GameObject scrollView = transform.GetChild(0).gameObject;
        GameObject objectnya;

        for (int i = 0; i < data.Length; i++)
        {
            objectnya = Instantiate(scrollView, transform);
            objectnya.transform.GetChild(0).GetComponent<Text>().text = data[i];
            objectnya.transform.GetChild(1).GetComponent<Text>().text = data[i];
        }

        Destroy(scrollView);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
