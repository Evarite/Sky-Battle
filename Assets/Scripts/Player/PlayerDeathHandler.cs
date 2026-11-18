using Lab.HealthSystem;
using UnityEngine;

namespace Lab.Player
{
    public class PlayerDeathHandler : BaseDeathHandler
    {
        [SerializeField] private ParticleSystem _deathEffectPrefab;

        protected override void Die()
        {
            var deathEffect = Instantiate(_deathEffectPrefab, transform.position,
                _deathEffectPrefab.transform.rotation);
            deathEffect.Play();

            gameObject.SetActive(false);
        }
    }
}
