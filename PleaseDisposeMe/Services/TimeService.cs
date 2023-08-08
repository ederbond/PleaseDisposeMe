using System.Reactive.Disposables;
using System.Reactive.Subjects;
using Reactive.Bindings.Extensions;

namespace PleaseDisposeMe.Services;

public interface ITimeService
{
    IObservable<DateTime> ObserveTime { get; }
    public void NotifyNow();
}

public class TimeService : IDisposable, ITimeService
{
    private readonly CompositeDisposable _disposables = new();
    private readonly BehaviorSubject<DateTime> _timeSubject;

    public TimeService()
    {
        _timeSubject = new BehaviorSubject<DateTime>(DateTime.Now).AddTo(_disposables);
    }

    public IObservable<DateTime> ObserveTime => _timeSubject;

    public void NotifyNow()
    {
        _timeSubject.OnNext(DateTime.Now);
    }

    public void Dispose()
    {
        _disposables?.Dispose();
    }
}