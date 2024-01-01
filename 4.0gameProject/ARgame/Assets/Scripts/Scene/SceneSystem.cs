namespace SceneSys
{
    public class SceneSystem
    {
        private BaseScene _baseScene;

        /// <summary>
        /// 设置当前场景并进入
        /// </summary>
        /// <param name="scene"></param>
        public void SetScene(BaseScene scene)
        {
            _baseScene?.OnExit();
            _baseScene = scene;
            _baseScene?.OnEnter();
        }
    } 
}

