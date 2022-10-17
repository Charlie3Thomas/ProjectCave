using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRandomizer : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private List<Transform> desiredDoors;

    private void Start()
    {
        if (door == null && desiredDoors == null)
            return;

        Transform desiredDoor = desiredDoors[Random.Range(0, desiredDoors.Count)];
        door.transform.rotation = desiredDoor.rotation;
        door.transform.position = desiredDoor.position;
    }
}
