using UnityEngine;
using UnityEngine.UI;

public sealed class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Navigator navigator;

    private void Awake()
    {
        startGameButton.onClick.AddListener(() => navigator.NavigateToGameScene());
    }
}
