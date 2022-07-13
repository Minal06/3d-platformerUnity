using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Character setup")]
    private CharacterController characterController;    
    private PowerUpsScript powerUpsScript;


    [Header("Reset Setup")]
    public Vector3 resetPos;
    [SerializeField] Vector3 checkpointPos;

    [Header("Powerups Respawn")]
    [SerializeField] float respawnTime;
   

    [Header("Jump Star Setup")]
    [SerializeField] Vector3 moveDirection;        
    [SerializeField] float dashSpeed;
    [SerializeField] float dashTime;

    [Header("Dash Star Setup")]
    [SerializeField] Vector3 moveDirectionR;
    [SerializeField] float dashSpeedR;
    [SerializeField] float dashTimeR;



    private void Start()
    {        
        characterController = GetComponent<CharacterController>();        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Deathzone":                
                ResetPos();
                break;

            case "JumpStar":
                other.gameObject.SetActive(false);
                StartCoroutine(DashUp());
                StartCoroutine(Respawn(other, respawnTime));                
                Debug.Log("should jump high");
                break;

            case "DashStar":
                other.gameObject.SetActive(false);
                StartCoroutine(DashRight());
                StartCoroutine(Respawn(other, respawnTime));
                Debug.Log("should jump right");
                break;

            case "Checkpoint":
                resetPos = checkpointPos;
                //Debug.Log("checkpoint powinien zmieniæ resetPos");
                Debug.Log(resetPos);
                break;

            case null:
                break;
        }
            

        
        //if (other.CompareTag("JumpStar"))
        //{
        //    StartCoroutine(DashUp());            
        //    Debug.Log("should jump high");
        //}

        //else if (other.CompareTag("Deadzone"))
        //{
            
        //}
    }
   
    void ResetPos()
    {
        Debug.Log("DEAD!");
        transform.position = resetPos;
        characterController.Move(default);
        
    }        
    

    IEnumerator DashUp()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            characterController.Move(moveDirection * dashSpeed * Time.deltaTime);            

            yield return null;
        }
    }
    IEnumerator DashRight()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTimeR)
        {
            characterController.Move(moveDirectionR * dashSpeedR * Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator Respawn(Collider other, float time)
    { 
        yield return new WaitForSeconds(time);        
        other.gameObject.SetActive(true);

    }
    
}
