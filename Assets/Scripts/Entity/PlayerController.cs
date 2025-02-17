using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera _camera;
    [SerializeField] private float interactionRange = 1.5f;

    protected override void Start()
    {
        base.Start();
        _camera = Camera.main;   
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertial = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertial).normalized;

        if (Input.GetKeyDown(KeyCode.G))
        {
            TryInteract();
        }

    }

    private void TryInteract()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactionRange);
        foreach (Collider2D collider in hitColliders)
        {
            IInteractable interactable = collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact(); // 상호작용 실행
                break; // 한 개의 오브젝트만 상호작용
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }

}
