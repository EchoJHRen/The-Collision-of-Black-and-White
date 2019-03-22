using UnityEngine;

public enum HeroState
{
    //idle,
    //jump,
    faceLeft,
    faceRight
}

public class Hero : MonoBehaviour {

    public AudioSource shotSound;
    public AudioSource hitSound;

    public GameObject bullet;
    public Transform spawn;
    public float fireRate;
    private float nextFire;

    public int heroNum;
    public float moveSpeed;
    public float jumpForce;

    private bool isGround = true;
    private int groundLayerMask;

    private HeroState state;

    //显示血量
    public int hp = 8;
    private int hpShowFLag1 = 0;
    private int hpShowFLag2 = 0;
    public GameObject hpSpawn;
    public Sprite hp1;
    public Sprite hp2;
    public Sprite hp3;
    public Sprite hp4;
    public Sprite hp5;
    public Sprite hp6;
    public Sprite hp7;
    public Sprite hp8;

    public Sprite showHero;
    public Sprite blackHero;
    public Sprite whiteHero;

	// Use this for initialization
	void Start () {
        groundLayerMask = LayerMask.GetMask("Ground");

        //hero状态 1初始朝右,2初始朝左
        if (heroNum == 0)
            state = HeroState.faceRight;
        else
            state = HeroState.faceLeft;
    }
	
	// Update is called once per frame
	void Update () {
        //判断是否在地面上
        RaycastHit hit;
        isGround = Physics.Raycast(transform.position, Vector3.down, out hit, 0.4f, groundLayerMask);
        ShowHP();
    }

    void FixedUpdate(){
        HeroControl();
    }

    void HeroControl(){
        if (heroNum == 0)
        {
            if (Input.GetKey(KeyCode.W) && isGround)
            {
                GetComponent<Rigidbody>().velocity += new Vector3(0, 2, 0);
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime);
                if (state == HeroState.faceRight)
                {
                    state = HeroState.faceLeft;
                    spawn.Rotate(new Vector3(0, 180, 0));
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);
                if (state == HeroState.faceLeft)
                {
                    state = HeroState.faceRight;
                    spawn.Rotate(new Vector3(0, 180, 0));
                }
            }
            if (Input.GetKey(KeyCode.F) && Time.time >= nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject bullet_c = Instantiate(bullet, spawn.position, spawn.rotation) as GameObject;
                bullet_c.tag = "bullet1";
                shotSound.Play();
            }
            if (Input.GetKeyDown(KeyCode.G)) 
            {
                if (hpShowFLag1 % 2 == 0)
                {
                    Color c = hpSpawn.GetComponent<SpriteRenderer>().color;
                    c.a = 1;
                    hpSpawn.GetComponent<SpriteRenderer>().color = c;
                    GetComponent<SpriteRenderer>().sprite = showHero;
                }
                else if (hpShowFLag1 % 2 == 1)
                {
                    Color c = hpSpawn.GetComponent<SpriteRenderer>().color;
                    c.a = 0;
                    hpSpawn.GetComponent<SpriteRenderer>().color = c;
                    GetComponent<SpriteRenderer>().sprite = blackHero;
                }
                hpShowFLag1++;
            }
        }
        else if (heroNum == 1)
        {
            if (Input.GetKey(KeyCode.UpArrow) && isGround)
            {
                GetComponent<Rigidbody>().velocity += new Vector3(0, 2, 0);
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime);
                if (state == HeroState.faceRight)
                {
                    state = HeroState.faceLeft;
                    spawn.Rotate(new Vector3(0, 180, 0));
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);
                if (state == HeroState.faceLeft)
                {
                    state = HeroState.faceRight;
                    spawn.Rotate(new Vector3(0, 180, 0));
                }
            }
            if (Input.GetKey(KeyCode.Comma) && Time.time >= nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject bullet_c = Instantiate(bullet, spawn.position, spawn.rotation) as GameObject;
                bullet_c.tag = "bullet2";
                shotSound.Play();
            }
            if (Input.GetKeyDown(KeyCode.Period))
            {
                if (hpShowFLag2 % 2 == 0)
                {
                    Color c = hpSpawn.GetComponent<SpriteRenderer>().color;
                    c.a = 1;
                    hpSpawn.GetComponent<SpriteRenderer>().color = c;
                    GetComponent<SpriteRenderer>().sprite = showHero;
                }
                else if (hpShowFLag2 % 2 == 1)
                {
                    Color c = hpSpawn.GetComponent<SpriteRenderer>().color;
                    c.a = 0;
                    hpSpawn.GetComponent<SpriteRenderer>().color = c;
                    GetComponent<SpriteRenderer>().sprite = whiteHero;
                }
                hpShowFLag2++;
            }
        }
    }

    void ShowHP()
    {
        switch (hp)
        {
            case 8:
                hpSpawn.GetComponent<SpriteRenderer>().sprite = hp1;
                break;
            case 7:
                hpSpawn.GetComponent<SpriteRenderer>().sprite = hp2;
                break;
            case 6:
                hpSpawn.GetComponent<SpriteRenderer>().sprite = hp3;
                break;
            case 5:
                hpSpawn.GetComponent<SpriteRenderer>().sprite = hp4;
                break;
            case 4:
                hpSpawn.GetComponent<SpriteRenderer>().sprite = hp5;
                break;
            case 3:
                hpSpawn.GetComponent<SpriteRenderer>().sprite = hp6;
                break;
            case 2:
                hpSpawn.GetComponent<SpriteRenderer>().sprite = hp7;
                break;
            case 1:
                hpSpawn.GetComponent<SpriteRenderer>().sprite = hp8;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (heroNum == 0 && other.tag == "bullet2")
        {
            hitSound.Play();
        }
        if (heroNum == 1 && other.tag == "bullet1")
        {
            hitSound.Play();
        }
    }

}

