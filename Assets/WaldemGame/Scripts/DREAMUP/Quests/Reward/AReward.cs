using UnityEngine;

namespace DREAMUP.Reward
{
    public abstract class AReward : ScriptableObject
    {
        public abstract void ReleaseReward();
    }
}