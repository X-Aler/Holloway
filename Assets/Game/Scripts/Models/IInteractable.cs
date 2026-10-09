using UnityEngine;

public interface IInteractable
{
    Transform UIPosition { get; }
    void Interact();
}
