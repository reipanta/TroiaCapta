using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEngine.Input;

namespace GameServices.Input
{
    // This class is used to attach joints to ingredients upon mouse click to make them draggable
    public class MouseDraggable : MonoBehaviour
    {
        [SerializeField, Range(0.0f, 100.0f)] private float damping = 5.0f;
        [SerializeField, Range(0.0f, 100.0f)] private float frequency = 5.0f;

        [SerializeField]
        private LayerMask mask; // Used to include/exclude certain objects (like spawners) from interaction

        private TargetJoint2D _targetJoint;
        private Vector2 _mousePos;
        private Rigidbody2D _rigidBody;
        private Collider2D _collider2D;

        // This method attaches a TargetJoint2D to the object at the mouse position
        public void AttachJoint()
        {
            _mousePos = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            _collider2D = Physics2D.OverlapPoint(_mousePos, mask);

            if (_collider2D != null)
            {
                _rigidBody = _collider2D.attachedRigidbody;

                if (_rigidBody != null)
                {
                    _targetJoint = _rigidBody.gameObject.AddComponent<TargetJoint2D>();
                    _targetJoint.dampingRatio = damping;
                    _targetJoint.frequency = frequency;
                }
            }
        }

        private void OnMouseDown()
        {
            AttachJoint();
        }


        private void OnMouseDrag()
        {
            FollowMouse();
        }

        public void FollowMouse()
        {
            if (_targetJoint != null)
            {
                _mousePos = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
                _targetJoint.target = _mousePos;
            }
        }

        private void OnMouseUp()
        {
            if (_targetJoint != null)
            {
                Destroy(_targetJoint);
                _targetJoint = null;
            }
        }
    }
}