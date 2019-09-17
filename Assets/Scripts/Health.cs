using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public Image healthBar;

    //Takes an amount of damage based on projectile damage
    public void GetDamaged(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / maxHealth;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
