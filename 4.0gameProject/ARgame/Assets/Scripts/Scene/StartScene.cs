using UI;
using UnityEngine.SceneManagement;

namespace SceneSys  
{
    public class StartScene : BaseScene
    {
        public StartScene()
        {
            SceneName = "StartScene";
        }

        public override void SceneLoaded(Scene scene, LoadSceneMode load)
        {
            base.SceneLoaded(scene, load);
            UIManager.PushUI(new ChoosePanel());
        }
    
    }
}

