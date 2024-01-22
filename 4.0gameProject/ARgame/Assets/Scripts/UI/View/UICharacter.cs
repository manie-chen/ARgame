using UnityEngine;

namespace UI
{
    public class UICharacterModel : UIModelBase
    {
        public int ID { get; set; }
        public string Name {get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        
        public UICharacterModel()
        {
            
        }
    }
}