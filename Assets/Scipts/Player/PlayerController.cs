using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject cursorUI;
    private Inventory inventory;
    private bool inventoryVisibility;

    void Awake()
    {
        inventoryUI.SetActive(false);
        cursorUI.SetActive(false);
    }

    void Start()
    {
        GameManager.GetInstance().GetInputs.actions["OpenInventory"].performed += ShowInventory;
        inventory = GetComponent<Inventory>();
    }

    public void ShowInventory(InputAction.CallbackContext context)
    {
        inventoryVisibility = !inventoryVisibility;
        inventoryUI.SetActive(inventoryVisibility);
        cursorUI.SetActive(inventoryVisibility);
    }

    public Inventory GetInventory
    {
        get { return inventory; }
    }

}
