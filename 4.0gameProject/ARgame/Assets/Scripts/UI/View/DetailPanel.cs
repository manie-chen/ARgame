using SceneSys;

namespace UI
{
    public class DetailPanel :UIBase
    {
        private DetailPanelModel _model;
        private SceneSystem SceneSystem =  new SceneSystem();

        public DetailPanel()
        {
            _model = new DetailPanelModel();
            UIPath = "Prefabs/Panel/DetailPanel";
            UIName = "DetailPanel";
        }

        public override void OnEnter()
        {
            base.OnEnter();

            // TODO: 根据model的值来显示不同的界面
            if (_model._isDetail)
            {
                
            }
            else
            {
                
            }
            
            UITool.AddClickEvent("BtnExit", () =>
            {
                UIManager.PopUI();
                _model._isExit = true;
                OnExit();
            });
            
            UITool.AddClickEvent("confirmBtn", () =>
            {
                // UIManager.PopUI();
                // _model._isExit = false;
                //
                // OnExit();
                // TODO: 跳转到MainScene
                SceneSystem.SetScene(new MainScene());
            });
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
    
    public class DetailPanelModel : UIModelBase
    {
        public bool _isDetail = true;
    }

}