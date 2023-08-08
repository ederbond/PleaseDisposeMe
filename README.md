# PleaseDisposeMe

Steps to reproduce the issue:

1) Set a breakpoint on Page2ViewModel line 27
2) Run the app on debug mode
3) Click on the button called "Notify Now"
4) You'll see that the label with the current time is updated on the screen. (cool)
5) Click "Go To Page 2"
6) You'll see the app will hit your break point a single time (cool)
7) Go back to page 1
8) Click on the button called "Notify Now"
9) You'll see that your break point on Page2V is still getting called wich is bad cause that page was registered as Transient on MauiProgram
10) Then Navigate again to Page 2
11) You'll see that your break point will be hit one time again (cool)
12) Go back to Page 1 and click on the button called "Notify Now"
13) You'll see that your breakpoint will stop 2x. And if you go back and forth you'll see that your break point will be hitted several times. That's because your Transient ViewModel is still live and listening for data coming from that observable. I my guess is that tha VM will never ever be disposed
because it holds subscription from my SingletonService.
In the past time of Xamarin.Forms it wasn't an issue for me cause I wasn't using Shell and I was using Prism Library which offers me an interface called IDestructible that when implemented on my VM was always calling a void Destroy() method for me.
But since prism is not supporting Maui nor Shell (Dan Seigel already told me that they doesn't even have a plan to support shell in the future).
So if someone decides to make Reactive Programing on Maui with Shell you're on a big trouble.

This examples clearly shows that without a proper easy and reliable extension point from the MAUI framework to dispose objects inside a VM your app will have serious memory leaks.
