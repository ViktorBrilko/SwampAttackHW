using UnityEngine;

public class Shotgun : Weapon
{
    private void Update()
    {
        _lastShootTime += Time.deltaTime;
    }

    public override void Shoot(Transform shootPoint)
    {
        Debug.Log("1");
        if (_lastShootTime >= _delay)
        {
            Debug.Log("2");
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            _lastShootTime = 0;
        }
    }
}