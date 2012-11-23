namespace RXMemoryTests
{
    using System;
    using NUnit.Framework;
    using ReactiveUI;

    public class Tests
    {
        [Test]
        public void ViewModelIsGarbageCollectedWhenSetToNull()
        {
            var viewModel = new ViewModel();
            var lifetimeMonitor = new WeakReference(viewModel);

            viewModel = null;

            Helper.RunGarbageCollection();

            Assert.IsFalse(lifetimeMonitor.IsAlive);
        }

        [Test]
        public void ViewModelIsGarbageCollectedWhenUnsubscribedFromMessageBus()
        {
            var messageBus = new MessageBus();
            var subscribingViewModel = new ViewModel();
            var lifetimeMonitor = new WeakReference(subscribingViewModel);

            subscribingViewModel.SubscribeToMessageBus(messageBus);

            subscribingViewModel.Unsubscribe();

            subscribingViewModel = null;

            Helper.RunGarbageCollection();

            Assert.IsFalse(lifetimeMonitor.IsAlive);
        }

        [Test]
        public void ViewModelIsGarbageCollectedWhileStillSubscribedToTheMessageBus()
        {
            var messageBus = new MessageBus();
            var subscribingViewModel = new ViewModel();
            var lifetimeMonitor = new WeakReference(subscribingViewModel);

            subscribingViewModel.SubscribeToMessageBus(messageBus);

            subscribingViewModel = null;

            Helper.RunGarbageCollection();

            Assert.IsFalse(lifetimeMonitor.IsAlive);
        }
    }
}
