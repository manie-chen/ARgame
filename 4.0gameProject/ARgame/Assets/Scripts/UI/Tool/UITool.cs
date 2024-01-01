using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// UI工具类
    /// </summary>
    public class UITool
    {
        private GameObject _nowPanel;
        
        public UITool(GameObject panel)
        {
            _nowPanel = panel;
        }

        /// <summary>
        /// 给当前面板添加组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetOrAddComponent<T>() where T : Component
        {
            if (_nowPanel.GetComponent<T>() == null)
                _nowPanel.AddComponent<T>();
            return _nowPanel.GetComponent<T>();
        }

        /// <summary>
        /// 查找子对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GameObject FindChildGameObject(string name)
        {
            Transform[] trans = _nowPanel.GetComponentsInChildren<Transform>();
            foreach (var item in trans)
            {
                if (item.name == name)
                {
                    return item.gameObject;
                }
            }
            Debug.LogError($"找不到{name}子对象");
            return null;
        }

        /// <summary>
        /// 获取子对象组件
        /// </summary>
        /// <param name="name"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetOrAddComponentInChildren<T>(string name) where T :Component
        {
            GameObject child = FindChildGameObject(name);
            if (child)
            {
                if (child.GetComponent<T>() == null)
                {
                    child.AddComponent<T>();
                }

                return child.GetComponent<T>();
            }
            
            Debug.LogError($"找不到{name}子对象组件");
            return null;
        }

        /// <summary>
        /// 按钮添加点击事件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="action"></param>
        public void AddClickEvent(string name, Action action)
        {
            GetOrAddComponentInChildren<Button>(name).onClick.AddListener(() =>
            {
                action?.Invoke();
            });
        }

        /// <summary>
        /// 添加子对象
        /// </summary>
        public void AddChildItem<T>(string name, GameObject child) where T : UIModelBase
        {
            GameObject parent = FindChildGameObject(name);
            if (parent)
            {
                child.transform.parent = parent.transform;
                child.transform.localPosition = Vector3.zero;
            }
        }
        
        
        /// <summary>
        /// 隐藏对象
        /// </summary>
        public void HideGameObject(string name)
        {
            GameObject child = FindChildGameObject(name);
            if (child)
            {
                child.SetActive(false);
            }
        }

        /// <summary>
        /// 显示对象
        /// </summary>
        /// <param name="name"></param>
        public void ShowGameObject(string name)
        {
            GameObject child = FindChildGameObject(name);
            if (child)
            {
                child.SetActive(true);
            }
        }
        
    }
}