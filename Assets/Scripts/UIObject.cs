using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace Game
{
    public class UIObject : MonoBehaviour
    {
        [SerializeField] bool selectable;
        [SerializeField] Sprite empty;
        [SerializeField] Sprite selectedOverlay;
        public RectTransform rectTransform;

        protected SpriteRenderer spriteRenderer;
        protected SpriteRenderer overlayRenderer;

        public Guid Guid
        {
            get;
            private set;
        }

        private bool selected; // Property Value

        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                if (!selectable) { return; }
                selected = value;
                overlayRenderer.sprite = value ? selectedOverlay : empty;
            }
        }

        private void Awake()
        {
            UIObjectInit();
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

        protected void UIObjectInit()
        {
            Guid = Guid.NewGuid();
            rectTransform = GetComponent<RectTransform>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            overlayRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        }

        public void SetVisible(bool _visible)
        {
            spriteRenderer.enabled = _visible;
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
            return (this.Guid.Equals(other.Guid));
        }
    }
}