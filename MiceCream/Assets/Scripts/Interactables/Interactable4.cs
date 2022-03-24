using UnityEngine;
using UnityEngine.Events;

public class Interactable4 : MonoBehaviour
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
        if (other.gameObject.name == "Patrick")
        {
            isInRange = true;
            other.transform.GetChild(4).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Patrick")
        {
            isInRange = false;
            other.transform.GetChild(4).gameObject.SetActive(false);
        }
    }







}
