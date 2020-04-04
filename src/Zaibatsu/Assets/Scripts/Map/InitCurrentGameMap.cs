using UnityEngine;

public class InitCurrentGameMap : MonoBehaviour
{
    [SerializeField] private CurrentGameMap map;

    private void Awake() => map.Init();
}