using System.Reflection;
using System.Windows;

namespace EdidEditor;

public static class ResourceLoader
{
    /// <summary>
    /// 通过反射加载外部 DLL 的资源字典
    /// </summary>
    /// <param name="assemblyName">dll 名称，如：MyTheme.dll</param>
    /// <param name="resourcePath">资源路径，如：Themes/Default.xaml</param>
    public static ResourceDictionary? LoadResourceDictionary(string assemblyName, string resourcePath)
    {
        try
        {
            Assembly assembly = Assembly.LoadFrom(assemblyName);
            string assemblySimpleName = assembly.GetName().Name!;
            var uri = $"pack://application:,,,/{assemblySimpleName};component/{resourcePath}";
            
            var dict = new ResourceDictionary
            {
                Source = new Uri(uri, UriKind.Absolute)
            };

            return dict;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}