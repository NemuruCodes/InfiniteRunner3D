using System.Collections;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    //public bool BossStart = false;
    public static bool isAlive { get; set; }
    bool Pickup = false;
    bool First = true;
    public Transform LeftAttackSpawn;
    public Transform MidAttackSpawn;
    public Transform RightAttackSpawn;

    //private Rigidbody rbAttacks;
    public float AttackSpeed;

    public GameObject WideAttackPrefab;
    public GameObject TallAttackPrefab;
    public GameObject LineAttackPrefab;
    public GameObject LineWarningAttackPrefab;
    public GameObject BulletPickUpPrefab;


    int BossPoints = 50;
    public PointManager pointManager = PointManager.Instance;

    void Start()
    {
        //Debug.Log("start");
        StartCoroutine(BossController());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(BossStart);
        //if (BossStart)
        //{
        //Debug.Log("start");
        //  StartCoroutine(BossController());
        //  BossStart = false;
        //}
       
        
    }

    IEnumerator BossController()
    {
        while (isAlive)
        {
            yield return StartCoroutine(RandomAttackAmount());
        }
        Defeated();
    }

    IEnumerator RandomAttackAmount()
    {
        while (true)
        {
            if (First)
            {
                yield return new WaitForSeconds(5f);
                First = false;
            }
            //Debug.Log("Time");
            yield return new WaitForSeconds(3f);

            // Randomly pick a number between 0 and 1
            int randomAmount = Random.Range(1, 4); // 1 or 2

            if (randomAmount == 1 && !Pickup)
            {
                // Debug.Log("Time2");
                RandomAttackType(1);
                Pickup = true;
            }
            else if (randomAmount == 2 && !Pickup)
            {
                //Debug.Log("Time3");
                RandomAttackType(2);
                Pickup = true;
            }
            else if (randomAmount == 3 && !Pickup)
            {
                //Debug.Log("Time4");
                RandomAttackType(3);
                Pickup = true;
            }

            else if (Pickup)
            {
                //Debug.Log("BulletPickUp");
                StartCoroutine(PickUp());
                yield return new WaitForSeconds(2f);
                Pickup = false;
            }
        }
        
    }

    void RandomAttackType(int Type)
    {
        if (Type == 1)
        {

            //Debug.Log("Wide");
            GameObject WideAttack = Instantiate(WideAttackPrefab, MidAttackSpawn.position, Quaternion.identity);

             //rbAttacks = GetComponent<Rigidbody>();
             //rbAttacks.linearVelocity = new Vector3(0, 0, -AttackSpeed);

            WideAttack.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -10), ForceMode.Impulse);// realised this is simplier
            Debug.Log("Wide2");



        }
        else if (Type == 2)
        {
            //Debug.Log("Type 2");
            int randomAttack = Random.Range(1, 4);

            switch (randomAttack)
            {
                case 1:
                    //Debug.Log("RanSwitch2,1");

                    int secondRandom = Random.Range(1, 3); 

                    if (secondRandom == 1)
                    {
                        StartCoroutine(LeftLane(1));
                        StartCoroutine(MidLane(1));
                    }
                    else if (secondRandom == 2)
                    {
                         StartCoroutine(LeftLane(1));
                        StartCoroutine(RightLane(1));
                    }

                    break;

                case 2:
                    //Debug.Log("RanSwitch2,2");

                    secondRandom = Random.Range(1, 3);

                    if (secondRandom == 1)
                    {
                         StartCoroutine(MidLane(1));
                        StartCoroutine(LeftLane(1));
                    }
                    else if (secondRandom == 2)
                    {
                         StartCoroutine(MidLane(1));
                        StartCoroutine(RightLane(1));
                    }

                    break;


                case 3:
                    //Debug.Log("RanSwitch2,3");

                    secondRandom = Random.Range(1, 3);

                    if (secondRandom == 1)
                    {
                        StartCoroutine(RightLane(1));
                        StartCoroutine(MidLane(1));
                    }
                    else if (secondRandom == 2)
                    {
                        StartCoroutine(RightLane(1));
                        StartCoroutine(LeftLane(1));
                    }

                    break;


            }
        }


        else if (Type == 3)
        {
            //Debug.Log("Type 3");
            int randomAttack = Random.Range(1, 4);

            switch (randomAttack)
            {
                case 1:
                    //Debug.Log("RanSwitch3,1");
                    //Debug.Log("Case 1 triggered");

                    int secondRandom = Random.Range(1, 3);

                    if (secondRandom == 1)
                    {
                         StartCoroutine(LeftLane(2));
                        StartCoroutine(MidLane(2));
                    }
                    else if (secondRandom == 2)
                    {
                         StartCoroutine(LeftLane(2));
                        StartCoroutine(RightLane(2));
                    }

                    break;

                case 2:
                    //Debug.Log("RanSwitch3,2");

                    secondRandom = Random.Range(1, 3);

                    if (secondRandom == 1)
                    {
                         StartCoroutine(MidLane(2));
                        StartCoroutine(LeftLane(2));
                    }
                    else if (secondRandom == 2)
                    {
                         StartCoroutine(MidLane(2));
                        StartCoroutine(RightLane(2));
                    }

                    break;


                case 3:
                    //Debug.Log("RanSwitch3,3");

                    secondRandom = Random.Range(1, 3);

                    if (secondRandom == 1)
                    {
                        StartCoroutine(RightLane(2));
                        StartCoroutine(MidLane(2));
                    }
                    else if (secondRandom == 2)
                    {
                        StartCoroutine(RightLane(2));
                        StartCoroutine(LeftLane(2));
                    }

                    break;


            }
        }



    }

    IEnumerator PickUp()
    {
        int random = Random.Range(1, 4);

        if (random == 1)
        {
            GameObject BulletPickup = Instantiate(BulletPickUpPrefab, LeftAttackSpawn.position, Quaternion.identity);
            BulletPickup.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -10), ForceMode.Impulse);
            yield return new WaitForSeconds(4f);
        }
        else if (random == 2)
        {
            GameObject BulletPickup = Instantiate(BulletPickUpPrefab, MidAttackSpawn.position, Quaternion.identity);
            BulletPickup.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -10), ForceMode.Impulse);
            yield return new WaitForSeconds(4f);
        }
        else if (random == 3)
        {
            GameObject BulletPickup = Instantiate(BulletPickUpPrefab, RightAttackSpawn.position, Quaternion.identity);
            BulletPickup.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -10), ForceMode.Impulse);
            yield return new WaitForSeconds(4f);
        }


    }

    IEnumerator LeftLane(int Type)
    {
        //Debug.Log("LeftLane");
        if (Type == 1)
        {
            Vector3 AttackSpawnL = LeftAttackSpawn.position + new Vector3(0, 0, -2);
            GameObject TallAttack = Instantiate(TallAttackPrefab, AttackSpawnL, Quaternion.identity);
            TallAttack.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -10), ForceMode.Impulse);
            yield return new WaitForSeconds(1f);
        }
        else if (Type == 2)
        {
            //Debug.Log("WarningLine");
            Vector3 AttackSpawnL = LeftAttackSpawn.position + new Vector3(0, 0, -20);
            GameObject LineWarningAttack = Instantiate(LineWarningAttackPrefab, AttackSpawnL, Quaternion.identity);
            LineWarningAttack.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 7.9f), ForceMode.Impulse);

            yield return new WaitForSeconds(2f);

           // Debug.Log("AttackLine");
            Vector3 AttackSpawnL2 = LeftAttackSpawn.position + new Vector3(0, 0, -20);
            GameObject LineAttack = Instantiate(LineAttackPrefab, AttackSpawnL2, Quaternion.identity);
            LineAttack.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 7.9f), ForceMode.Impulse);

            yield return new WaitForSeconds(10f);
        }
    }


    IEnumerator MidLane(int Type)
    {
        //Debug.Log("MidLane");
        if (Type == 1)
        {
            Vector3 AttackSpawnM = MidAttackSpawn.position + new Vector3(0, 0, -2);
            GameObject TallAttack = Instantiate(TallAttackPrefab, AttackSpawnM, Quaternion.identity);
            TallAttack.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -10), ForceMode.Impulse);
            yield return new WaitForSeconds(1f);
        }
        else if (Type == 2)
        {
           // Debug.Log("WarningLine");
            Vector3 AttackSpawnM = MidAttackSpawn.position + new Vector3(0, 0, -20);
            GameObject LineWarningAttack = Instantiate(LineWarningAttackPrefab, AttackSpawnM, Quaternion.identity);
            LineWarningAttack.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 7.9f), ForceMode.Impulse);

            yield return new WaitForSeconds(2f);

           // Debug.Log("AttackLine");
            Vector3 AttackSpawnM2 = MidAttackSpawn.position + new Vector3(0, 0, -20);
            GameObject LineAttack = Instantiate(LineAttackPrefab, AttackSpawnM2, Quaternion.identity);
            LineAttack.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 7.9f), ForceMode.Impulse);

            yield return new WaitForSeconds(10f);
        }
    }

    IEnumerator RightLane(int Type)
    {
       // Debug.Log("RightLane");
        if (Type == 1)
        {
            Vector3 AttackSpawnR = RightAttackSpawn.position + new Vector3(0, 0, -2);
            GameObject TallAttack = Instantiate(TallAttackPrefab, AttackSpawnR, Quaternion.identity);
            TallAttack.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -10), ForceMode.Impulse);
            yield return new WaitForSeconds(1f);
        }
        else if (Type == 2)
        {
            //Debug.Log("WarningLine");

            Vector3 AttackSpawnR = RightAttackSpawn.position + new Vector3(0, 0,-20);
            GameObject LineWarningAttack = Instantiate(LineWarningAttackPrefab, AttackSpawnR, Quaternion.identity);
            LineWarningAttack.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 7.9f), ForceMode.Impulse);

            yield return new WaitForSeconds(2f);

            //Debug.Log("AttackLine");
            Vector3 AttackSpawnR2 = RightAttackSpawn.position + new Vector3(0, 0, -20);
            GameObject LineAttack = Instantiate(LineAttackPrefab, AttackSpawnR2, Quaternion.identity);
            LineAttack.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 7.9f), ForceMode.Impulse);

            yield return new WaitForSeconds(10f);
        }
    }

    public void Defeated()
    {
        if (isAlive == false)
        {
            pointManager.value += BossPoints;
            pointManager.bossesDefeated++;
        }
       
    }
}