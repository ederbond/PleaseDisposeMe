using PleaseDisposeMe.Services;
using Reactive.Bindings;
using Reactive.Bindings.Disposables;
using Reactive.Bindings.Extensions;

namespace PleaseDisposeMe;

public class Page1ViewModel : IDisposable
{
    private readonly CompositeDisposable _disposables = new();
    private readonly ITimeService _service;

    public Page1ViewModel(ITimeService service)
    {
        _service = service;
        CurrentTime = new ReactiveProperty<string>().AddTo(_disposables);
        NotifyCommand = new ReactiveCommand().WithSubscribe(Notify).AddTo(_disposables);
        NextCommand = new AsyncReactiveCommand().WithSubscribe(GoNextPage).AddTo(_disposables);

        _service.ObserveTime.Subscribe(x =>
        {
            CurrentTime.Value = x.ToLongTimeString();
        }).AddTo(_disposables);
    }

    public ReactiveProperty<string> CurrentTime { get; }
    public AsyncReactiveCommand NextCommand { get; }
    public ReactiveCommand NotifyCommand { get; }
    
    private void Notify()
    {
        _service.NotifyNow();
    }

    private async Task GoNextPage()
    {
        await Shell.Current.GoToAsync("Page2");
    }

    public void Dispose()
    {
        _disposables?.Dispose();
    }
}