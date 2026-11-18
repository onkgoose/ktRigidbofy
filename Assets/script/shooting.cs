using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce = 15f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            // Направление от точки спавна пули до клика
            Vector2 direction = (mousePos - transform.position).normalized;

            // Спавним пулю в точке префаба (позиция объекта, на котором висит скрипт)
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Поворачиваем пулю по направлению полёта
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            // Запускаем пулю
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * bulletForce;
        }
    }
}
