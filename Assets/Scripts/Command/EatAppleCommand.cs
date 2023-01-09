using QFrame;
using UnityEngine;

public struct EatAppleCommand : ICommand
{
    public void Excute()
    {
        Object.FindObjectOfType<GameManager>().AppleCount++;
    }
}
