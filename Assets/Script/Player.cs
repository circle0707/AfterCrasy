using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody ri;
    [SerializeField] Camera cam;

     public float PlayerHP;
    [SerializeField] float PlayerSpeed;
    [SerializeField] float LookGamdo;
    [SerializeField] float CamLimit;
    [SerializeField] float currentCamRotationX;

    public float bandong;

    bool canDash = true;
    bool canJump = true;
    bool JumpRay;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//커서잠그기
        Cursor.visible = false;//커서숨기기
        ri = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        panByeol_HP();
        move();
        SandeJump();
        CamRotation();//상하 카메라 회전
        CharRotation();//좌우 캐릭터 회전
        GameManager.instance.currentHP = PlayerHP;
    }
    private void FixedUpdate()
    {
        
    }

    void move()
    {
        float Move = Input.GetAxisRaw("Vertical");
        Vector3 vel = transform.forward * Input.GetAxisRaw("Vertical") * PlayerSpeed * -1;
        vel.y = ri.velocity.y;//점프 막힘 우회
        ri.velocity = vel;
        //transform.position += transform.forward * Input.GetAxisRaw("Vertical") * PlayerSpeed * Time.deltaTime *-1;
        

    }
    void CamRotation()
    {
        float camRotationX = (Input.GetAxisRaw("Mouse Y") * LookGamdo +bandong) *Time.deltaTime; // 카메라 로테션 구하기
        currentCamRotationX -= camRotationX; // 현재에 더하다.
        currentCamRotationX = Mathf.Clamp(currentCamRotationX, -CamLimit, CamLimit); // 가두리
        cam.transform.localEulerAngles = new Vector3(currentCamRotationX, 180,0);//대입
    }
    void CharRotation()
    {
        float yRotation = Input.GetAxisRaw("Mouse X") * LookGamdo*Time.deltaTime; // y로테션 구하기
        Vector3 charRotationY = new Vector3(0, yRotation, 0);
        transform.rotation *= Quaternion.Euler(charRotationY);
        //ri.MoveRotation(ri.rotation * Quaternion.Euler(charRotationY));
        
    }

    //산데비스탄, 점프
    void SandeJump()
    {
        JumpRay = Physics.Raycast(ri.position, Vector3.down, 10, LayerMask.GetMask("Platform"));
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
        {
            PlayerSpeed = 100;
            canDash = false;
            Invoke("after3s", 3f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            ri.AddForce(Vector3.up * 40, ForceMode.Impulse);
            canJump = false;
            Invoke("Down", 0.5f);
        }
        //땅 인식
        if(JumpRay == true)
        {
            canJump = true;
        }
        if (JumpRay == false)
        {
            canJump = false;
        }
    }
    void after3s()
    {
        PlayerSpeed = 23;
        Invoke("after5s", 5f);
    }
    void after5s()
    {
        canDash = true;
    }
    void Down()
    {
        ri.AddForce(Vector3.down * 10, ForceMode.VelocityChange);
    }

    //HP관련
    void panByeol_HP()
    {
        if (PlayerHP <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    //닿았을때
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemySBull")
        {
            print("EnemySBull");
            PlayerHP -= 100;
        }
        if (collision.gameObject.tag == "EnemyGBull")
        {
            print(collision.gameObject.name);
            PlayerHP -= 300;
        }
    }

}
    