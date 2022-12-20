using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBUser : MonoBehaviour
{
    public static string Username;
    // Start is called before the first frame update
    void Start()
    {
        Username = PlayerPrefs.GetString("name1");
        Debug.Log(Username);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
