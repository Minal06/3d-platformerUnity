using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsScript : MonoBehaviour
{
    [Header("Visuals")]
    [SerializeField] private float vRotation;
    [SerializeField] private float vRange;
    [SerializeField] private float vSpeed;

    //public float vPower;
        
    private GameObject floatingObj;
    private float vAngle;

    private void Start()
    {
        floatingObj = transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        vAngle += vSpeed * Time.deltaTime;
                
        floatingObj.transform.localPosition = new Vector3(0, Mathf.Cos(vAngle) * vRange, 0);
    } 

}
