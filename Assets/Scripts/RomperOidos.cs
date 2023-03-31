using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class RomperOidos : MonoBehaviour
{
    public AudioMixer mixer;
    public string volumeName;
    public void RomperOidosMucho(){
        mixer.SetFloat(volumeName, 100f);
    }
}
