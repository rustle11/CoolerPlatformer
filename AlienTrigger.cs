using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlienTrigger : MonoBehaviour
{
    Transform playerBody;

    CharacterController contrl;

    public float speed = 5f;

    float gravityValue = -9.81f;

    bool isGrounded = false;

    float jumpHeight = 5f;

    [SerializeField] TextMeshProUGUI PointText;

    static float Point = 0f;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Transform>();
        contrl = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 2;
        float vertical = Input.GetAxis("Vertical");

        contrl.Move(playerBody.forward * vertical * speed * Time.deltaTime);

        playerBody.Rotate(0,mouseX,0);

        contrl.Move(playerBody.up * gravityValue * Time.deltaTime);

        if (Input.GetKeyDown("space") && isGrounded == true){
            contrl.Move(playerBody.up * jumpHeight);
        }

        isGrounded = false;
    }

    void OnControllerColliderHit(ControllerColliderHit col){
        if(col.gameObject.tag == "ground"){
            isGrounded = true;
        }

        if(col.gameObject.tag == "bad"){
            Destroy(col.gameObject);
            Point = Point + 0.5f;
            PointText.text = Point + "";
        }
    }

}