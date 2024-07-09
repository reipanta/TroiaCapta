using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEngine.Input;

namespace GameServices.Input
{
    // This class is used to attach joints to ingredients upon mouse click to make them draggable
    public class MouseDraggable : MonoBehaviour {
        
        // Damping and frequency are made serializable to calibrate them in editor
        [SerializeField, Range(0.0f, 100.0f)] private float damping = 5.0f;
        [SerializeField, Range(0.0f, 100.0f)] private float frequency = 5.0f;
        [SerializeField] private LayerMask mask; // Used to include/exclude certain objects from interactions

        private TargetJoint2D _targetJoint;
        private Vector2 _mousePos;
        private Rigidbody2D _rigidBody;
        private Collider2D _collider2D;

        // This method attaches a TargetJoint2D to the object at the mouse position
        public void AttachJoint()
        {
            _mousePos = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition); // Get current mouse position
            _collider2D = Physics2D.OverlapPoint(_mousePos, mask); // Check for a collider at the mouse position with the specified layer mask ("Collidable")

            if (_collider2D != null) // If a collider is found on the overlap place...
            {
                _rigidBody = _collider2D.attachedRigidbody; // ...get the Rigidbody2D component attached to the collider

                if (_rigidBody != null) // If the Rigidbody2D component is found...
                {
                    _targetJoint = _rigidBody.gameObject.AddComponent<TargetJoint2D>(); // ...add a joint
                    _targetJoint.dampingRatio = damping;
                    _targetJoint.frequency = frequency;
                }
            }
        }
        // This method is called when the LMB is down continously
        private void OnMouseDown()
        {
            AttachJoint();
        }

        // This method is called when the mouse is moving AND the LMB is still down on an object
        private void OnMouseDrag()
        {
            FollowMouse();
        }

        public void FollowMouse()
        {
            if (_targetJoint != null) // Check for no component
            {
                _mousePos = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition); // Get mouse position
                _targetJoint.target = _mousePos; // Make the object follow mouse position
            }
        } 

        // This method is called the moment the LMB is up again
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