using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SoundSlider : MonoBehaviour
{
    Scrollbar scrollbar
    {
        get {return GetComponent<Scrollbar>();}
    }
    public AudioMixer mixer;
    public string volumeName;
    [SerializeField]float valor;
    //float volume;
    void Start()
    {
        mixer.GetFloat(volumeName, out valor);
        scrollbar.value = (valor + 80 )/ 100;
    }

    public void UpdateValueOnChange(){

        mixer.SetFloat(volumeName, Mathf.Log(scrollbar.value + 0.01f) * 20f);
    }
}
