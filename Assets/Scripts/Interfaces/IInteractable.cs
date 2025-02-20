using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact(); // 상호작용 메서드
    void Interact(PlayerController player);
}
