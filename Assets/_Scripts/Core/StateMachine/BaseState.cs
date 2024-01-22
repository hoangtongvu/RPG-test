using Core;
using System;
using UnityEngine;

namespace Core.StateMachine
{
    public abstract class BaseState : SaiMonoBehaviour
    {
        [Header("Base State")]
        [SerializeField] protected StateMachine SM;

        [SerializeField] protected bool isRootState = false;
        [SerializeField] protected BaseState currentSuperState;
        [SerializeField] protected BaseState currentSubState;

        public BaseState CurrentSubState => currentSubState;


        public virtual void ResetState()
        {
            Reset();
        }


        public virtual void StateInit(StateMachine stateMachine)
        {
            SM = stateMachine;
        }


        public abstract void StateOnEnter();
        public abstract void StateUpdate();
        public abstract void StateFixedUpdate();
        public abstract void StateOnExit();



        // States LOOP
        public void FixedUpdateStates()
        {
            this.StateFixedUpdate();
            if (currentSubState != null) currentSubState.FixedUpdateStates();
        }

        public void UpdateStates()
        {
            StateUpdate();
            if (currentSubState != null) currentSubState.UpdateStates();
        }
        protected abstract void CheckSwitchState();//todo change return type to bool


        //Super State
        protected virtual void SetSuperState<TEnum>(TEnum @enum) where TEnum : Enum
        {
            currentSuperState = GetStateByEnum(@enum);
        }
        protected virtual void SetSuperState(BaseState newSuperState)
        {
            currentSuperState = newSuperState;
        }

        protected virtual void SetSuperState(string newSuperStateName)//NEW
        {
            currentSuperState = GetStateByName(newSuperStateName);
        }


        //Sub State
        protected abstract void InitSubState();
        protected virtual void SetSubState<TEnum>(TEnum @enum) where TEnum : Enum
        {
            currentSubState = GetStateByEnum(@enum);
            currentSubState.SetSuperState(this);
        }

        protected virtual void SetSubState(string newSubStateName)//NEW
        {
            currentSubState = GetStateByName(newSubStateName);
            currentSubState.SetSuperState(this);
        }



        //ELSE
        protected virtual void SwitchState<TEnum>(TEnum newStateEnum) where TEnum : Enum
        {
            if (isRootState)
            {
                SM.SwitchState(newStateEnum.ToString());
            }
            else if (currentSuperState != null)
            {
                StateOnExit();
                BaseState newState = GetStateByEnum(newStateEnum);
                newState.StateOnEnter();
                currentSuperState.SetSubState(newStateEnum);

            }
        }

        protected virtual void SwitchState(string newStateName)//NEW
        {
            if (isRootState)
            {
                SM.SwitchState(newStateName);
            }
            else if (currentSuperState != null)
            {
                StateOnExit();
                BaseState newState = GetStateByName(newStateName);
                newState.StateOnEnter();
                currentSuperState.SetSubState(newStateName);

            }
        }

        protected virtual BaseState GetStateByEnum<TEnum>(TEnum @enum) where TEnum : Enum
        {
            return SM.GetStateByName(@enum.ToString());
        }

        protected virtual BaseState GetStateByName(string stateName)
        {
            return SM.GetStateByName(stateName);
        }

        public virtual string GetName()
        {
            return gameObject.name;
        }


        public abstract void HandleAnimation();

    }
}