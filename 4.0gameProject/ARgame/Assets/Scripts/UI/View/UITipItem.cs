namespace UI
{
    public class UITipItem : UIBase
    {
        private UITipItemModel _model;

        public UITipItem()
        {
            UIPath = "Prefabs/ItemUI/TipItem";
            UIName = "TipItem";
        }

        public override void OnEnter()
        {
            base.OnEnter();
            _model = UIModel as UITipItemModel;
            if(_model == null) return;
            UITool.BindText("Tip", UITool._nowPanel ,_model.tipText);
            
            UITool.AddClickEvent("BtnExit", () => UIManager.PopUI());
        }
    }
    
    public class UITipItemModel : UIModelBase
    {
        public string tipText { get; set; }
    }
}