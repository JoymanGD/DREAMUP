using System.Threading.Tasks;

namespace WaldemGame.Abstract
{    
    public interface IInitable
    {
        bool Inited { get; set; }
        void Init();
        Task AsyncInit();
        void Reinit();
    }
}