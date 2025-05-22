// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.AssemblyLoader
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using TradingPlatform.BusinessLayer.Utils;

#nullable enable
namespace TradingPlatform.BusinessLayer;

/// <summary>The assembly loader.</summary>
public static class AssemblyLoader
{
  private static readonly 
  #nullable disable
  HashSet<string> 퓬픩;
  private static readonly Dictionary<string, AssemblyLoader.퓏> 퓬필;
  private static readonly Dictionary<string, string> 퓬퓖;
  private static Dictionary<string, Dictionary<string, Assembly>> 퓬픵 = new Dictionary<string, Dictionary<string, Assembly>>();

  static AssemblyLoader()
  {
    AssemblyLoader.퓬필 = new Dictionary<string, AssemblyLoader.퓏>();
    AssemblyLoader.퓬픩 = new HashSet<string>()
    {
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓠(),
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓥()
    };
    try
    {
      AssemblyLoader.퓬퓖 = new Dictionary<string, string>();
      string str1 = Path.Combine(Const.CUSTOM_SCRIPTS_PATH, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓯());
      if (File.Exists(str1))
      {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(str1);
        foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
        {
          if (childNode.Attributes[\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜()] != null && childNode.Attributes[\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓑()] != null)
          {
            string str2 = Path.Combine(Const.CUSTOM_SCRIPTS_PATH, childNode.Attributes[\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓑()].Value);
            AssemblyLoader.퓬퓖[childNode.Attributes[\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픜()].Value] = str2;
          }
        }
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핋());
    }
    AppDomain.CurrentDomain.AssemblyResolve += (ResolveEventHandler) (([In] obj0, [In] obj1) =>
    {
      try
      {
        try
        {
          if (obj1.RequestingAssembly != (Assembly) null)
          {
            string path;
            if (AssemblyLoader.퓬퓖.TryGetValue(obj1.Name, out path))
            {
              if (File.Exists(path))
              {
                Assembly assembly = Assembly.Load(File.ReadAllBytes(path));
                if ((object) assembly != null)
                {
                  LoggerManager loggers1 = Core.Instance.Loggers;
                  DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(74, 2);
                  interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓜());
                  interpolatedStringHandler.AppendFormatted(obj1.Name);
                  interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픺());
                  interpolatedStringHandler.AppendFormatted<Assembly>(obj1.RequestingAssembly);
                  string stringAndClear1 = interpolatedStringHandler.ToStringAndClear();
                  loggers1.Log(stringAndClear1);
                  LoggerManager loggers2 = Core.Instance.Loggers;
                  interpolatedStringHandler = new DefaultInterpolatedStringHandler(74, 3);
                  interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핃());
                  interpolatedStringHandler.AppendFormatted(obj1.Name);
                  interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픺());
                  interpolatedStringHandler.AppendFormatted<Assembly>(obj1.RequestingAssembly);
                  interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓫());
                  interpolatedStringHandler.AppendFormatted(path);
                  string stringAndClear2 = interpolatedStringHandler.ToStringAndClear();
                  loggers2.Log(stringAndClear2);
                  return assembly;
                }
              }
            }
          }
        }
        catch (Exception ex)
        {
          Core.Instance.Loggers.Log(ex);
        }
        if (obj1.RequestingAssembly != (Assembly) null)
        {
          AssemblyLoader.퓏 퓏1;
          if (AssemblyLoader.퓬필.TryGetValue(obj1.RequestingAssembly.FullName, out 퓏1))
          {
            Assembly assembly = AssemblyLoader.퓏(obj1.Name, 퓏1.AssemblyFolder);
            if ((object) assembly != null)
              return assembly;
            AssemblyLoader.퓏 퓏2;
            if (AssemblyLoader.퓬필.TryGetValue(obj1.Name, out 퓏2))
              return 퓏2.Assembly;
            LoggerManager loggers = Core.Instance.Loggers;
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(74, 2);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓜());
            interpolatedStringHandler.AppendFormatted(obj1.Name);
            interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픺());
            interpolatedStringHandler.AppendFormatted<Assembly>(obj1.RequestingAssembly);
            string stringAndClear = interpolatedStringHandler.ToStringAndClear();
            loggers.Log(stringAndClear);
          }
        }
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
      return (Assembly) null;
    });
  }

  /// <summary>Load types.</summary>
  /// <param name="folderName">The folder name.</param>
  /// <param name="targetType">The target type.</param>
  /// <param name="assemblyNameFilter">The assembly name filter.</param>
  /// <param name="searchOption">The search option.</param>
  /// <param name="loadInMemory">If true, load in memory.</param>
  /// <param name="allowLoadingReferences">If true, allow loading references.</param>
  /// <returns><![CDATA[List<TypeWrapper>]]></returns>
  public static List<TypeWrapper> LoadTypes(
    string folderName,
    Type targetType,
    string assemblyNameFilter = null,
    SearchOption searchOption = SearchOption.TopDirectoryOnly,
    bool loadInMemory = false,
    bool allowLoadingReferences = false)
  {
    List<TypeWrapper> typeWrapperList = new List<TypeWrapper>();
    try
    {
      foreach (string enumerateFile in Directory.EnumerateFiles(Path.Combine(Const.EXECUTING_FOLDER, folderName), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓞(), searchOption))
      {
        string fileName = Path.GetFileName(enumerateFile);
        if (string.IsNullOrEmpty(assemblyNameFilter) || fileName.Contains(assemblyNameFilter))
        {
          List<TypeWrapper> collection = AssemblyLoader.퓏(enumerateFile, targetType, loadInMemory, allowLoadingReferences);
          if (collection != null)
            typeWrapperList.AddRange((IEnumerable<TypeWrapper>) collection);
        }
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return typeWrapperList;
  }

  internal static List<TypeWrapper> 퓏([In] string obj0, [In] Type obj1, bool _param2 = false, bool _param3 = false)
  {
    List<TypeWrapper> source = new List<TypeWrapper>();
    try
    {
      Assembly assembly = _param2 ? Assembly.Load(File.ReadAllBytes(obj0)) : Assembly.LoadFrom(obj0);
      if (_param3)
        AssemblyLoader.퓬필[assembly.FullName] = new AssemblyLoader.퓏(Path.GetDirectoryName(obj0), assembly);
      foreach (Type exportedType in assembly.ExportedTypes)
      {
        if (!exportedType.IsAbstract && (obj1.IsAssignableFrom(exportedType) || ((IEnumerable<Type>) exportedType.GetInterfaces()).Contains<Type>(obj1)))
          source.Add(new TypeWrapper(exportedType, obj0));
      }
      if (_param3)
      {
        if (source.Any<TypeWrapper>())
          AssemblyLoader.퓏(assembly, obj0);
      }
    }
    catch (BadImageFormatException ex)
    {
      Core.Instance.Loggers.Log((Exception) ex, loggingLevel: LoggingLevel.Verbose);
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
    return source;
  }

  private static void 퓏([In] Assembly obj0, [In] string obj1)
  {
    foreach (AssemblyName referencedAssembly in obj0.GetReferencedAssemblies())
    {
      if (!referencedAssembly.Name.Contains(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핅()))
      {
        if (!AssemblyLoader.퓬픩.Contains(referencedAssembly.Name))
        {
          try
          {
            string path = Path.Combine(Path.GetDirectoryName(obj1), referencedAssembly.Name + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픰());
            if (File.Exists(path))
            {
              Assembly assembly = Assembly.Load(File.ReadAllBytes(path));
              if ((object) assembly != null)
              {
                AssemblyLoader.퓬필[referencedAssembly.FullName] = new AssemblyLoader.퓏(Path.GetDirectoryName(obj1), assembly);
                AssemblyLoader.퓏(assembly, obj1);
              }
            }
          }
          catch (Exception ex)
          {
            Core.Instance.Loggers.Log(ex);
          }
        }
      }
    }
  }

  private static void 퓏([In] string obj0)
  {
    AssemblyLoader.퓬픵[obj0] = new Dictionary<string, Assembly>();
    foreach (string enumerateFile in Directory.EnumerateFiles(obj0, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓞(), SearchOption.AllDirectories))
    {
      try
      {
        Assembly assembly = Assembly.Load(File.ReadAllBytes(enumerateFile));
        if ((object) assembly != null)
          AssemblyLoader.퓬픵[obj0][assembly.FullName] = assembly;
      }
      catch (BadImageFormatException ex)
      {
        Core.Instance.Loggers.Log((Exception) ex, loggingLevel: LoggingLevel.Verbose);
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }
  }

  private static Assembly 퓏([In] string obj0, [In] string obj1)
  {
    if (!AssemblyLoader.퓬픵.ContainsKey(obj1))
      AssemblyLoader.퓏(obj1);
    Dictionary<string, Assembly> dictionary;
    Assembly assembly;
    return AssemblyLoader.퓬픵.TryGetValue(obj1, out dictionary) && dictionary.TryGetValue(obj0, out assembly) ? assembly : (Assembly) null;
  }

  private class 퓏
  {
    public string AssemblyFolder { get; [param: In] set; }

    public Assembly Assembly { get; [param: In] set; }

    public 퓏([In] string obj0, [In] Assembly obj1)
    {
      this.AssemblyFolder = obj0;
      this.Assembly = obj1;
    }
  }
}
