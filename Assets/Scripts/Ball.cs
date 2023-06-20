using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
    public float speed = 5;
    public float oldSpeed = 5;

    private float rotateSpeed;
    private Vector2 dir;
    private float startDirection;
    private float degrees = 0.0f;

    public JerseyDatabase ballDB;
    public SpriteRenderer sr;

    public Image leftBonusShootPlaceholder;
    public Image leftMalusShootPlaceholder;
    public Image leftBonusFreezePlaceholder;

    public Image rightBonusShootPlaceholder;
    public Image rightMalusShootPlaceholder;
    public Image rightBonusFreezePlaceholder;

    public Sprite BonusShootDisable;
    public Sprite MalusShootDisable;
    public Sprite BonusFreezeDisable;

    public GameObject LeftBonusShootActive;
    public GameObject LeftMalusShootActive;
    public GameObject LeftBonusFreezeActive;
    public GameObject RightBonusShootActive;
    public GameObject RightMalusShootActive;
    public GameObject RightBonusFreezeActive;

    private LeftInventoryManager leftinventoryManager;
    private RightInventoryManager rightinventoryManager;
    private int selectedBall = 0;

    void Start()
    {
        Vector2 randomDir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        GetComponent<Rigidbody2D>().velocity = randomDir * speed;
        leftinventoryManager = GetComponent<LeftInventoryManager>();
        rightinventoryManager = GetComponent<RightInventoryManager>();

        if (!PlayerPrefs.HasKey("SelectedBall")) {
            selectedBall = 0;
        } else {
            Load();
        }
        UpdateBall(selectedBall);
    }

    private void UpdateBall(int selectedBall)
    {
        Jersey ball = ballDB.GetJersey(selectedBall);
        sr.sprite = ball.jerseySprite;
    }

    private void Load()
    {
        selectedBall = PlayerPrefs.GetInt("SelectedBall");
    }

    void Update()
    {
        if (speed >= rotateSpeed)
            rotateSpeed = speed;
        if (GetComponent<Rigidbody2D>().velocity.x >= 0)
            degrees -= rotateSpeed;
        else
            degrees += rotateSpeed;
        transform.eulerAngles = Vector3.forward * degrees;
    }
    
    float hitFactor (Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight; 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "LeftPlayer" || col.gameObject.name == "RightPlayer")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            if (col.gameObject.name == "LeftPlayer")
                dir = new Vector2(1, y).normalized;
            else
                dir = new Vector2(-1, y).normalized;

            if (speed < 4 || speed > 16) {
                speed = oldSpeed;
            }
            
            if (speed < 15.0f)
                speed += 0.25f;

            if ((LeftBonusShootActive.activeSelf == true && col.gameObject.name == "LeftPlayer") || (RightBonusShootActive.activeSelf == true && col.gameObject.name == "RightPlayer")) {
                oldSpeed = speed;
                speed = 17;
            } else if ((LeftMalusShootActive.activeSelf == true && col.gameObject.name == "RightPlayer") || (RightMalusShootActive.activeSelf == true && col.gameObject.name == "LeftPlayer")) {
                oldSpeed = speed;
                speed = 3;
            }
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            if (LeftBonusFreezeActive.activeSelf == true) {
                LeftBonusFreezeActive.SetActive(false);
                rightBonusFreezePlaceholder.sprite = BonusFreezeDisable;
            }
            
            if (RightBonusFreezeActive.activeSelf == true) {
                RightBonusFreezeActive.SetActive(false);
                leftBonusFreezePlaceholder.sprite = BonusFreezeDisable;
            }
        }

        if (col.gameObject.name == "LeftPlayer") {
            if (LeftBonusShootActive.activeSelf == true) {
                LeftBonusShootActive.SetActive(false);
                leftBonusShootPlaceholder.sprite = BonusShootDisable;
            }
            
            if (RightMalusShootActive.activeSelf == true) {
                RightMalusShootActive.SetActive(false);
                leftMalusShootPlaceholder.sprite = MalusShootDisable;
            }
        }

        if (col.gameObject.name == "RightPlayer") {
            if (RightBonusShootActive.activeSelf == true) {
                RightBonusShootActive.SetActive(false);
                rightBonusShootPlaceholder.sprite = BonusShootDisable;
            }
            
            if (LeftMalusShootActive.activeSelf == true) {
                LeftMalusShootActive.SetActive(false);
                rightMalusShootPlaceholder.sprite = MalusShootDisable;
            }
        }
    }

    public void resetBall()
    {
        speed = 5.0f;
        this.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        Vector2 randomDir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        GetComponent<Rigidbody2D>().velocity = randomDir * speed;
    }

}