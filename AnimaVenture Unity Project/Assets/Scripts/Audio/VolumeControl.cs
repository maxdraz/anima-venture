using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{

    public AudioMixer master;

    public void SetSfxLvl(float sfxLvl)
    {
        master.SetFloat("sfxVol", sfxLvl);
    }

    public void SetMusicLvl(float musicLvl)
    {
        master.SetFloat("musicVol", musicLvl);
    }

    public void SetMasterLvl(float masterLvl)
    {
        master.SetFloat("masterVol", masterLvl);
    }

}
