using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadNameScore : MonoBehaviour
{
   
    public Text skor;
    public Text skorDB;
    
    public Text namaInBoard;
    private string Nama;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getScore());

        Nama = PlayerPrefs.GetString("name1");
        namaInBoard.text = PlayerPrefs.GetString("name1");
    }

    IEnumerator getScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("nama", PlayerPrefs.GetString("name1"));

        WWW www = new WWW("https://gamecovidta.000webhostapp.com/TA/getScore1.php", form);
        yield return www;

        if (www.error == null)
        {
            Debug.Log(www.text);

            jsonDataClass jsonData = JsonUtility.FromJson<jsonDataClass>(www.text);

            foreach (score2 x in jsonData.resultScore2)
            {
                skorDB.text = "" + x.score;
                PlayerPrefs.SetString("skor", "" + x.score);
            }
        }
        else
        {
            Debug.Log("Ada yang error nih!!!");
        }
    }
}
