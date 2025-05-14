using System.Collections;
using UnityEngine;

public class BossManager : MonoBehaviour
{

    bool isAlive = true;
    public Transform LeftAttackSpawn;
    public Transform MidAttackSpawn;
    public Transform RightAttackSpawn;

    public GameObject WideAttackPrefab;

    void Start()
    {
        BossControler();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BossControler()
    {
        while (isAlive)
        {
            StartCoroutine(RandomAttackAmount());

        }
    }

    IEnumerator RandomAttackAmount()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            // Randomly pick a number between 0 and 1
            int randomAmount = Random.Range(1, 3); // 1 or 2

            if (randomAmount == 1)
            {
                RandomAttackType(1);
            }
        }

    }

    void RandomAttackType(int Amount)
    {
        if (Amount == 1)
        {
            int randomAttack = Random.Range(1, 4);

            if (randomAttack == 1)
            {
                GameObject WideAttack = Instantiate(WideAttackPrefab, LeftAttackSpawn.position, Quaternion.identity);
            }
            
        }

        

    }
}