using UnityEngine;

namespace AComponents
{
    public abstract class ActionBase : MonoBehaviour
    {
        [SerializeField] protected bool _executeOnAwake;
        [SerializeField] protected bool _executeOnce;
        [SerializeField] protected bool _executeOnUpdate;

        protected bool _isExecutedOnce;

        private void Awake()
        {
            if (_executeOnAwake)
            {
                _isExecutedOnce = true;
                ExecuteInternal();
            }
        }
        private void Update()
        {
            if (_executeOnUpdate)
            {
                ExecuteInternal();
            }
        }
        public void Execute()
        {
            if (_executeOnce && _isExecutedOnce)
                return;

            _isExecutedOnce = true;
            ExecuteInternal();
        }
        protected abstract void ExecuteInternal();
    }
}