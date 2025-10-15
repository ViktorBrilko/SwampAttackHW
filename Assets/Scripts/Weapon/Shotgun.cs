using UnityEngine;

public class Shotgun : Weapon
{
    private void Update()
    {
        _lastShootTime += Time.deltaTime;
    }

    public override void Shoot(Transform shootPoint)
    {
        if (_lastShootTime >= _delay)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            _lastShootTime = 0;
        }
    }
}