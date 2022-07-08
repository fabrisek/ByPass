using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomeSave 
{
    List<Vector3> positionPlayer;
    List<Quaternion> rotationPlayer;
    List<float> time;

    public FantomeSave ()
    {
        positionPlayer = new List<Vector3>();
        rotationPlayer = new List<Quaternion>();
        time = new List<float>();
    }

    public void SaveData (Vector3 position, Quaternion rotation, float time)
    {
        positionPlayer.Add(position);
        rotationPlayer.Add(rotation);
        this.time.Add(time);
    }

}
