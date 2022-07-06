using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundButton : MonoBehaviour
{
    public void PlaySoundbutton(int son)
    {
        GameManager.Instance.PlaySound(TypeOfSound.sfx3D, Vector3.zero, (SfxSon)son);
    }
}
