using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(TrapVisibility))]
public class TrapDamage : MonoBehaviour
{
    // Enum
    private enum TrapState { Active, Inactive };

    // SerializeField
    [SerializeField] private TrapState state = TrapState.Active;
    [SerializeField] private float trapDamage = 10.0f;

    // Manager
    private GameManager manager;

    void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void Start()
    {
        manager = GameManager.GetInstance();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.isTrigger)
            {
                return;
            }
            if (state == TrapState.Active)
            {
                manager.PlaySound("Degat");
                manager.GetPlayerController.GetHealthControl.RemoveHealth(trapDamage);
                GetComponent<TrapVisibility>().ChangeVisibility();
                state = TrapState.Inactive;
            }
        }
    }
}
