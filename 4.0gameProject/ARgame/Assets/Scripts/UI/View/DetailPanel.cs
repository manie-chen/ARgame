using SceneSys;
using UnityEngine;

namespace UI
{
    public class DetailPanel :UIBase
    {
        private DetailPanelModel _model;

        public DetailPanel()
        {
            UIPath = "Prefabs/Panel/DetailPanel";
            UIName = "DetailPanel";
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _model = UIModel as DetailPanelModel;

            if(_model == null) return;
            
            // TODO: 根据model的值来显示不同的界面
            if (_model._isDetail)
            {
                UITool.HideGameObject("confirmBtn");
                
                UITool.AddClickEvent("workBtn", () =>
                {
                    GameObject newItem = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/ItemUI/TipItem"));
                    var tip = new UITipItemModel();
                    tip.tipText = "工作中...";
                    UIManager.PushUI(new UITipItem(), layer: UILayer.LAYER_TOP, tip);
                });
                
                UITool.AddClickEvent("feedBtn", () =>
                {
                    GameObject newItem = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/ItemUI/TipItem"));
                    var tip = new UITipItemModel();
                    tip.tipText = "投喂中...";
                    UIManager.PushUI(new UITipItem(), layer: UILayer.LAYER_TOP, tip);
                });
                UITool.AddClickEvent("interactBtn", () =>
                {
                    GameObject newItem = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/ItemUI/TipItem"));
                    var tip = new UITipItemModel();
                    tip.tipText = "互动中...";
                    UIManager.PushUI(new UITipItem(), layer: UILayer.LAYER_TOP, tip);
                });
            }
            else
            {
                UITool.AddClickEvent("confirmBtn", () =>
                {
                    GameManager.Instance.SceneSystem.SetScene(new MainScene());
                });
                
                UITool.HideGameObject("growType");
            }
            
            UITool.AddClickEvent("BtnExit", () =>
            {
                UIManager.PopUI();
                _model._isExit = true;
                OnExit();
            });
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
    
    public class DetailPanelModel : UIModelBase
    {
        public bool _isDetail = true;
    }

}