using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] RawImage rawImage;
    [SerializeField] AudioClip[] audioClip;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        StartCoroutine(GetTextures("https://ichef.bbci.co.uk/news/800/cpsprodpb/184E3/production/_120355599_chi-han-lin_see-who-jumps-high_00006221.jpg"));

    }



    public void Search()
    {
        GameObject objectSearched = GameObject.Find("Drone");

        objectSearched.transform.GetChild(0).gameObject.SetActive(true);

        AudioSource.PlayClipAtPoint(audioClip[0], objectSearched.transform.position);
    }

    public void Signal()
    {
        audioSource.PlayOneShot(audioClip[1]);
    }

    IEnumerator GetTextures(string url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture textures = ((DownloadHandlerTexture)www.downloadHandler).texture;
            rawImage.texture = textures;
        }
    }

}
