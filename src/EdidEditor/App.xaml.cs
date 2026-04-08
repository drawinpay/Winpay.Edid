using System.Configuration;
using System.Data;
using System.Windows;

namespace EdidEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            ResourceDictionary? dict = ResourceLoader.LoadResourceDictionary(
                "EdidEditor.Theme.Light.dll",
                "Themes/Generic.xaml"
            );
            
            //Application.Current.Resources.MergedDictionaries.Add(dict);
        }
    }
}
