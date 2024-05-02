
using GuardiansWall.Settings;
using GuardiansWall.Utils;
using UnityEngine;

namespace GuardiansWall.Engine
{
    internal sealed class StartGame : MonoBehaviour
    {
        [SerializeField] private SettingsContainer _settingsContainer;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Transform _placeForUI;

        private const GameState InitialState = GameState.StartGame; 

        private MainController _mainController;


        private void Start()
        {
            ProfileGame profileGame = new ProfileGame(InitialState);
            _mainController = new MainController(profileGame,_settingsContainer,_placeForUI);
        }

        private void Update()
        {
            _mainController.Update();
        }
    }
}
