using Assets.Game.Scripts.Models;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Systems.Managers
{
    public class ClientsManager : MonoBehaviour
    {
        private Transform pickupPoint;
        [SerializeField] private float distanceBetweenClients = 5f;

        private List<Client> clients = new List<Client>();

        public void Initialize(PointStorage points)
        {
            pickupPoint = points.pickupPoint;
        }

        public void AddClient(Client client)
        {
            clients.Add(client);
            UpdateQueue();
        }

        public Client GetFirstClient() => clients.Count > 0 ? clients[0] : null;

        public void RemoveFirstClient()
        {
            if (clients.Count > 0)
            {
                clients.RemoveAt(0);
                UpdateQueue();
            }
        }

        public void UpdateQueue()
        {
            for (int i = 0; i < clients.Count; i++)
            {
                var currentClient = clients[i];

                if (i == 0)
                {
                    currentClient.MoveTo(pickupPoint.position, currentClient.ShowPhone);
                    currentClient.ShowPhone();
                }
                else
                {
                    var clientInFront = clients[i - 1].transform;
                    var movePosition = clientInFront.forward * distanceBetweenClients;

                    currentClient.MoveTo(movePosition, null);
                }
            }
        }
    }
}
