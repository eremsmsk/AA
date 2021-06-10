using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject topPrefab;
    int ToplamTopSayisi;
    List<Rigidbody2D> tumToplar = new List<Rigidbody2D>();

    float hiz = 20f;
    float ilkTopunYPozisyonu = -3f;

    [SerializeField] Text level_txt;

    int level;
    UI ui;
    private void Start()
    {
        ui = GameObject.FindObjectOfType<UI>();
        levelKontrol();

        ilkToplariEkle();
    }

    void levelKontrol()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
        else
        {
            level = 1;
            PlayerPrefs.SetInt("level", level);
        }

        level_txt.text = level.ToString();
    }

    void ilkToplariEkle()
    {
        ToplamTopSayisi = level * 3;

        for (int i = 0; i < ToplamTopSayisi; i++)
        {
            GameObject yeniTop = Instantiate(topPrefab);

            if (i == 0)
            {
                yeniTop.transform.position = new Vector2(0, ilkTopunYPozisyonu);
            }
            else
            {
                yeniTop.transform.position = new Vector2(0, tumToplar[i - 1].transform.position.y - (tumToplar[i - 1].GetComponent<CircleCollider2D>().bounds.size.y * 1.5f));

            }

            yeniTop.GetComponentInChildren<TextMeshProUGUI>().text = (ToplamTopSayisi - i).ToString();
            tumToplar.Add(yeniTop.GetComponent<Rigidbody2D>());
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && tumToplar.Count > 0)
        {
            tumToplar[0].velocity = Vector2.up * hiz;

            tumToplar.RemoveAt(0);

        }
        else if (tumToplar.Count <= 0)
        {
            Kazandin();
        }
    }

    public void ToplarinPozisyonlariniGuncelle()
    {
        for (int i = 0; i < tumToplar.Count; i++)
        {
            if (i == 0)
            {
                tumToplar[i].transform.position = new Vector2(0, ilkTopunYPozisyonu);
            }
            else
            {
                tumToplar[i].transform.position = new Vector2(0, tumToplar[i - 1].transform.position.y - (tumToplar[i - 1].GetComponent<CircleCollider2D>().bounds.size.y * 1.5f));

            }
        }
    }

    public void Kazandin()
    {
        ui.pnlTB_Goster();
        this.enabled = false;
    }

    public void Kaybettin()
    {
        ui.pnlGameOver_Goster();
        this.enabled = false;
    }
}
