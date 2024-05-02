using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GuardiansWall.Engine
{
    public class BaseController : IDisposable
    {
        private List<BaseController> _baseControllers;
        private List<GameObject> _gameObjectsInGame;
        private bool _isDisposed;


        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;

            OnDispose();
            DisposeAllGameObjects();
            DisposeAllControllers();
        }

        private void DisposeAllGameObjects()
        {
            for (int i = 0; i < _gameObjectsInGame.Count; i++)
            {
                Object.Destroy(_gameObjectsInGame[i]);
            }

            _gameObjectsInGame.Clear();
        }

        private void DisposeAllControllers()
        {
            for (int i = 0; i < _baseControllers.Count; i++)
            {
                _baseControllers[i].Dispose();
            }

            _baseControllers.Clear();
        }

        protected virtual void OnDispose() { }

        protected void AddGameObjects(GameObject gameObject)
        {
            if (_gameObjectsInGame == null)
            {
                _gameObjectsInGame = new List<GameObject>();
            }

            _gameObjectsInGame.Add(gameObject);
        }

        protected void AddBaseController(BaseController baseController)
        {
            if (_baseControllers == null)
            {
                _baseControllers = new List<BaseController>();
            }

            _baseControllers.Add(baseController);
        }

        public void Update()
        {
            if (_baseControllers == null)
            {
                return;
            }
            else
            {
                for (int i = 0; i < _baseControllers.Count; i++)
                {
                    if (_baseControllers[i] is IExecute executeController)
                    {
                        executeController.Execute();
                    }
                }
            }
        }
    }
}
