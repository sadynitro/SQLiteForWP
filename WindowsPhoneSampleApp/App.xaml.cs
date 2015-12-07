using Microsoft.Practices.Prism.Mvvm;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsPhoneSampleApp.Models;
using WindowsPhoneSampleApp.ViewModels;
using WindowsPhoneSampleApp.Views;

namespace WindowsPhoneSampleApp
{
  /// <summary>
  /// 既定の Application クラスに対してアプリケーション独自の動作を実装します。
  /// </summary>
  public sealed partial class App : MvvmAppBase
  {
    protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
    {
      var rootFrame = (Frame)Window.Current.Content;
      rootFrame.Language = ApplicationLanguages.Languages[0];

      NavigationService.Navigate("Main", args.Arguments);
      return Task.FromResult(default(object));
    }

    protected override Task OnInitializeAsync(IActivatedEventArgs args)
    {
      var listItemModel = new ListItemModel();

      // VとVMとMのマッピング
      ViewModelLocationProvider.Register(
          typeof(MainPage).FullName,
          () => new ListItemViewModel(listItemModel));
      
      return Task.FromResult<object>(null);
    }
  }
}