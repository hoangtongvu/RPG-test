using UnityEngine;
using System;
using Core;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;

namespace Core.Animator
{
    public class BaseAnimator : SaiMonoBehaviour
    {
        [SerializeField] protected UnityEngine.Animator animator;
        [SerializeField] protected AnimationClip[] animationList;
        [SerializeField] protected string currentStateName;

        [SerializedDictionary("Anim name", "Clip")]
        [SerializeField] protected SerializedDictionary<string, AnimationClip> animList;


        #region LoadComponents

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadComponentInCtrl(ref this.animator);
            this.LoadAnimationClip();
        }

        protected virtual void LoadAnimationClip()
        {
            this.animationList = animator.runtimeAnimatorController.animationClips;
            foreach (AnimationClip clip in animationList)
            {
                this.animList.Add(clip.name, clip);
            }
        }

        #endregion LoadComponents

        public virtual void ChangeAnimationState<TEnum>(TEnum @newState) where TEnum : Enum
        {
            string newStateName = newState.ToString();
            if (currentStateName == newStateName) return;
            animator.Play(newStateName);
            currentStateName = newStateName;
        }


        public virtual float GetAnimationLength<TEnum>(TEnum @newState) where TEnum : Enum
        {
            string aniName = newState.ToString();
            foreach (AnimationClip clip in animationList)
            {
                if (clip.name == aniName)
                {
                    return clip.length;
                }
            }
            Debug.LogError($"{transform.parent.name} can't find animationClip with name: {aniName}");
            return 0;
        }



        public virtual void ChangeAnimationState(string newStateName)
        {
            if (currentStateName == newStateName) return;
            animator.Play(newStateName);
            currentStateName = newStateName;
        }

        public virtual float GetAnimationLength_Old(string aniName)
        {
            foreach (AnimationClip clip in animationList)
            {
                if (clip.name == aniName)
                {
                    return clip.length;
                }
            }
            Debug.LogError($"{transform.parent.name} can't find animationClip with name: {aniName}");
            return 0;
        }

        public virtual float GetAnimationLength(string aniName)
        {
            if (!this.animList.TryGetValue(aniName, out AnimationClip clip))
            {
                Debug.LogError($"Can't find animationClip in {transform.parent.name} with name: {aniName}", transform.parent.gameObject);
                return -1;
            }

            return clip.length;

        }

        public bool IsAnimatorPlaying()
        {
            return this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1 && !this.animator.IsInTransition(0);
        }

    }
}