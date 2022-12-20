using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunculNyawa : MonoBehaviour
{
    public GameObject virus;
    public float posisiMinimal, posisiMaksimal;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Munculnyawa());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Munculnyawa()
    {
        //waktu tunggu virus muncul
        yield return new WaitForSeconds(10);
        //munculin object virus sesuai posisi
        Instantiate(virus, transform.position + Vector3.right * Random.Range(posisiMinimal, posisiMaksimal)
            , Quaternion.identity);
        //mengulang methos MunculVirus()
        StartCoroutine(Munculnyawa());
    }
}
