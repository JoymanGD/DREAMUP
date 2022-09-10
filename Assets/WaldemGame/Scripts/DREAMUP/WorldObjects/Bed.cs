using DREAMUP.Inventory;
using UnityEngine;
using WaldemGame;
using WaldemGame.Managers;

namespace DREAMUP
{
    public class Bed : UsableObject
    {
        protected override void UsableAction()
        {
            var dreamUpManager = App.GetManager<DREAMUPManager>();
            dreamUpManager.Sleep();
        }
    }    
}