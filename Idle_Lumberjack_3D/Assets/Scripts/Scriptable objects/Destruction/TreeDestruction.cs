using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TreeDestruction",menuName = "Destruction/Create TreeDestruction")]
public class TreeDestruction : Destruction
{
    [SerializeField]ParticleSystem particles;
    [SerializeField] RandomAudioEvent audioEvent;
    public override IEnumerator DestructionSequenceCorutine(MonoBehaviour runner, float remainigHealthPercentage)
    {
        runner.transform.localScale *=remainigHealthPercentage;

        var basePosition = runner.transform.position;
        var baseScale = runner.transform.localScale;
        if (particles != null)
        {
            var particlesInstance = Instantiate(particles);
            particlesInstance.transform.position = basePosition;
            particlesInstance.transform.localScale = baseScale;
            particlesInstance.Play();
            Destroy(particlesInstance.gameObject, particles.main.duration);
        }

        yield break;    
    }
}
   

