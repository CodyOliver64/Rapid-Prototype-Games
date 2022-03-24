using UnityEngine;
using UnityEngine.Events;

public class Interactable1 : MonoBehaviour
{
    public float radius = 3f;

    public bool isInRange;
    public KeyCode getIceCreamKey;
    public UnityEvent iceCreamAction;



    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(getIceCreamKey))
            {
                iceCreamAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sophie")
        {
            isInRange = true;
            other.transform.GetChild(5).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Sophie")
        {
            isInRange = false;
            other.transform.GetChild(5).gameObject.SetActive(false);
        }
    }







}
