using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public sealed class Navigator : ScriptableObject
{
    private string _currentScene;
    private string _previousScene;

    [SerializeField] private bool loadSynchronously;

    public void NavigateToMainMenu() => NavigateTo("MainMenu");
    public void NavigateToGameScene() => NavigateTo("GameScene");
    public void NavigateBack() => NavigateTo(_previousScene);

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    
    private void NavigateTo(string name)
    {
        _previousScene = SceneManager.GetActiveScene().name;
        _currentScene = name;
        
        // TODO: This should eventually be injected as an OnNavigate action instead.
        PlayerPrefs.Save();
        
        if (!loadSynchronously)
        {
            var loading = SceneManager.LoadSceneAsync(name);
            if (LoadingScreen.Instance != null)
                LoadingScreen.Instance.Init(loading);
        }
        else
        {
            SceneManager.LoadScene(name);
        }
    }
}
