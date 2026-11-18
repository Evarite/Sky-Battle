namespace Lab.Pooling
{
    public class PooledParticleEffect : PooledEntity
    {
        private void OnParticleSystemStopped() => Return();
    }
}