using System.Threading.Tasks;
using UnityEngine;
using WaldemGame.Abstract;

namespace WaldemGame.Managers
{
    public abstract class AManager : MonoBehaviour, IInitable
    {
        public bool Inited { get; set;}

        public virtual void Init()
        {
            
        }

        public Task AsyncInit()
        {
            return Task.Run(Init);
        }

        public void Reinit()
        {
            Inited = false;
            Init();
        }
    }
}