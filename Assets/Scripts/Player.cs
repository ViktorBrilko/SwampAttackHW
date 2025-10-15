using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private List<GameObject> _weapons;
    [SerializeField] private GameObject _startWeaponPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _weaponPoint;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber;
    private int _currentHealth;
    private Animator _animator;

    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        GameObject startWeapon = Instantiate(_startWeaponPrefab, _weaponPoint.position, Quaternion.identity, transform);
        ChangeWeapon(startWeapon.GetComponent<Weapon>());
        _weapons.Add(startWeapon);

        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        GameObject newWeapon = Instantiate(weapon.WeaponPrefab, _weaponPoint.position, Quaternion.identity, transform);
        newWeapon.SetActive(false);
        _weapons.Add(newWeapon);
    }

    public void NextWeapon()
    {  
        _weapons[_currentWeaponNumber].SetActive(false);
        
        if (_currentWeaponNumber == _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon(_weapons[_currentWeaponNumber].GetComponent<Weapon>());
        _weapons[_currentWeaponNumber].SetActive(true);
    }

    public void PreviousWeapon()
    {
        _weapons[_currentWeaponNumber].SetActive(false);
        
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _weapons.Count - 1;
        else
            _currentWeaponNumber--;

        ChangeWeapon(_weapons[_currentWeaponNumber].GetComponent<Weapon>());
        _weapons[_currentWeaponNumber].SetActive(true);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}