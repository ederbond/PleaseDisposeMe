using PleaseDisposeMe.Services;
using Reactive.Bindings;
using Reactive.Bindings.Disposables;
using Reactive.Bindings.Extensions;

namespace PleaseDisposeMe;

public class Page2ViewModel : IQueryAttributable, IDisposable
{
    private readonly CompositeDisposable _disposables = new();
    private readonly ITimeService _service;

    public Page2ViewModel(ITimeService service)
    {
        _service = service;
        CurrentTime = new ReactiveProperty<string>().AddTo(_disposables);
        NextCommand = new AsyncReactiveCommand().WithSubscribe(GoNextPage).AddTo(_disposables);
    }

    public ReactiveProperty<string> CurrentTime { get; }
    public AsyncReactiveCommand NextCommand { get; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _service.ObserveTime.Subscribe(x =>
        {
            CurrentTime.Value = x.ToLongTimeString();
        }).AddTo(_disposables);
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