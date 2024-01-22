using System;
using Cysharp.Threading.Tasks;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneSys
{
    /// <summary>
    /// 场景状态
    /// </summary>
    public class BaseScene
    {
        public UIManager UIManager;
    
        /// <summary>
        /// 场景名字
        /// </summary>
        public string SceneName { get; set; }

        public BaseScene()
        {
            UIManager = new UIManager();
        }

        public virtual async UniTask OnEnter()
        {
            // 加载的是新场景
            if (SceneManager.GetActiveScene().name != SceneName)
            {
                // 加载完成后通知
                SceneManager.sceneLoaded += SceneLoaded;
                
                await SceneManager.LoadSceneAsync(SceneName);
            }
            else
            {
                // 直接通知
                SceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
            }
        }

        /// <summary>
        /// 初始化ui层级
        /// </summary>
        private void InitLayer()
        {
            Debug.Log("init layer");
            GameObject uiRoot = GameObject.Find("Canvas");
            foreach (UILayer uiLayer in Enum.GetValues(typeof(UILayer)))
            {
                var layer = new GameObject();
                layer.name = uiLayer.ToString();
                layer.transform.parent = uiRoot.transform;
                layer.transform.localPosition = Vector3.zero;
            }
        }

        public virtual void OnExit()
        {
            SceneManager.sceneLoaded -= SceneLoaded;
            // UIManager.PopAllUI();
        }
    
        public virtual void SceneLoaded(Scene scene, LoadSceneMode load)
        {
            InitLayer();
            Debug.Log($"加载{SceneName}场景");
        }
    }
}
