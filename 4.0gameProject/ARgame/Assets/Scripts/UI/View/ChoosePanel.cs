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
            }
            UITool.AddClickEvent(content, () =>
            {
                var detailPanelModel = new DetailPanelModel();
                detailPanelModel._isDetail = false;
                var panel = UIManager.PushUI(new DetailPanel(), layer: UILayer.TOP, detailPanelModel) as DetailPanel;
            });
        }
    }
    
    public class ChoosePanelModel : UIModelBase
    {
        public List<UICharacterModel> _characterModels = new List<UICharacterModel>();
        public int _characterCount { get; set; }
        
    }
}