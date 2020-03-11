using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Have some UIObjects with restricted movement E.g. locked to one side of the screen

namespace Game
{
    public class UIController : SCP_Singleton<UIController>
    {
        [SerializeField] Camera mainCamera;
        public List<UIObject> uiObjects;

        [Tooltip("How much mouse movement to ignore before it becomes a drag")]
        [SerializeField] float dragThreshhold = 0.1f;
        Vector3 mousePos;
        Vector3 lastTickMousePos;
        bool leftMouseHeld;
        bool thisClickSelected;
        bool thisClickMoved;
        bool visible = true;

        public bool Visible
        {
            get { return visible; }
            set
            {
                if (value == visible) { return; }
                SetUIVisible(value);
                visible = value;
            }
        }

        private void Awake()
        {
            SingletonInit(this, true);
            uiObjects = new List<UIObject>();
        }

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            mousePos = Input.mousePosition;

            if (leftMouseHeld)
            {
                if ((mousePos - lastTickMousePos).magnitude >= dragThreshhold)
                {
                    MoveUIObjects(mousePos - lastTickMousePos, true);
                    thisClickMoved = true;
                }
            }
            else
            {
                thisClickSelected = false;
                thisClickMoved = false;
            }

            if (Input.GetMouseButtonDown(0)) // Left mouse press
            {
                leftMouseHeld = true;

                // Select UIObjects
                UIObject[] matchingObjects = GetUIObjectsAtPoint(mousePos);
                for (int i = 0; i < matchingObjects.Length; i++)
                {
                    if (!matchingObjects[i].Selected)
                    {
                        matchingObjects[i].Selected = true;
                        thisClickSelected = true;
                    }

                }
            }

            if (Input.GetMouseButtonUp(0)) // Left mouse release
            {
                leftMouseHeld = false;

                // Deselect UIObjects if we didn't select an object this frame
                if (!thisClickSelected && !thisClickMoved)
                {
                    UIObject[] matchingObjects = GetUIObjectsAtPoint(mousePos);

                    for (int i = 0; i < matchingObjects.Length; i++)
                    {
                        if (matchingObjects[i].Selected)
                        {
                            matchingObjects[i].Selected = false;
                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Visible = !Visible;
            }

            lastTickMousePos = Input.mousePosition;
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Gizmos.DrawSphere(mouseWorldPos, 0.2f);
                Gizmos.DrawSphere(Input.mousePosition, 5f);
            }
        }

        void MoveUIObjects(Vector3 _movementVector, bool _onlySelected)
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                if (_onlySelected && !uiObjects[i].Selected) { continue; }
                uiObjects[i].transform.position += _movementVector;
            }
        }

        UIObject[] GetUIObjectsAtPoint(Vector3 _point)
        {
            List<UIObject> matchingObjects = new List<UIObject>();
            for (int i = 0; i < uiObjects.Count; i++)
            {
                Vector3 topRightCorner = new Vector3();
                Vector3 bottomLeftCorner = new Vector3();
                topRightCorner.x = uiObjects[i].rectTransform.position.x + uiObjects[i].rectTransform.rect.width / 2;
                topRightCorner.y = uiObjects[i].rectTransform.position.y + uiObjects[i].rectTransform.rect.height / 2;
                bottomLeftCorner.x = uiObjects[i].rectTransform.position.x - uiObjects[i].rectTransform.rect.width / 2;
                bottomLeftCorner.y = uiObjects[i].rectTransform.position.y - uiObjects[i].rectTransform.rect.height / 2;

                Debug.DrawLine(topRightCorner, bottomLeftCorner, Color.red, 1f);

                if (_point.x <= topRightCorner.x && _point.y <= topRightCorner.y &&
                    _point.x >= bottomLeftCorner.x && _point.y >= bottomLeftCorner.y)
                {
                    matchingObjects.Add(uiObjects[i]);
                }
            }

            return matchingObjects.ToArray();
        }

        void SetUIVisible(bool _visible)
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                uiObjects[i].SetVisible(_visible);
            }
        }

        public void ShootInUI(CARDINAL _dir)
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                UIShooter uiShooter = uiObjects[i] as UIShooter;

                if (uiShooter != null && uiShooter.direction == _dir)
                {
                    uiShooter.Shoot();
                }
            }
        }

        void PrintUIOjects()
        {
            for (int i = 0; i < uiObjects.Count; i++)
            {
                Debug.DrawRay(uiObjects[i].transform.position, Vector3.up * 100, Color.red, 1f);

            }
            Debug.Log(uiObjects.Count.ToString());
        }
    }
}

