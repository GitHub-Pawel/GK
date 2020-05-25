using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public Player player;
    private Inventory inventory;
    private InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        //if (Input.GetButtonDown("Inventory"))
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Toggle Inventory");
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            if (inventoryUI.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                PlayerMovement movement = player.GetComponent<PlayerMovement>();
                movement.shouldIMove = false;
                Camera camera = Camera.main;
                MouseLook mouseLook = camera.GetComponent<MouseLook>();
                mouseLook.shouldILook = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                PlayerMovement movement = player.GetComponent<PlayerMovement>();
                movement.shouldIMove = true;
                Camera camera = Camera.main;
                MouseLook mouseLook = camera.GetComponent<MouseLook>();
                mouseLook.shouldILook = true;
            }
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
