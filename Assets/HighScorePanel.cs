using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScorePanel : MonoBehaviour
{
    [SerializeField] Image picture;

    public void ChangeProfilePicture(string url)
    {
        Debug.Log(url);
        Davinci.get().load(url).into(picture).start();
    }
}
