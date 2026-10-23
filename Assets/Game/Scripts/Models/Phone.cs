using UnityEngine;

namespace Assets.Game.Scripts.Models
{
    public class Phone : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform uiPosition;
        public Transform UIPosition => uiPosition;

        public void Interact()
        {
            var code = Random.Range(000000, 999999);
            Debug.Log($"Код: {code}");
        }
    }
}