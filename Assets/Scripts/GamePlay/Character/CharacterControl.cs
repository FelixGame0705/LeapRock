using UnityEngine;
using Map;
namespace Character
{
    internal class CharacterControl : MonoBehaviour
    {
        EnvironmentTransform _currentTransForm;
        public void SetPosition(EnvironmentTransform transform)
        {
            this.transform.position = transform.position+Vector3.up;
            _currentTransForm = transform;
            MapControl.Instance.SpawnNext(transform);
        }
        private void Update()
        {

            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    Environment env = hit.transform.GetComponent<Environment>();
                    if(env) SetPosition(env.GetCurrentPosition());
                }
            }
        }
    }
}
