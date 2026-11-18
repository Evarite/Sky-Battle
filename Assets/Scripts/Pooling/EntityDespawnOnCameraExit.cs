using UnityEngine;

namespace Lab.Enemies
{
    public class EntityDespawnOnCameraExit : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PooledEnemy>(out var enemy))
                enemy.Return();
        }
    }
}