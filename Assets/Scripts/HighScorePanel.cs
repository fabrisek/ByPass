using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScorePanel : MonoBehaviour
{
    [SerializeField] Image picture;
    [SerializeField] string entityId;
    public void ChangeProfilePicture(string url, string entity)
    {
        entityId = entity;
        Davinci.get().load(url).into(picture).start();
    }

    public void GetGhost()
    {
        PlayfabGhost.Instance.GetGhostPlayer(entityId);
    }
}
