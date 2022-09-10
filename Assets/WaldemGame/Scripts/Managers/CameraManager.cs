using UnityEngine;
using WaldemGame.Abstract;

namespace WaldemGame.Managers
{    
    public class CameraManager : AManager, ILateUpdatable
    {
    #pragma warning disable 0649
        [SerializeField]
        private Camera mainCamera;
        [SerializeField]
        private Camera loadingCamera;
        [SerializeField]
        private bool followTarget = true;
        [SerializeField]
        private Transform target;
        [SerializeField]
        private float followSpeed;
    #pragma warning restore 0649

        public override void Init()
        {
            if(!Inited)
            {
                mainCamera.gameObject.SetActive(true);
                
                var gameManager = App.GetManager<GameManager>();

                gameManager.OnGameLateUpdate.RemoveListener(DoLateUpdate);
                gameManager.OnGameLateUpdate.AddListener(DoLateUpdate);
                Inited = true;
            }
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        public void DoLateUpdate(float deltaTime)
        {
            if(followTarget)
            {
                var newPos = mainCamera.transform.position;
                var cacheZ = newPos.z;
                newPos = Vector3.Lerp(newPos, target.position, Time.deltaTime * followSpeed);
                newPos.z = cacheZ;
                mainCamera.transform.position = newPos;
            }
        }
    }
}