using SceneSys;

namespace UI
{
    public class HallPanel : UIBase
    {
        private ChoosePanelModel _model;

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
                GameManager.Instance.SceneSystem.SetScene(new MapScene());
            });
        }
    }
    
    public class HallPanelModel : UIModelBase
    {
        
    }
}