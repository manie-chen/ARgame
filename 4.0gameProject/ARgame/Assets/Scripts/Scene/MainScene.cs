using UI;
using UnityEngine.SceneManagement;

namespace SceneSys
{
    public class MainScene : BaseScene
    {
        public MainScene()
        {
            SceneName = "MainScene";
        }

        public override void SceneLoaded(Scene scene, LoadSceneMode load)
        {
            base.SceneLoaded(scene, load);
            UIManager.PushUI(new HallPanel());
        }
    }
}

