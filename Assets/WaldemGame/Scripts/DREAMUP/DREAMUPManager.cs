using DG.Tweening;
using DREAMUP.UI;
using TMPro;
using UnityEngine;
using WaldemGame;
using WaldemGame.Managers;

namespace DREAMUP
{
    public class DREAMUPManager : AManager
    {
        [SerializeField]
        private PlayerController playerController;
        [SerializeField]
        private GameObject grid;
        [SerializeField]
        private GameObject items;
        [SerializeField]
        private GameObject npc;
        [SerializeField]
        private TextMeshProUGUI daysCounterText;
        private int daysCounter = 1;

        public override void Init()
        {
            if(!Inited)
            {
                grid.SetActive(true);
                items.SetActive(true);
                npc.SetActive(true);

                playerController.Init();
                SyncDayCounterText();

                if(daysCounterText.TryGetComponent<APanelView>(out APanelView daysPanel))
                {
                    daysPanel.ShowPanel(2);
                }
            }
        }

        public void Sleep()
        {
            var inputManager = App.GetManager<InputManager>();
            inputManager.DisableInput(InputTypes.All);

            var uiManager = App.GetManager<UIManager>();
            uiManager.HideGameScreen(()=>
            {
                daysCounter++;
                SyncDayCounterText();
                DOVirtual.DelayedCall(2, ()=>
                {
                    uiManager.ShowGameScreen();
                    inputManager.EnableInput(InputTypes.All);
                });
            });
        }

        private void SyncDayCounterText()
        {
            daysCounterText.text = $"Day {daysCounter}";
        }
    }
}