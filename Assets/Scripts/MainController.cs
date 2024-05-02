
using GuardiansWall.Settings;
using GuardiansWall.Utils;
using UnityEngine;
using GuardiansWall.Engine.Game;
using GuardiansWall.Engine.LevelSelect;
using GuardiansWall.Engine.MainMenu;

namespace GuardiansWall.Engine
{
    internal sealed class MainController : BaseController
    {
        private readonly ProfileGame _profileGame;
        private readonly SettingsContainer _settingsContainer;
        private readonly Transform _placeForUI;

        private GameController _gameController;
        private LevelSelectController _levelSelectController;
        private MainMenuController _mainMenuController;

        public MainController(ProfileGame profileGame,SettingsContainer settingsContainer,Transform placeForUI)
        {
            _profileGame = profileGame;
            _settingsContainer = settingsContainer;
            _placeForUI = placeForUI;

            _profileGame.CurrentGameState.SubscribeOnChanged(OnChangeGameState);
            OnChangeGameState(_profileGame.CurrentGameState.Value);

        }

        private void OnChangeGameState(GameState gameState)
        {
            DisposeAllControllers();

            switch (gameState)
            {
                case GameState.MainMenu:
                    _mainMenuController = new MainMenuController();
                    AddBaseController(_mainMenuController);
                    break;
                case GameState.Settings:
                    break;
                case GameState.LevelSelect:
                    _levelSelectController = new LevelSelectController();
                    AddBaseController(_levelSelectController);
                    break;
                case GameState.StartGame:
                    _gameController = new GameController();
                    AddBaseController(_gameController);
                    break;
                case GameState.QuitGame:
                    QuitGame();
                    break;
                default:
                    DisposeAllControllers();
                    break;
            }
        }

        private void DisposeAllControllers()
        {
            _gameController?.Dispose();
            _mainMenuController?.Dispose();
            _levelSelectController?.Dispose();
        }

        private void QuitGame()
        {
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
            {
                Debug.Log(this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
#endif

#if (UNITY_EDITOR)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }

#elif (UNITY_STANDALONE)
            {
               Application.Quit();
            }
#elif (UNITY_WEBGL)
            {
               SceneManager.LoadScene("QuitScene");
            }
#endif
        }

        protected override void OnDispose()
        {
            _gameController?.Dispose();
            _mainMenuController?.Dispose();
            _levelSelectController?.Dispose();
            _profileGame.CurrentGameState.UnSubscribeOnChanged(OnChangeGameState);
        }
    }
}
