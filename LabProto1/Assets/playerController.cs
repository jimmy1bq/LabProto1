using UnityEngine;
using UnityEngine.Windows;

public class playerController : MonoBehaviour
{
    CharacterController controller;
    int playerSpeed = 10;
    Vector3 velocity = new Vector3(0, 0, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        TickSystem.frequenttickTime.AddListener(playerMovement);
    }

    void playerMovement(float time) 
    {
       //oops no switch case
        Vector3 totalMovement = Vector3.zero;
        if (UnityEngine.Input.GetKey(KeyCode.W))
        {
            totalMovement += Vector3.back;
        }
        if (UnityEngine.Input.GetKey(KeyCode.S))
        {
            totalMovement += Vector3.forward;
        }
        if (UnityEngine.Input.GetKey(KeyCode.A))
        {
            totalMovement += Vector3.right;
        }
        if (UnityEngine.Input.GetKey(KeyCode.D))
        {
            totalMovement += Vector3.left;
        }
        float horizontalInput = UnityEngine.Input.GetAxis("Mouse X");
        float verticalInput = UnityEngine.Input.GetAxis("Mouse Y");
        gameObject.transform.GetChild(0).transform.Rotate(new Vector3(-verticalInput, horizontalInput, 0));
        
        gravity();
        controller.Move(totalMovement.normalized * (playerSpeed+PlayerInformationManager.playerPowerUP[enums.powerUps.speed]) * Time.deltaTime);
    }
    void gravity() 
    {
        if (!controller.isGrounded)
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }     
    }

   
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Coins": PlayerInformationManager.playerStats[enums.playerStat.coins]+=1+PlayerInformationManager.playerPowerUP[enums.powerUps.extraMoneyEarned]; UIManager.instance.updateCoinsText(); Destroy(other.gameObject); break;
            case "Finish": GameManager.instance.gameOver(enums.loseMethod.win); break;
            case "Void": GameManager.instance.gameOver(enums.loseMethod.falling); break;
        }
    }
}
