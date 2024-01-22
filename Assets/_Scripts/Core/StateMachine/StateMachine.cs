using Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.StateMachine
{
    public abstract class StateMachine : SaiMonoBehaviour
    {

        [SerializeField] protected string currentStateName;

        [SerializeField] protected BaseState currentState;

        [SerializeField] protected Transform statesHolder;

        [SerializeField] protected List<BaseState> stateList = new List<BaseState>();

        public List<BaseState> StateList => stateList;

        protected virtual void Start()
        {
            //this.SwitchState("Idle");
            this.SetDefaultState();
        }

        private void SetDefaultState()
        {
            this.SwitchState(this.GetDefaultState());
        }

        protected abstract BaseState GetDefaultState();

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadStateHolder();
            this.LoadStateList();
        }


        protected virtual void LoadStateHolder()
        {
            this.statesHolder = transform.Find("StateHolder");
        }


        protected virtual void LoadStateList()
        {
            foreach (Transform state in statesHolder)
            {
                if (!state.TryGetComponent(out BaseState baseState)) continue;
                this.stateList.Add(baseState);
                baseState.StateInit(this);
            }
        }





        protected virtual void FixedUpdate()
        {
            if (this.CheckNullState()) return;
            this.currentState.FixedUpdateStates();

        }

        protected virtual void Update()
        {
            if (this.CheckNullState()) return;
            this.currentState.UpdateStates();
        }


        public virtual void SwitchState(string stateName)
        {
            BaseState newState = this.stateList.Find(state => state.gameObject.activeSelf && state.gameObject.name == stateName);
            if (newState == null)
            {
                Debug.LogError(stateName + " is Null State", this.gameObject);
                return;
            }

            this.SwitchState(newState);

            //Get State Name
            //loop through state holder
            //If name of gameObj == State name => do that state

        }

        public virtual void SwitchState(BaseState newState)
        {
            if (this.currentState != null) this.currentState.StateOnExit();
            this.currentState = newState;
            this.currentStateName = this.currentState.gameObject.name;
            this.currentState.StateOnEnter();
        }

        public virtual BaseState GetStateByName(string stateName)
        {
            BaseState newState = this.stateList.Find(state => state.gameObject.activeSelf && state.gameObject.name == stateName);
            if (newState == null)
            {
                Debug.LogError(stateName + " is Null State", this.gameObject);
                return null;
            }
            return newState;

        }


        protected virtual bool CheckNullState()
        {
            if (this.currentState != null) return false;
            Debug.LogError("Current State is null");
            return true;
        }

    }
}