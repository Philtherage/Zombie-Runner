using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    [SerializeField] GameObject damageCanvas;
    [SerializeField] float canvasFadeTime = 1f;

    private void Start()
    {
        damageCanvas.SetActive(false);
    }

    public void DealDamageToPlayer(int damage)
    {
        FindObjectOfType<PlayerHealth>().PlayerTakeDamage(damage);
        StartCoroutine(DisplayDamage());
    }

    IEnumerator DisplayDamage()
    {
        damageCanvas.SetActive(true);
        yield return new WaitForSeconds(canvasFadeTime);
        damageCanvas.SetActive(false);
    }

}
