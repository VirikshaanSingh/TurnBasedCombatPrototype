using System.Collections;
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
    public CombatHud playerHud;
    public CombatHud enemyHud;
    public StatScript playerStats;
    public StatScript enemyStats;

    public CombatSystem combatState;

    private void Start()
    {
        combatState = CombatSystem.Start;
        StartCoroutine(CombatSetup());
    }

    IEnumerator CombatSetup()
    {
        GameObject playerGameObject = Instantiate(playerPrefab, playerSpawn);
        playerStats = playerGameObject.GetComponent<StatScript>();
        GameObject enemyGameObject = Instantiate(enemyPrefab, enemySpawn);
        enemyStats = enemyGameObject.GetComponent<StatScript>();
        trackerText.text = playerStats.entityName + " vs " + enemyStats.entityName;
        playerHud.SetCombatHUD(playerStats);
        enemyHud.SetCombatHUD(enemyStats);
        yield return new WaitForSeconds(2f);
        combatState = CombatSystem.PlayerTurn;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        trackerText.text = "Your Turn";
    }

}
