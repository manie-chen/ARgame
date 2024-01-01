using UnityEngine;

namespace UI
{
    public class UICharacter : UIBase
    {
        public UICharacter()
        {
            UIPath = "Prefabs/Character/UICharacter";
            UIName = "UICharacter";
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
            UITool.AddClickEvent("icon", () => UIManager.PushUI(new DetailPanel(), UILayer.TOP));
        }
    }
    
    public class UICharacterModel : UIModelBase
    {
        private int ID { get; set; }
        private string Name {get; set; }
        private string Description { get; set; }
        private string Icon { get; set; }
        
        
        public UICharacterModel()
        {
            
        }
    }
}