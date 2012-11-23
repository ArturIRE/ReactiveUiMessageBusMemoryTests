namespace RXMemoryTests
{
    using System;
    using ReactiveUI;

    public class ViewModel : ReactiveObject
    {
        private IDisposable subscription;

        private bool messageReceived;

        public ViewModel()
        {
            this.messageReceived = false;
        }

        public void SubscribeToMessageBus(IMessageBus messageBus)
        {
            if (this.subscription == null)
            {
                this.subscription = messageBus.Listen<object>().Subscribe(this.SubscriptionHandler);
            }
        }

        public void SendMessage(IMessageBus messageBus)
        {
            messageBus.SendMessage(new object());
        }

        public bool HasReceivedMessage
        {
            get
            {
                return this.messageReceived;
            }
        }

        private void SubscriptionHandler(object obj)
        {
            this.messageReceived = true;
        }

        public void Unsubscribe()
        {
            if (this.subscription != null)
            {
                this.subscription.Dispose();
            }
        }
    }
}
