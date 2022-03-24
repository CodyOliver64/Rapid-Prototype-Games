using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private XRRig player;
    private Vector3 spawn = new Vector3(-337.4f, 21.5f, -345.2f);
    private Vector3 beach = new Vector3(-312, 21.5f, 198);
    private Vector3 tree = new Vector3(59, 21.5f, -138);
    private Vector3 cliff = new Vector3(377.7f, 55.5f, -64.6f);
    private Vector3 overlook = new Vector3(222, 133.5f, 292);
    private Vector3 lake = new Vector3(435, 28, 473);
    public void OnActivate()
    {
        if (gameObject.name == "Spawn")
        {
            player.transform.position = tree;
        }
        else if (gameObject.name == "Beach")
        {
            player.transform.position = overlook;
        }
        else if (gameObject.name == "Tree")
        {
            player.transform.position = beach;
        }
        else if (gameObject.name == "Cliff")
        {
            player.transform.position = lake;
        }
        else if (gameObject.name == "Overlook")
        {
            player.transform.position = spawn;
        }
        else if (gameObject.name == "Lake")
        {
            player.transform.position = cliff;
        }
    }
}
