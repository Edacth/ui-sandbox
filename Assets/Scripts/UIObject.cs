using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace Game
{
    public class UIObject : MonoBehaviour
    {
        [SerializeField] Sprite empty;
        [SerializeField] Sprite selectedOverlay;
        public RectTransform rectTransform;
        Image imageRenderer;
        Image overlayRenderer;

        Guid guid;
        private bool selected; // Property Value

        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                overlayRenderer.sprite = value ? selectedOverlay : empty;
            }
        }

        private void Awake()
        {
            guid = Guid.NewGuid();
            rectTransform = GetComponent<RectTransform>();
            imageRenderer = GetComponent<Image>();
            overlayRenderer = transform.GetChild(0).GetComponent<Image>();
        }

        private void Start()
        {
            Selected = false;
        }

        private void OnEnable()
        {
            UIController.instance.uiObjects.Add(this);
        }

        private void OnDisable()
        {
            if (UIController.instance == null) { return; }
            UIController.instance.uiObjects.Remove(this);
        }

        public void SetVisible(bool _visible)
        {
            imageRenderer.enabled = _visible;
            overlayRenderer.enabled = _visible;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            UIObject objAsUIObject = obj as UIObject;
            if (objAsUIObject == null) { return false; }
            else return base.Equals(objAsUIObject);
        }

        public bool Equals(UIObject other)
        {
            if (other == null) { return false; }
            return (this.guid.Equals(other.guid));
        }
    }
}