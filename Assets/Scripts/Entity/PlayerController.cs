using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera _camera;
    [SerializeField] private float interactionRange = 1.5f;

    public bool isPlayed = false;

    Rigidbody2D rigidbody;
    Vector3 dirVec;
    UIManager uIManager;
    GameManager gameManager;

    GameObject scanObject;

    protected override void Awake()
    {
        base.Awake();
        rigidbody = GetComponent<Rigidbody2D>();
        gameManager = GameManager.instance;
    }

    protected override void Start()
    {
        base.Start();
        if (PlayerPrefs.HasKey("PlayerPosX"))
        {
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY");
            float z = PlayerPrefs.GetFloat("PlayerPosZ");
            PlayerPrefs.DeleteKey("PlayerPosX");
            PlayerPrefs.DeleteKey("PlayerPosY");
            PlayerPrefs.DeleteKey("PlayerPosZ");

            transform.position = new Vector3(x, y, z);
        }
        else
        {
            base.Start();
        }
        _camera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = GameManager.instance.isAction ? 0f : Input.GetAxisRaw("Horizontal");
        float vertial = GameManager.instance.isAction ? 0f : Input.GetAxisRaw("Vertical");
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
