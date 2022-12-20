using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public struct DataCovid
{
    public string id;
    public string jenis_varian;
    public string versi_varian;
    public string tanggal;
    public string gejala;
    public string nama;
    public string point;
}

public class varian : MonoBehaviour
{
    string URL = "http://localhost/covid_game/getData2.php";
    public string[] varianData;

    public Text jenisVariant, versiVariant;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        UnityWebRequest variant = UnityWebRequest.Get(URL);
        yield return variant.Send();

        DataCovid data = JsonUtility.FromJson<DataCovid>(variant.downloadHandler.text);

        jenisVariant.text = data.nama;
        versiVariant.text = data.point;

        //yield return variant;
        //string variantDataString = variant.text;
        //varianData = variantDataString.Split('}');

        //for (int i = 0; i < varianData.Length; i++)
        //{
        //print(varianData.Length.ToString());
        //}
    }

    string GetValueData(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        
        if (value.Contains(","))
        {
            value = value.Substring(value.IndexOf(","));
        }
        return value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
