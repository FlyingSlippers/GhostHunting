using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public BattleManager battleManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            battleManager.StartBattle();
        }
    }
}