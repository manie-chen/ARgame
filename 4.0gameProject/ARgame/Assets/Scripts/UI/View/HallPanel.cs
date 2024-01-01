using SceneSys;

namespace UI
{
    public class HallPanel : UIBase
    {
        private ChoosePanelModel _model;
        private SceneSystem SceneSystem =  new SceneSystem();

        public HallPanel()
        {
            _model = new ChoosePanelModel();
            UIPath = "Prefabs/Panel/HallPanel";
            UIName = "HallPanel";
        }

        public override void OnEnter()
        {
            base.OnEnter();
            UITool.AddClickEvent("BagButton", () => UIManager.PushUI(new BagPanel()));
            UITool.AddClickEvent("MapButton", () =>
            {
                SceneSystem.SetScene(new MapScene());
            });
        }
    }
    
    public class HallPanelModel : UIModelBase
    {
        
    }
}