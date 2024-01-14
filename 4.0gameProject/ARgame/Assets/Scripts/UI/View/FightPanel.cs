using SceneSys;

namespace UI
{
    public class FightPanel : UIBase
    {
        private FightPanelModel _model;
        public FightPanel()
        {
            _model = new FightPanelModel();
            UIPath = "Prefabs/Panel/FightPanel";
            UIName = "FightPanel";
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
            UITool.AddClickEvent( "BtnExit", () => GameManager.Instance.SceneSystem.SetScene(new MapScene()));
        }
        
    }
    
    public class FightPanelModel : UIModelBase
    {
        
    }
}