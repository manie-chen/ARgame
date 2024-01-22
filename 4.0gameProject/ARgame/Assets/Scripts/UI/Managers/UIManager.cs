using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// ui层级
    /// </summary>
    public enum UILayer
    {
        LAYER_TIP,
        LAYER_TOP,
        LAYER_MID,
        LAYER_BOTTOM
    }
    /// <summary>
    /// 储存所有UI信息
    /// </summary>
    public class UIManager
    {
        /// <summary>
        /// 当前存在的界面
        /// </summary>
        private Dictionary<string, GameObject> _dicUI;
        private Stack<UIBase> StackPanel;
        private UIBase _panel;
        
        public UIManager()
        {
            _dicUI = new Dictionary<string, GameObject>();
            StackPanel = new Stack<UIBase>();
        }
        
        /// <summary>
        /// 实例化UI的prefab
        /// </summary>
        /// <param name="uiPath"></param>
        /// <param name="uiName"></param>
        /// <returns></returns>
        public GameObject ShowUI(string uiPath, string uiName, UILayer layer)
        {
            GameObject parent = GameObject.Find($"Canvas/{layer.ToString()}");
            if (!parent)
            {
                Debug.LogError($"Canvas/{layer.ToString()}不存在");
            }

            if (_dicUI.ContainsKey(uiName))
                return _dicUI[uiName];
            GameObject prefab = Resources.Load<GameObject>(uiPath);
            if (!prefab)
            {
                Debug.LogError($"无法从路径'{uiPath}'加载预制体");
                return null;
            }
            GameObject ui = GameObject.Instantiate(prefab, parent.transform);
            
            _dicUI.Add(uiName, ui);
            return ui;
        }

        public void DestroyUI(string uiName)
        {
            if (_dicUI.ContainsKey(uiName))
            {
                GameObject.Destroy(_dicUI[uiName]);
                _dicUI.Remove(uiName);
            }
        }
        
        /// <summary>
        /// 暂停当前面板，入栈新面板并显示
        /// </summary>
        /// <param name="nextPanel"></param>
        public UIBase PushUI(UIBase nextPanel,UILayer layer = UILayer.LAYER_TOP,UIModelBase uiModel = null)
        {
            if (StackPanel.Count > 0)
            {
                _panel = StackPanel.Peek();
                _panel.OnPause();
            }
            StackPanel.Push(nextPanel);

            GameObject newPanel = ShowUI(nextPanel.UIPath, nextPanel.UIName, layer);
            var uiTool = new UITool(newPanel);
            nextPanel.Init(uiTool, this, uiModel);
            nextPanel.OnEnter();
            return nextPanel;
        }

        /// <summary>
        /// 退出面板并出栈,启动上层面板
        /// </summary>
        public void PopUI()
        {
            if (StackPanel.Count > 0)
            {
                StackPanel.Pop().OnExit();
            }

            if (StackPanel.Count > 0)
            {
                StackPanel.Peek().OnResume();
            }
        }

        public void PopAllUI()
        {
            while (StackPanel.Count > 0)
            {
                StackPanel.Pop().OnExit();
            }
        }
    }
}