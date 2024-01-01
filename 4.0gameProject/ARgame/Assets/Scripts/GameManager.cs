using SceneSys;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public SceneSystem SceneSystem { get; set; }

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        SceneSystem = new SceneSystem();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        SceneSystem.SetScene(new StartScene());
    }
}
