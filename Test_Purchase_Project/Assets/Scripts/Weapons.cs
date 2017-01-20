using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {

    private int firePower;
    private int fireRate;

    public Weapons(int firePower, int fireRate)
    {
        firePower = 1;
        fireRate = 1;
    }

    public int FirePower
    {
        get { return firePower; }
        set { firePower = value; }
    }

    public int FireRate
    {
        get { return fireRate; }
        set { fireRate = value; }
    }

    Weapons machineGun = new Weapons(1, 4);
}
