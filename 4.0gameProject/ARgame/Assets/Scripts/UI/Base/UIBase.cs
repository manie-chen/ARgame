using UnityEngine;

namespace UI
{
    public class UIBase
    {
        public string UIPath { get; set; }
        
        public string UIName { get; set; }
        
        public UIModelBase UIModel { get; set; }
        
        public UIBase()
        {
            
        }
        
        public UITool UITool { get; private set; }
        public UIManager UIManager { get; private set; }

        public void Init(UITool uiTool, UIManager uiManager, UIModelBase uiModelBase)
        {
            UITool = uiTool;
            UIManager = uiManager;
            UIModel = uiModelBase;
        }
        

        /// <summary>
        /// 进入
        /// </summary>
        public virtual void OnEnter()
        {
            
        }
    
        /// <summary>
        /// 暂停，点开界面内其他按钮时
        /// </summary>
        public virtual void OnPause()
        {
            UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = false;
        }
    
        /// <summary>
        /// 继续执行
        /// </summary>
        public virtual void OnResume()
        {
            UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = true;

        }
    
        /// <summary>
        /// 退出
        /// </summary>
        public virtual void OnExit()
        {
            UIManager.DestroyUI(UIName);
        }
    }
}

