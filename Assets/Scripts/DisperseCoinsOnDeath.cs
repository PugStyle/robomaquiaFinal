using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Genetic;

[RequireComponent(typeof(HealthController))]
[RequireComponent(typeof(GeneticIndividual))]
public class DisperseCoinsOnDeath : MonoBehaviour
{

    [SerializeField]
    private Coin coin;

    private HealthController healthController;

    private GeneticIndividual geneticIndividual;

    private void Start() {
        geneticIndividual = GetComponent<CharacterGeneticIndividual>();
        healthController = GetComponent<HealthController>();
        healthController.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        healthController.OnDeath -= OnDeath;
        for (int i = 0; i < Mathf.Log(geneticIndividual.Fitness, 2); i++)
        {
            Coin c = Instantiate(coin, transform.position, Quaternion.identity);
            c.Rigidbody2D.AddForce(new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)).normalized * Random.Range(10, 350));
        }
    }

    private void OnDestroy() {
        healthController.OnDeath -= OnDeath;
    }

}
