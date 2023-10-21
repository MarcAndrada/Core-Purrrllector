using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMinigameManager : MonoBehaviour
{
    [SerializeField]
    private float laserChargeSpeed;
    [SerializeField]
    private float laserDischargeSpeed;

    [ SerializeField]
    private Vector2 neededSizes;
    
    [SerializeField]
    private Color correctEnergyColor = Color.blue;
    [SerializeField]
    private Color wrongEnergyColor = Color.grey;

    [Space, Header("Left Laser"), SerializeField]
    private MinigameBarController leftLaser;
    private bool chargingLeftLaser;
    [Space, Header("Right Laser"), SerializeField]
    private MinigameBarController rightLaser;
    private bool chargingRightLaser;


    void Start()
    {
        leftLaser.SetCurrentEnergyLevel(50f);
        rightLaser.SetCurrentEnergyLevel(50f);

        GenerateRandomNeededEnergyLevels();
    }

    // Update is called once per frame
    void Update()
    {
        ManageInputs();
        SetLasersValue();
        CheckLasersEnergy();


        if (Input.GetKeyDown(KeyCode.M))
        {
            //Acabar de minar
        }
    }

    
    private void ManageInputs() 
    {
        chargingLeftLaser = Input.GetButton("Fire1");
        chargingRightLaser = Input.GetButton("Fire2");
    }

    private void SetLasersValue() 
    {
        ChangeCurrentLaser(leftLaser, chargingLeftLaser);
        ChangeCurrentLaser(rightLaser, chargingRightLaser);
    }
    private void ChangeCurrentLaser(MinigameBarController _currentLaser, bool _chargingCurrentLaser)
    {
        float currentEnergy = _currentLaser.GetCurrentEnergy();

        if (_chargingCurrentLaser)
        {
            currentEnergy += laserChargeSpeed * Time.deltaTime;
        }
        else
        {
            currentEnergy -= laserDischargeSpeed * Time.deltaTime;
        }
        currentEnergy = Mathf.Clamp(currentEnergy, 0, 100);
        _currentLaser.SetCurrentEnergyLevel(currentEnergy);

    }

    private void CheckLasersEnergy()
    {
        CheckCurrentLaserEnergy(leftLaser);   
        CheckCurrentLaserEnergy(rightLaser);   
    }

    private void CheckCurrentLaserEnergy(MinigameBarController _currentLaser)
    {
        float currentEnergy = _currentLaser.GetCurrentEnergy();
        float currentNeededEnergy = _currentLaser.GetNeedEnergy();
        float currentOffset = _currentLaser.GetEnergyOffset() / 2;

        if (currentEnergy >= currentNeededEnergy - currentOffset &&
            currentEnergy <= currentNeededEnergy + currentOffset)
        {
            //Tiene la energia necesaria
            _currentLaser.SetCurrentEnergyPointerColor(correctEnergyColor);
        }
        else
        {
            //No tiene la energia necesaria
            _currentLaser.SetCurrentEnergyPointerColor(wrongEnergyColor);
        }
    }

    private void GenerateRandomNeededEnergyLevels()
    {
        leftLaser.SetNeedEnergyLevel(Random.Range(10f, 90f), Random.Range(neededSizes.x, neededSizes.y));
        rightLaser.SetNeedEnergyLevel(Random.Range(10f, 90f), Random.Range(neededSizes.x, neededSizes.y));
    }


}
