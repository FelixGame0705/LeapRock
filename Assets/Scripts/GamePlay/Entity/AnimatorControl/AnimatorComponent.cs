using UnityEngine;
namespace Entity
{ 
    internal abstract class AnimatorComponent : EntityComponent
    {
        [SerializeField] protected Animator _animator;

        public virtual void PlayAnimator(IPlayAnimation playAnimation)
        {
            playAnimation.PlayAnimation(_animator);
        }
    }
}
