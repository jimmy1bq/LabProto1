using UnityEngine;

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
       
        Vector3 totalMovement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            totalMovement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.S))
        {
            totalMovement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            totalMovement += Vector3.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            totalMovement += Vector3.left;
        }
        gravity();
        controller.Move(totalMovement.normalized * playerSpeed * Time.deltaTime);
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
            case "Coins": PlayerInformationManager.playerStats[enums.playerStat.coins]++; UIManager.instance.updateCoinsText(); Destroy(other.gameObject); break;
            case "Void": GameManager.instance.gameOver(enums.loseMethod.falling); break;
        }
    }
}
