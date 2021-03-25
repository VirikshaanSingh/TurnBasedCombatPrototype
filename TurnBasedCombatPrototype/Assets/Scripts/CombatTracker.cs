using UnityEngine;
using UnityEngine.UI;

public enum CombatSystem { Start, PlayerTurn, EnemyTurn, Win, Lose }
public class CombatTracker : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerSpawn;
    public Transform enemySpawn;
    public Text trackerText;
    StatScript playerStats;
    StatScript enemyStats;

    public CombatSystem combatState;

    private void Start()
    {
        combatState = CombatSystem.Start;
        CombatSetup();
    }

    void CombatSetup()
    {
        GameObject playerGameObject = Instantiate(playerPrefab, playerSpawn);
        playerStats = playerGameObject.GetComponent<StatScript>();
        GameObject enemyGameObject = Instantiate(enemyPrefab, enemySpawn);
        enemyStats = enemyGameObject.GetComponent<StatScript>();
        trackerText.text = playerStats.entityName + " vs " + enemyStats.entityName;
    }

}
