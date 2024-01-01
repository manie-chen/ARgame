using UI;
using UnityEngine.SceneManagement;

namespace SceneSys
{
    public class MapScene: BaseScene
    {
        public MapScene()
        {
            SceneName = "MapScene";
        }

        public override void SceneLoaded(Scene scene, LoadSceneMode load)
        {
            base.SceneLoaded(scene, load);
            UIManager.PushUI(new MapPanel());
        }
    }
    
}

