using UI;
using UnityEngine.SceneManagement;

namespace SceneSys
{
    public class FightScene : BaseScene
    {
        public FightScene()
        {
            SceneName = "FightScene";
        }
        
        public override void SceneLoaded(Scene scene, LoadSceneMode load)
        {
            base.SceneLoaded(scene, load);
            UIManager.PushUI(new FightPanel());
        }
    }
}