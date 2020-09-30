using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 ClickPos;
    private Vector3 deltaNorm;

    public int grechaNumber;
    public GameObject GrechaObject;
    Text textGrecha;

    public int paperNumber;
    public GameObject PaperObject;
    Text textPaper;

    public static int coronaKillNumber;
    public GameObject CoronaKillObject;
    Text textCoronaKill;

    public Bullet bullet;
    public GameObject DeathWindow;

    SpriteRenderer m_SpriteRenderer;

    void Awake()
    {
        textGrecha = GrechaObject.GetComponent<Text>();
        textPaper = PaperObject.GetComponent<Text>();
        textCoronaKill = CoronaKillObject.GetComponent<Text>();
        m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        paperNumber = 5;
        grechaNumber = 5;
        textPaper.text = paperNumber.ToString();
        textGrecha.text = grechaNumber.ToString();
    }

    void Update()
    {
        Move();
        if (Input.GetMouseButtonUp(1) && grechaNumber > 0) Shoot();
        textCoronaKill.text = coronaKillNumber.ToString();
        if (paperNumber < 1) Die();
    }

    void Move()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rayHit = Physics2D.Raycast(ray, Vector2.zero);
            if (rayHit.transform != null)
            {
                ClickPos = new Vector3(rayHit.point.x, rayHit.point.y, 0);
                deltaNorm = ClickPos - transform.position;
                deltaNorm.Normalize();
            }
        }
        transform.up = deltaNorm;
        transform.position += deltaNorm * speed * Time.deltaTime;

    }

    public void Shoot()
    {
        grechaNumber--;
        textGrecha.text = grechaNumber.ToString();
        Vector3 position = transform.position;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        newBullet.Direction = transform.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "paper")
        {
            paperNumber++;
            textPaper.text = paperNumber.ToString();
            Destroy(collision.gameObject);
            Debug.Log("Paper = " + paperNumber);
        }

        if (collision.tag == "grecha")
        {
            grechaNumber += 5;
            textGrecha.text = grechaNumber.ToString();
            Destroy(collision.gameObject);
            Debug.Log("Grecha = " + grechaNumber);
        }

        if (collision.tag == "covid")
        {
            paperNumber--;
            textPaper.text = paperNumber.ToString();
            Debug.Log("Paper = " + paperNumber);
            StartCoroutine(ChangeColor());
        }
    }

    IEnumerator ChangeColor()
    {
        m_SpriteRenderer.color = new Color32(255, 83, 83, 255);
        yield return new WaitForSeconds(0.2f);
        m_SpriteRenderer.color = new Color32(255, 255, 255, 255);
    }

    private void Die()
    {
        Time.timeScale = 0;
        DeathWindow.SetActive(true);
    }

}
