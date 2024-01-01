namespace UI
{
    public class StartPanel : UIBase
    {
        public StartPanel()
        {
            UIPath = "Prefabs/Panel/ChoosePanel";
            UIName = "ChoosePanel";
        }

        public override void OnEnter()
        {
            base.OnEnter();
            // UITool.AddClickEvent("BtnSetting", () => UIManager.PushUI(new SettingPanel(), UILayer.TOP));
            // UITool.AddClickEvent("BtnStart", () => GameManager.Instance.SceneSystem.SetScene(new MainScene()));
        }
    }
}