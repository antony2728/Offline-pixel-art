using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaPlayer : MonoBehaviour
{
    public int health;
    public int maxHealt;

    PlayerController playerController;
    [SerializeField] Transform uiBarHealth;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        RefresBar();
    }

    void RefresBar()
    {
        float healthBar = (float)health / (float)maxHealt;
        uiBarHealth.localScale = Vector3.Lerp(uiBarHealth.localScale, new Vector3(healthBar, 1, 1), Time.deltaTime * 9f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hurt"))
        {
            health -= collision.GetComponent<Damage>().daño;
            playerController.myAnim.SetTrigger("Hit");
        }
    }
}
