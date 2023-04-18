using UnityEngine;
using Map;
namespace Entity
{
    internal class CharacterControl : MonoBehaviour
    {
        EnvironmentTransform _currentTransForm;
        public void SetPosition(EnvironmentTransform nextEnvironment)
        {
            if (!CheckJumb(nextEnvironment)) return;
            this.transform.position = nextEnvironment.position+Vector3.up;
            _currentTransForm = nextEnvironment;
            MapControl.Instance.SpawnNext(nextEnvironment);
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

        private bool CheckJumb(EnvironmentTransform transform)
        {
            return Mathf.Abs(_currentTransForm.x - transform.x) <= 2
                && Mathf.Abs(_currentTransForm.y - transform.y) == 1;
        }
    }
}
