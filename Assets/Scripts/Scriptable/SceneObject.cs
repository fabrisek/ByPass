using UnityEngine;

[CreateAssetMenu(fileName = "SceneDataDefault", menuName = "ScriptableObjects/SceneData", order = 1)]
public class SceneObject : ScriptableObject
{
    [field: SerializeField] public string MapName { get; private set; }
    [field: SerializeField] public int IndexScene { get; private set; }
    [field: SerializeField] public float[] TimeStar { get; private set; } = new float[5];
    [field: SerializeField] public Sprite SpriteCard { get; private set; }
}