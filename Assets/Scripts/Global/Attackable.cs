using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    public int attackValue = 0;
    public HealthComponent healthComponent = null;

    protected virtual void Awake()
    {
        healthComponent = GetComponentInChildren<HealthComponent>();
        if (healthComponent == null)
            Debug.LogError("Health Component not found");
    }

    public void TakeDamage(int value)
    {
        healthComponent.TakeDamage(value);
    }

    public void Shake(float duration = 0.1f, float magnitude = 4f)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    protected virtual void HandleDeath() { }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = orignalPosition + new Vector3(x, y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;


        if (healthComponent.IsDead())
            HandleDeath();
    }
}
