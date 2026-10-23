using UnityEngine;

public interface ICommand
{
    void Start();
    void Update();
    bool IsCompleted { get; set; }
}
