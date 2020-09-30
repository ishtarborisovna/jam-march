using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Covid covid;
    private int XPos;
    private int YPos;
    private float rateCovid = 1f;
    private GameObject[] enemis;

    public Grecha grecha;
    private int Xgrecha;
    private int Ygrecha;
    private float rateGrecha = 8f;
    private GameObject[] bullets;

    public Paper paper;
    private int Xpaper;
    private int Ypaper;
    private float ratePaper = 4f;
    private GameObject[] papers;

    public CovidCorona corona;
    private int Xcorona;
    private int Ycorona;
    private float rateCorona = 5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        rateCovid -= Time.deltaTime;
        rateGrecha -= Time.deltaTime;
        ratePaper -= Time.deltaTime;
        rateCorona -= Time.deltaTime;

        enemis = GameObject.FindGameObjectsWithTag("covid");
        bullets = GameObject.FindGameObjectsWithTag("grecha");
        papers = GameObject.FindGameObjectsWithTag("paper");

        if (rateCovid <= 0f && enemis.Length < 8) SpawnCovid();
        if (rateGrecha <= 0f && bullets.Length < 4) SpawnGrecha();
        if (ratePaper <= 0f && bullets.Length < 4) SpawnPaper();
        if (rateCorona <= 0f) SpawnCorona();
    }

    void SpawnCovid()
    {
            XPos = Random.Range(-8, 8);
            if (XPos == -8 || XPos == -8) YPos = Random.Range(-5, 5);
            else 
            { 
                YPos = Random.Range(4, 5);
                if (YPos == 4) YPos = -5;
            }
            Vector3 spawnPos = transform.position + new Vector3(XPos, YPos, 0);
            Instantiate(covid, spawnPos, Quaternion.identity);
        if (timer < 50) rateCovid = 5f;
        else if (timer >= 50 && timer < 100) rateCovid = 4f;
        else if (timer >= 150 && timer < 200) rateCovid = 3f;
        else if (timer >= 250) rateCovid = 3.5f;
    }

    void SpawnCorona()
    {
        Xcorona = Random.Range(-8, 8);
        if (Xcorona == -8 || Xcorona == -8) Ycorona = Random.Range(-5, 5);
        else
        {
            Ycorona = Random.Range(4, 5);
            if (Ycorona == 4) Ycorona = -5;
        }
        Vector3 spawnPos = transform.position + new Vector3(Xcorona, Xcorona, 0);
        Instantiate(corona, spawnPos, Quaternion.identity);
        rateCorona = 6f;
    }

    void SpawnGrecha()
    {
        Xgrecha = Random.Range(-7, 7);
        Ygrecha = Random.Range(-4, 4);
        Vector3 spawnPos = transform.position + new Vector3(Xgrecha, Ygrecha, 0);
        Instantiate(grecha, spawnPos, Quaternion.identity);
        rateGrecha = 8f;
    }

    void SpawnPaper()
    {
        Xpaper = Random.Range(-7, 7);
        Ypaper = Random.Range(-4, 4);
        Vector3 spawnPos = transform.position + new Vector3(Xpaper, Ypaper, 0);
        Instantiate(paper, spawnPos, Quaternion.identity);
        ratePaper = 10f;
    }
}
