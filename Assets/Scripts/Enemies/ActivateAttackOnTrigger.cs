using UnityEngine;

namespace Lab.Enemies
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class ActivateAttackOnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<EnemyAttack>(out var attack))
                attack.enabled = true;
        }
    }
}