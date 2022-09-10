using System.Collections;
using System.Collections.Generic;
using DREAMUP.UI;
using UnityEngine;
using WaldemGame;

namespace DREAMUP.Economics
{
    public class ResourcesPanelView : APanelView
    {
        [SerializeField]
        private Transform elementsContainer;
        [SerializeField]
        private ResourcesPanelElementView resourcesPanelElementPrefab;

        private List<ResourcesPanelElementView> currentResourcesElements = new List<ResourcesPanelElementView>();

        public void SyncResourcesView(List<ResourceData> resources)
        {
                    
            var economicsManager = App.GetManager<EconomicsManager>();

            if(currentResourcesElements.Count == resources.Count)
            {
                for (int i = 0; i < currentResourcesElements.Count; i++)
                {
                    var element = currentResourcesElements[i];
                    var resource = resources[i];
                    var icon = economicsManager.GetResourceIcon(resource.Type);

                    element.Set(icon, resource.Amount);
                }

                return;
            }
            else
            {
                TurnAllElements(false);

                for (int i = 0; i < resources.Count; i++)
                {
                    if(currentResourcesElements.Count <= i)
                    {
                        var newPanelElementView = Instantiate(resourcesPanelElementPrefab, elementsContainer);
                        currentResourcesElements.Add(newPanelElementView);
                    }

                    var element = currentResourcesElements[i];
                    var resource = resources[i];
                    var icon = economicsManager.GetResourceIcon(resource.Type);

                    element.Set(icon, resource.Amount);

                    element.Enable(true);
                }
            }
        }

        private void TurnAllElements(bool value)
        {
            foreach (var item in currentResourcesElements)
            {
                item.Enable(value);
            }
        }
    }
}