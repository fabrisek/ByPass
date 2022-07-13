using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CardWorld : MonoBehaviour
{
    [SerializeField] Color colorImageLock;
    [SerializeField] Sprite imageLock;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] TextMeshProUGUI levelName;
    [SerializeField] TextMeshProUGUI posPlayer;
    [SerializeField] TextMeshProUGUI starPlayer;
    bool unlock;
    SceneObject objRef;
    int _levelIndex;

    // Start is called before the first frame update

    public void ChangeInformation(SceneObject obj, float timerSave, int star, bool isUnlock, int levelIndex)
    {
        _levelIndex = levelIndex;
        objRef = obj;
        levelName.text = obj.MapName;

        unlock = isUnlock;
        if (!isUnlock)
        {
            image.sprite = obj.SpriteCard;
            image.color = colorImageLock;
            timer.text = "";
            starPlayer.text = "";
        }
        else
        {
            
            image.sprite = obj.SpriteCard;
            timer.text = Timer.FormatTime(timerSave);            
            starPlayer.text = star.ToString() + " / 5";
        }
    }

    public void ClickButton()
    {
        if (unlock)
        {
            GameManager.Instance.LoadLevel(objRef);
            GameManager.Instance.ChangeLevelIndex(_levelIndex);
            InputManager.Instance.ActiveActioMapInGame(false);
        }
        else
        {
            //AudioManager.instance.playSoundEffect(5, 1);
            //Debug.Log("je suis bloquer");
            Debug.Log("Ajouter anim bloquer");
        }
    }
}
