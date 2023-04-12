using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainCameraMusic : MonoBehaviour
{

    [SerializeField]AudioClip[] canciones;
    [SerializeField]AudioSource audioSourceCamara;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSourceCamara.isPlaying){
            int random = Random.Range(0, canciones.Length);
            audioSourceCamara.clip = canciones[random];
            audioSourceCamara.Play();
        }
    }
}
