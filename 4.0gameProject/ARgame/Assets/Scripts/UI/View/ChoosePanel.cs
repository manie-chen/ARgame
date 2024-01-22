using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ChoosePanel : UIBase
    {
        private ChoosePanelModel _model;
        
        public ChoosePanel()
        {
            _model = new ChoosePanelModel();
            UIPath = "Prefabs/Panel/ChoosePanel";
            UIName = "ChoosePanel";
        }

        public override void OnEnter()
        {
            _model._characterCount = 5;
            while (_model._characterCount-- > 0)
            {
                GameObject newItem = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/ItemUI/Character/UICharacter"));
                UITool.AddChildItem("Content", newItem);
                // 填充数据
                UITool.BindText("Name", newItem, "dog");
                UITool.AddClickEvent(newItem.name, () =>
                {
                    Debug.Log("1111");
                    var detailPanelModel = new DetailPanelModel();
                    detailPanelModel._isDetail = false;
                    var panel = UIManager.PushUI(new DetailPanel(), layer: UILayer.LAYER_TOP, detailPanelModel) as DetailPanel;
                }, newItem);
            }
        }
    }
    
    public class ChoosePanelModel : UIModelBase
    {
        public List<UICharacterModel> _characterModels = new List<UICharacterModel>();
        public int _characterCount { get; set; }
        
    }
}