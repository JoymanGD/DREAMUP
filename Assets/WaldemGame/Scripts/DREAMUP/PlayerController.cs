using System.Threading.Tasks;
using DG.Tweening;
using DREAMUP.Inventory;
using UnityEngine;
using WaldemGame;
using WaldemGame.Abstract;
using WaldemGame.Managers;

namespace DREAMUP
{
    public class PlayerController : MonoBehaviour, IInitable, IFixedUpdatable
    {
        [SerializeField]
        private float playerSpeed = 4;
        [SerializeField]
        private Rigidbody2D playerRigidbody;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private float toolUseDuration = .5f;

        private Transform playerTransform;
        private Vector2 movementVector;

        public bool Inited { get; set; }

        public void Init()
        {
            if(!Inited)
            {
                gameObject.SetActive(true);

                playerTransform = transform;

                var inputManager = App.GetManager<InputManager>();
                inputManager.OnAxisInputUpdate.RemoveListener(SetMovementVector);
                inputManager.OnAxisInputUpdate.AddListener(SetMovementVector);

                var gameManager = App.GetManager<GameManager>();
                gameManager.OnGameFixedUpdate.RemoveListener(DoFixedUpdate);
                gameManager.OnGameFixedUpdate.AddListener(DoFixedUpdate);

                var inventoryManager = App.GetManager<InventoryManager>();
                inventoryManager.OnItemSelected.RemoveListener(ItemSelectedHandler);
                inventoryManager.OnItemSelected.AddListener(ItemSelectedHandler);
                inventoryManager.OnToolUsed.RemoveListener(ToolUsedTrigger);
                inventoryManager.OnToolUsed.AddListener(ToolUsedTrigger);
            }
        }

        private void SetMovementVector(Vector2 movement)
        {
            movementVector = movement.normalized * playerSpeed;

            var movementSpeed = movementVector.sqrMagnitude;

            if(animator)
            {
                animator.SetFloat("Speed", movementSpeed);

                if(movementSpeed > 0) //dont let animator axes params reset to zero value
                {
                    animator.SetFloat("Horizontal", movementVector.x);
                    animator.SetFloat("Vertical", movementVector.y);
                }
            }
        }

        private void ToolUsedTrigger()
        {
            var inputManager = App.GetManager<InputManager>();
            inputManager.DisableInput(InputTypes.Keyboard);

            animator.SetTrigger("ToolTrigger");
            
            DOVirtual.DelayedCall(toolUseDuration, ()=>
            {
                inputManager.EnableInput(InputTypes.Keyboard);
            });
        }

        private void ItemSelectedHandler(int itemIndex)
        {
            animator.SetInteger("Tool", itemIndex+1);
        }

        public void DoFixedUpdate(float deltaTime)
        {
            if(playerRigidbody)
            {
                playerRigidbody.velocity = movementVector;
            }
        }

        public void Reinit()
        {
            Inited = false;
            Init();
        }

        public Task AsyncInit()
        {
            throw new System.NotImplementedException();
        }
    }
}