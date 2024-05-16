using UnityEngine;

namespace AComponents
{
    public class ActionConstantMove : ActionBase
    {
        public float speed;
        protected override void ExecuteInternal()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (speed * Time.deltaTime));
        }
    }
}