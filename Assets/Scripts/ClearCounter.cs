using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KitchenObject kitchenObject;

    private void Update()
    {
        if (testing && Keyboard.current.tKey.isPressed)
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetClearCounter(secondClearCounter);
            }
        }   
    }
    public void Interact()
   {
        if (kitchenObjectsSO != null)
        {
            
            Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.prefabs, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
            
        }else
        {
            Debug.Log(kitchenObject.GetClearCounter());
        }
   }


   public Transform GetKitchenObjectFollowTransform() {
        return counterTopPoint;
   }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject; 
    }

    public KitchenObject GetKitchenObject() { return kitchenObject; }

    public void ClearKitchenObject() { kitchenObject = null; }

    public bool HasKitchenObject() { return kitchenObject  != null; }

}
