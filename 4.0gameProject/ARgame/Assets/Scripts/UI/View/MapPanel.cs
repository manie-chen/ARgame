namespace UI
{
    public class MapPanel : UIBase
    {
        private MapPanelModel _model;
        public MapPanel()
        {
            _model = new MapPanelModel();
            UIPath = "Prefabs/Panel/MapPanel";
            UIName = "MapPanel";
        }

        public override void OnEnter()
        {
            base.OnEnter();
            UITool.AddClickEvent("BtnExit", () => UIManager.PopUI());
        }
    }

    
    public class MapPanelModel : UIModelBase
    {
        
    }
}