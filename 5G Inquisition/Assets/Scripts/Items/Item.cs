using UnityEngine;

[CreateAssetMenu(fileName = "New Item Config", menuName = "Inventory/Item Config")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        //Use the item
        
        Debug.Log("USING "+name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
