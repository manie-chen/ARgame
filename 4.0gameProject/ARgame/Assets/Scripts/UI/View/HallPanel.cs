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
            UITool.AddClickEvent("UICharacter", () =>
            {
                var detailPanelModel = new DetailPanelModel();
                detailPanelModel._isDetail = true;
                var panel = UIManager.PushUI(new DetailPanel(), layer: UILayer.LAYER_TOP, detailPanelModel) as DetailPanel;
            });
        }
    }
    
    public class HallPanelModel : UIModelBase
    {
        
    }
}