using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcakBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] pos_btn = new Vector3[transform.childCount];
        bool[] tidak_numpuk = new bool[transform.childCount];
        for (int i = 0; i < pos_btn.Length; i++)
        {
            pos_btn[i] = transform.GetChild(i).position;
            tidak_numpuk[i] = false;
        }


        for (int i = 0; i < pos_btn.Length; i++)
        {
            bool mengulang = true;
            while (mengulang)
            {
                int pos_random = Random.Range(0, transform.childCount);
                if (!tidak_numpuk[pos_random])
                {
                    transform.GetChild(i).transform.position = pos_btn[pos_random];
                    tidak_numpuk[pos_random] = true;
                    mengulang = false;
                }
                else
                {
                    mengulang = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
