using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ChoosePanel : UIBase
    {
        private ChoosePanelModel _model;
        private string content;
        
        public ChoosePanel()
        {
            _model = new ChoosePanelModel();
            UIPath = "Prefabs/Panel/ChoosePanel";
            UIName = "ChoosePanel";
        }

        public override void OnEnter()
        {
            _model._characterCount = 5;
            content = "Content";
            while (_model._characterCount-- > 0)
            {
                GameObject newItem = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Character/UICharacter"));
                UITool.AddChildItem<UICharacterModel>(content, newItem);
                // _model._characterModels.Add(new UICharacterModel());
            }
            UITool.AddClickEvent(content, () =>
            {
                OnPause();
                var detailPanelModel = new DetailPanelModel();
                detailPanelModel._isDetail = false;
                var panel = UIManager.PushUI(new DetailPanel(), layer: UILayer.TOP, detailPanelModel) as DetailPanel;
                // if(panel != null && panel._model._isExit)
                //     OnResume();
                
            });
        }
        
        public override void OnPause()
        {
            base.OnPause();
            
            UITool.HideGameObject("ChoosePanel(Clone)");
        }
        
        public override void OnResume()
        {
            base.OnResume();
            UITool.ShowGameObject("ChoosePanel(Clone)");
        }
        
        
    }
    
    public class ChoosePanelModel : UIModelBase
    {
        public List<UICharacterModel> _characterModels = new List<UICharacterModel>();
        public int _characterCount { get; set; }
        
    }
}