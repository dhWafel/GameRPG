using UnityEngine;

public class PlayerController : MonoBehaviour{

    [SerializeField]
    private Rigidbody2D player;
    [SerializeField]
    private Animator walk;

    public Rigidbody2D getPlayerRB() 
    {
        return player;
    }

    private void Update(){
        walk.enabled = player.velocity.magnitude > 1f;
        if (Input.GetKey(KeyCode.D)){
            player.AddForce(transform.right * Game.Const.playerSpeed);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if (Input.GetKey(KeyCode.A)){
            player.AddForce(transform.right * -Game.Const.playerSpeed);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        if (Input.GetKey(KeyCode.W)){
            player.AddForce(transform.up * Game.Const.playerSpeed);
        }
        if (Input.GetKey(KeyCode.S)){
            player.AddForce(transform.up * -Game.Const.playerSpeed);
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            QuestController.Instance.AddQuest();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            QuestController.Instance.RemoveQuest();
        }


    }
}