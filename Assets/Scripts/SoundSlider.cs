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
        mixer.GetFloat(volumeName,out valor);
        scrollbar.value =(float) Math.Pow(Math.E, valor/20.0f);
    }

    public void UpdateValueOnChange(){

        mixer.SetFloat(volumeName, Mathf.Log(scrollbar.value + 0.01f) * 20f);
    }
}

//valor = log10(value) * 20
//10^(valor/20) = value