using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System;

public class demo : MonoBehaviour
{

    public struct Data
    {
        public string Name1, Name2, Name3, Name4, Name5, Name6, Name7;
        public string ImageURL1, ImageURL2, ImageURL3, ImageURL4, ImageURL5, ImageURL6, ImageURL7;
    }

    [SerializeField] Text uiNameText1, uiNameText2, uiNameText3, uiNameText4, uiNameText5, uiNameText6, uiNameText7;
    [SerializeField] RawImage uiRawImage1, uiRawImage2, uiRawImage3, uiRawImage4, uiRawImage5, uiRawImage6, uiRawImage7;
    [SerializeField] AudioSource suara;

    string jsonURL = "https://drive.google.com/uc?export=download&id=1oYBnROW4Lg4nHHlOooXFcmtK0zAy7bOT";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetData(jsonURL));
    }

    IEnumerator GetData(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.Send();

        if (request.isNetworkError)
        {
            Debug.Log("error getData");
        }
        else
        {
            Data data = JsonUtility.FromJson<Data>(request.downloadHandler.text);

            uiNameText1.text = data.Name1;
            StartCoroutine(GetImage1(data.ImageURL1));

            uiNameText2.text = data.Name2;
            StartCoroutine(GetImage2(data.ImageURL2));

            uiNameText3.text = data.Name3;
            StartCoroutine(GetImage3(data.ImageURL3));

            uiNameText4.text = data.Name4;
            StartCoroutine(GetImage4(data.ImageURL4));

            uiNameText5.text = data.Name5;
            StartCoroutine(GetImage5(data.ImageURL5));

            uiNameText6.text = data.Name6;
            StartCoroutine(GetImage6(data.ImageURL6));

            uiNameText7.text = data.Name7;
            StartCoroutine(GetImage7(data.ImageURL7));
        }
        request.Dispose();

    }

    IEnumerator GetImage1(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.Send();

        if (request.isNetworkError)
        {
            Debug.Log("error getImage");
        }
        else
        {
            uiRawImage1.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
        request.Dispose();
    }

    IEnumerator GetImage2(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.Send();

        if (request.isNetworkError)
        {
            Debug.Log("error getImage");
        }
        else
        {
            uiRawImage2.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
        request.Dispose();
    }

    IEnumerator GetImage3(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.Send();

        if (request.isNetworkError)
        {
            Debug.Log("error getImage");
        }
        else
        {
            uiRawImage3.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
        request.Dispose();
    }

    IEnumerator GetImage4(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        //UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV);
        yield return request.Send();

        if (request.isNetworkError)
        {
            Debug.Log("error getImage");
        }
        else
        {
            uiRawImage4.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
        request.Dispose();
    }

    IEnumerator GetImage5(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.Send();

        if (request.isNetworkError)
        {
            Debug.Log("error getImage");
        }
        else
        {
            uiRawImage5.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
        request.Dispose();
    }

    IEnumerator GetImage6(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.Send();

        if (request.isNetworkError)
        {
            Debug.Log("error getImage");
        }
        else
        {
            uiRawImage6.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
        request.Dispose();
    }

    IEnumerator GetImage7(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.Send();

        if (request.isNetworkError)
        {
            Debug.Log("error getImage");
        }
        else
        {
            uiRawImage7.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
        request.Dispose();
    }
}
