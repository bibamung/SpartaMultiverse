using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact(); // ��ȣ�ۿ� �޼���
    void Interact(PlayerController player);
}
