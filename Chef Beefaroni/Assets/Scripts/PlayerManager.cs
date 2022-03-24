using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerManager : MonoBehaviour
{

    [Header("Manager Stuff")]
    public GameManager gameManager;
    public static PlayerManager playerManager;

    [Header("Current Stats")]
    public float currentSpeed;
    public float currentHealth;
    public float distanceTravelled;

    [Header("Speed")]
    public float startSpeed;
    public float maxSpeed;
    public float leftRightSpeed;
    public float speedIncreaseRate;

    [Header("Health")]
    public float startHealth;
    public float maxHealth;

    [Header("Misc Shit")]
    public bool RoundActive;
    public GameObject CanModel;
    public float rotationSpeed;

    [Header("UI")]
    public TextMeshProUGUI DistanceText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI SpecialAbilityText;
    public TextMeshProUGUI SpecialAbilityUsesText;

    private Rigidbody rb;
    private bool holdingLeft;
    private bool holdingRight;
    public UpgradeManager upgradeManager;

    [Header("Upgrade Stuff")]
    public GameObject actualCanModel;
    public Material[] metalMATS;
    public Material[] labelMATs;

    private bool isInTimeSlow = false;

    public int ability = 0; //0 = jump, 1 = shoot, 2 = timestop
    public int abilityUses = 3;

    public Transform bulletSpawnLocation;
    public GameObject bulletPrefab;
    public GameObject bulletParent;
    public AudioSource splatNoise;

    private void Awake()
    {
        if (playerManager == null)
        {
            playerManager = this;
        }
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        gameManager = GameManager.gameManager;

        upgradeManager = GameObject.Find("UpgradeSystem(Clone)").GetComponent<UpgradeManager>();
        
        var canmesh = actualCanModel.GetComponent<MeshFilter>();
        canmesh.mesh = upgradeManager.models[upgradeManager.currentModel];

        var canMats = actualCanModel.GetComponent<MeshRenderer>().materials;
        canMats[0] = metalMATS[upgradeManager.currentMetal];
        canMats[1] = labelMATs[upgradeManager.currentLabel];

        actualCanModel.GetComponent<MeshRenderer>().materials = canMats;

        //Actually assign new values here

        maxHealth = upgradeManager.maxHealth;
        startHealth = maxHealth;
        HealthText.text = $"Health: {startHealth}";

        maxSpeed = upgradeManager.maxSpeed;

        ability = upgradeManager.ability;
        switch (ability)
        {
            case 0:
                SpecialAbilityText.text = "Jump";
                break;
            case 1:
                SpecialAbilityText.text = "Shoot";
                break;
            case 2:
                SpecialAbilityText.text = "Time Slow";
                break;
        }
    }

    void Update()
    {
        if (RoundActive)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);

            if(!isInTimeSlow && currentSpeed < maxSpeed)
            {
                currentSpeed += speedIncreaseRate * Time.deltaTime;
            }

            //Change these to tilt controls eventually 
            if (Input.GetKey(KeyCode.A) || holdingLeft)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }

            if (Input.GetKey(KeyCode.D) || holdingRight)
            {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }

            if (Input.GetKeyDown(KeyCode.Space)) SpecialAbility();

            RotateCan();
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            CalculateDistance();
        }
    }

    public void RoundStart()
    {
        currentHealth = startHealth;
        currentSpeed = startSpeed;

        RoundActive = true;
    }

    public void LoseHealth()
    {
        currentHealth -= 1;
        HealthText.text = $"Health: {currentHealth}";
        if (currentHealth <= 0)
        {
            //Die
            //Fix this to incluude UI
            upgradeManager.currentMoney += (int)distanceTravelled;
            gameManager.SceneReset();

        }
    }

    public void RotateCan()
    {
        CanModel.transform.Rotate(new Vector3(rotationSpeed, 0, 0) * currentSpeed * Time.deltaTime);
    }

    public void CalculateDistance()
    {

        distanceTravelled += currentSpeed/2 * Time.deltaTime;
        int distanceRounded = Mathf.RoundToInt(distanceTravelled);
        DistanceText.text = $"Distance Travelled: {distanceRounded}m";
    }

    public void MoveLeft()
    {
        holdingLeft = true;
    }

    public void MoveRight()
    {
        holdingRight = true;
    }

    public void DontMoveLeft()
    {
        holdingLeft = false;
    }

    public void DontMoveRight()
    {
        holdingRight = false;
    }

    public void Jump()
    {
        rb.AddForce(new Vector3(0, 7.5f, 0), ForceMode.Impulse);
    }

    public IEnumerator TimeSlow()
    {
        isInTimeSlow = true;
        var tempSpeedVar = currentSpeed;

        currentSpeed = currentSpeed / 2;
        yield return new WaitForSeconds(3);
        currentSpeed = tempSpeedVar;
        isInTimeSlow = false;
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnLocation);
        bullet.transform.SetParent(bulletParent.transform);
        splatNoise.Play();
    }

    public void SpecialAbility()
    {
        if(abilityUses > 0)
        {
            switch (ability)
            {
                case 0:
                    Jump();
                    break;
                case 1:
                    Shoot();
                    break;
                case 2:
                    StartCoroutine(TimeSlow());
                    break;
            }

            abilityUses--;
            SpecialAbilityUsesText.text = abilityUses.ToString();
        }

    }
}
