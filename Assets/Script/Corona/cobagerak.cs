using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cobagerak : MonoBehaviour
{
    public Text nyawaUI;

    public GameObject PopUpKalah;
    public GameObject loading;

    public AudioSource ouch, yeah, kalah;

    public Text skor;
    public Text skorDB;
    private string Nama;
    public float nyawa = 3;

    public float playerSpeed = 5f;
    private float playerDir;

    private Rigidbody rb;

    private bool facingRight = true;
    
    public Transform playerPutaran;
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        Nama = PlayerPrefs.GetString("name1");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(playerDir);

        FlipPlayer();
    }

    void MovePlayer(float playerDir)
    {
        rb.velocity = new Vector3(playerDir, rb.velocity.y, 0f);
        anim.SetFloat("Kecepatan", Mathf.Abs(playerDir), 0.1f, Time.deltaTime);
    }

    void FlipPlayer()
    {
        if (playerDir > 0 && !facingRight || playerDir < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 tempScale = transform.localScale;
            tempScale.x *= -1f;
            transform.localScale = tempScale;
        }
    }

    

    public void MoveLeft()
    {
        playerDir = -playerSpeed;
        rb.velocity = Vector3.left * playerDir;
        anim.SetFloat("Kecepatan", Mathf.Abs(playerDir), 0.1f, Time.deltaTime);
        playerPutaran.localEulerAngles = new Vector3(0, playerDir * -90, 0);
    }

    public void MoveRight()
    {
        playerDir = playerSpeed;
        rb.velocity = Vector3.right * playerDir;
        anim.SetFloat("Kecepatan", Mathf.Abs(playerDir), 0.1f, Time.deltaTime);
        playerPutaran.localEulerAngles = new Vector3(0, playerDir * 90, 0);
    }

    public void StopMoving()
    {
        playerDir = 0;
        anim.SetFloat("Kecepatan", Mathf.Abs(playerDir), 0.1f, Time.deltaTime);
        playerPutaran.localEulerAngles = new Vector3(0, playerDir * 0, 0);
    }

    //ketika player bersentuhan dengan sesuatu
    private void OnCollisionEnter(Collision collision)
    {
        //ketika player bersentuhan dengan tag yg bernama virus
        if (collision.collider.CompareTag("Virus"))
        {
            nyawa -= 1; //int
            nyawaUI.text = nyawa.ToString(); //convert dari float ke string
            Time.timeScale = 1; //mengatur kecepatan 
            ouch.PlayOneShot(ouch.clip); //audio ketika terkena virus
            Destroy(collision.collider.gameObject); //virus hilang ketika kena player
            if (nyawa == 0)
            {
                //karena skor dan skorDB adalah string makan saya convert dlu menjadi int agar bisa dibandingkan
                int a = int.Parse(skor.text);
                int x = int.Parse(skorDB.text);

                //jika skor aktual lebih dari skor pada DB, maka skor aktual akan tersave sbagai skor tertinggi
                if (a > x)
                {
                    Debug.Log("Save");
                    Time.timeScale = 0; //waktu berhenti
                    kalah.PlayOneShot(kalah.clip); //audio ketika nyawa 0/kalah
                    PopUpKalah.SetActive(true); //pop saat nayawa 0 = kalah
                    loading.SetActive(true);
                    StartCoroutine(SaveScore());
                }
                else
                {
                    Debug.Log("Not Save");
                    Time.timeScale = 0; //waktu berhenti
                    kalah.PlayOneShot(kalah.clip); //audio ketika nyawa 0/kalah
                    PopUpKalah.SetActive(true); //pop saat nayawa 0 = kalah
                }
            }
        }

        //ketika player bersentuhan dengan tag yg bernama nyawa
        if (collision.collider.CompareTag("Nyawa"))
        {
            nyawa += 1; //nyawa nambah
            nyawaUI.text = nyawa.ToString(); //convert string
            yeah.PlayOneShot(yeah.clip); //audio play
            Destroy(collision.collider.gameObject); //nyawa hancur ketika kena
        }
    }

    IEnumerator SaveScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("nama", Nama);
        form.AddField("score", skor.text);

        WWW www = new WWW("https://gamecovidta.000webhostapp.com/TA/saveScore.php", form);
        yield return www;

        if (www.text == "0")
        {
            loading.SetActive(false);
            Debug.Log("Berhasil Update");
        }
        else
        {
            loading.SetActive(false);
            Debug.Log("Update Gagal. Error #" + www.error);
        }
    }
}
