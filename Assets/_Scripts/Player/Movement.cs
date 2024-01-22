using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Movement : SaiMonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;

        private void Update()
        {
            this.Moving();
        }

        private void Moving()
        {
            int moveX = this.GetMoveX();
            int moveZ = this.GetMoveZ();

            transform.parent.position += new Vector3(moveX, 0f, 0f) * Time.deltaTime * this.moveSpeed;
            transform.parent.position += new Vector3(0f, 0f, moveZ) * Time.deltaTime * this.moveSpeed;
        }

        private int GetMoveX()
        {
            int moveX = 0;
            MoveDirection direction = InputManager.Instance.MoveDirection;
            if (direction.left) moveX = -1;
            if (direction.right) moveX = 1;
            return moveX;
        }

        private int GetMoveZ()
        {
            int moveZ = 0;
            MoveDirection direction = InputManager.Instance.MoveDirection;
            if (direction.up) moveZ = 1;
            if (direction.down) moveZ = -1;
            return moveZ;
        }

    }

}
