using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI.Optimization
{
    public class StaticUIOptimizer : MonoBehaviour
    {
        [SerializeField] private RectTransform _staticUIRoot;

        private LayoutGroup[] _layoutGroups;

        private void Awake()
        {
            _layoutGroups = GetComponentsInChildren<LayoutGroup>();
        }

        private void Start()
        {
            RebuildStaticUI();
        }

        public void RebuildStaticUI()
        {
            RebuildAsync().Forget();
        }

        private async UniTaskVoid RebuildAsync()
        {
            foreach (var layoutGroup in _layoutGroups)
                layoutGroup.enabled = true;

            await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);

            LayoutRebuilder.ForceRebuildLayoutImmediate(_staticUIRoot);

            foreach (var layoutGroup in _layoutGroups)
                layoutGroup.enabled = false;
        }
    }
}