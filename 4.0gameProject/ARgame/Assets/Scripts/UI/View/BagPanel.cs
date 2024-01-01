namespace UI
{
    public class BagPanel : UIBase
    {
        private BagPanelModel _model;
        public BagPanel()
        {
            _model = new BagPanelModel();
            UIPath = "Prefabs/Panel/BagPanel";
            UIName = "BagPanel";
        }

        public override void OnEnter()
        {
            UITool.AddClickEvent("exitBtn", () => UIManager.PopUI());
            base.OnEnter();
        }
    }
    
    public class BagPanelModel : UIModelBase
    {
        
    }
}