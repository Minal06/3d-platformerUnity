using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorsScript : MonoBehaviour
{
    [SerializeField] GameObject _door;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            _door.transform.position = new Vector3(_door.transform.position.x, _door.transform.position.y + 3, _door.transform.position.z);
        }
    }
}
