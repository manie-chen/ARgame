namespace UI
{
    public class SettingPanel:UIBase
    {
        public SettingPanel()
        {
            UIPath = "Prefabs/Panel/SettingPanel";
            UIName = "SettingPanel";
        }

        public override void OnEnter()
        {
            UITool.AddClickEvent("BtnExit", () => UIManager.PopUI());
        }
    }
}