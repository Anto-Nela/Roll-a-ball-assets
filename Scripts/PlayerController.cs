using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int count=0;
    public Text countText; 
    public Text winText;
    public Text wintxt2;
    public LayerMask groundlayers;
    public float jumpforce = 5f;
    public SphereCollider col;

    void Start() {
        rb=GetComponent<Rigidbody>();
        count=0;
        countText.text = "Count: 0";
        winText.text="";
        wintxt2.text = "";
        col = GetComponent<SphereCollider>();
    }
    /* is called before rendering a game, its where most of the game code will go
     void Update(){}
    */

    //is called just before performing any physics calculations, its where the physics code will go
    void FixedUpdate(){

        float moveHorizontal =Input.GetAxis("Horizontal");
        float moveVertical= Input.GetAxis("Vertical");
        
        Vector3 movement= new Vector3(moveHorizontal,0,moveVertical);

        rb.AddForce(movement*speed);

        if (isGrounded() && Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up*jumpforce, ForceMode.Impulse);

        }
    }
    void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag("Pick Up")){
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText(){
        countText.text="Count: "+ count.ToString();
        if(count>=12){
            winText.text="You Win!";
        
            if (count>=24) {
            wintxt2.text ="You won the game! Click the player to exit.";
            }
        
        }
    }

    private bool isGrounded() {

       return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y,col.bounds.center.z), col.radius * .9f, groundlayers);

    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("GameOver");
    }
}
