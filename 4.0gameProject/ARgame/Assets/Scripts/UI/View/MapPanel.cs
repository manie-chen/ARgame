using SceneSys;

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
            UITool.AddClickEvent("BtnExit", () => GameManager.Instance.SceneSystem.SetScene(new MainScene()));
            UITool.AddClickEvent("PVPBtn",() => GameManager.Instance.SceneSystem.SetScene(new FightScene()));
            UITool.AddClickEvent("PVEBtn",() => GameManager.Instance.SceneSystem.SetScene(new FightScene()));
        }
    }

    
    public class MapPanelModel : UIModelBase
    {
        
    }
}