using System.Collections;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public Vector2 turn;
    public float jumpspeed;
    public float BoostSpeed;
    public float movespeed = 10f;
    public float rotatespeed = 75f;
    public gamebehavior gameManager;

    public float distancetoground = 0.1f;
    public LayerMask groundlayer;

    public float vinput;
    public float hinput;
    public bool get;
    public bool set;
    public int _jetpack = 0;

    public GameObject bullet;
    public float bulletspeed = 100f;

    public float jumpvelocity = 30f;
    public float boostspeed = 30f;

    private float yspeed;
    public float IsGrounded;
    private CapsuleCollider _col;
    private Rigidbody _rb;

    public Transform enemy;

    public gamebehavior _gameManager;

    public delegate void JumpingEvent();
    public event JumpingEvent playerJump;
    private pausemenu _pauseMenu;

    public AudioClip bulletFireAudioClip; // Assign this in the Unity Editor
    private AudioSource _audioSource;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>(); // Get the existing AudioSource
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _col = GetComponent<CapsuleCollider>();

        _pauseMenu = GameObject.FindObjectOfType<pausemenu>();
        _gameManager = GameObject.Find("GameManager").GetComponent<gamebehavior>();

        enemy = GameObject.Find("Enemy").transform;
        enemy = GameObject.Find("Enemy (1)").transform;
        enemy = GameObject.Find("Enemy (2)").transform;
    }

    void fixedUpdate()
    {
        Vector3 rotation = Vector3.up * hinput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * vinput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpvelocity, ForceMode.Impulse);
            playerJump?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the game is paused
        if (_pauseMenu != null && _pauseMenu.isPaused)
        {
            return; // Skip the rest of the Update logic if paused
        }

        // Existing movement and shooting logic
        vinput = Input.GetAxis("Vertical") * movespeed;
        hinput = Input.GetAxis("Horizontal") * movespeed;

        this.transform.Translate(Vector3.forward * vinput * Time.deltaTime);
        this.transform.Translate(Vector3.right * hinput * Time.deltaTime);

        turn.x += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        if (_jetpack >= 1)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                this.transform.Translate(Vector3.forward * BoostSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                _rb.AddForce(Vector3.up * jumpvelocity, ForceMode.Impulse);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject newBullet = Instantiate(bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation) as GameObject;
        Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();
        BulletRB.velocity = this.transform.forward * bulletspeed;

        // Play the bullet firing sound
        if (bulletFireAudioClip != null)
        {
            _audioSource.PlayOneShot(bulletFireAudioClip);
        }
    }

    public int jetpack
    {
        get { return _jetpack; }
        set
        {
            _jetpack = value;
            Debug.LogFormat("Jetpack: {0}", _jetpack);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.name == "Enemy")
        //{
        //_gameManager.HP -= 1;
        //}
    }
}
