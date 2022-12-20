using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunculinVirus : MonoBehaviour
{
    public GameObject virus;
    public float waktuMinimal, waktuMaximal, posisiMinimal, posisiMaksimal;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MunculVirus());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MunculVirus()
    {
        //munculin object virus sesuai posisi
        Instantiate(virus, transform.position + Vector3.right * Random.Range(posisiMinimal, posisiMaksimal)
            , Quaternion.identity);
        //waktu tunggu virus muncul
        yield return new WaitForSeconds(Random.Range(waktuMinimal,waktuMaximal));
        //mengulang methos MunculVirus()
        StartCoroutine(MunculVirus());
    }
}
