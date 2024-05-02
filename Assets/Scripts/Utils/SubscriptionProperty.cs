using System;


namespace GuardiansWall.Utils
{
    internal sealed class SubscriptionProperty<TValue> : ISubscriptionProperty<TValue>
    {
        private TValue _value;
        private Action<TValue> _onChangedValue;

        public TValue Value
        {
            get => _value;

            set
            {
                _value = value;
                _onChangedValue?.Invoke(_value);
            }
        }

        public void SubscribeOnChanged(Action<TValue> subscriptionAction)
        {
            _onChangedValue += subscriptionAction;
        }

        public void UnSubscribeOnChanged(Action<TValue> unsubscriptionAction)
        {
            _onChangedValue -= unsubscriptionAction;
        }
    }
}
