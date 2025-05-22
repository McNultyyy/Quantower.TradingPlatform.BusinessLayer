// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.ScriptManager`2
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
using System.Runtime.InteropServices;
using System.Threading.Tasks;

#nullable enable
namespace TradingPlatform.BusinessLayer;

public abstract class ScriptManager<TScriptInfo, TScript> : IDisposable
  where TScriptInfo : 
  #nullable disable
  ScriptInfo
  where TScript : ExecutionEntity
{
  protected Dictionary<ScriptKey, TScriptInfo> scriptsInfoCache;
  private readonly Dictionary<string, List<ScriptKey>> 퓬퓥;
  private readonly Dictionary<string, List<TScriptInfo>> 퓬퓯;
  private readonly FileSystemWatcher 퓬픜;
  private readonly HashSet<string> 퓬퓑;
  private readonly Dictionary<string, DateTime> 퓬핋;
  private readonly object 퓬퓞;

  public event ScriptInfoEventHandler ScriptAdded;

  public event ScriptInfoEventHandler ScriptUpdated;

  public event ScriptInfoEventHandler ScriptDeleted;

  protected abstract string DefaultScriptsPath { get; }

  public abstract string CustomScriptsPath { get; }

  public TScriptInfo[] All => this.scriptsInfoCache.Values.ToArray<TScriptInfo>();

  protected ScriptManager()
  {
    this.scriptsInfoCache = new Dictionary<ScriptKey, TScriptInfo>();
    this.퓬퓥 = new Dictionary<string, List<ScriptKey>>();
    this.퓬퓯 = new Dictionary<string, List<TScriptInfo>>();
    this.퓬픜 = new FileSystemWatcher();
    this.퓬퓑 = new HashSet<string>();
    this.퓬핋 = new Dictionary<string, DateTime>();
    this.퓬퓞 = new object();
  }

  internal virtual void 퓏()
  {
    string customScriptsPath = this.CustomScriptsPath;
    if (!Directory.Exists(customScriptsPath))
      Directory.CreateDirectory(customScriptsPath);
    this.퓏(AssemblyLoader.LoadTypes(this.DefaultScriptsPath, typeof (TScript), searchOption: SearchOption.AllDirectories, loadInMemory: true), ScriptCreationType.Default);
    this.퓏(AssemblyLoader.LoadTypes(customScriptsPath, typeof (TScript), searchOption: SearchOption.AllDirectories, loadInMemory: true, allowLoadingReferences: true), ScriptCreationType.Custom);
    this.퓬픜.Path = customScriptsPath;
    this.퓬픜.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size;
    this.퓬픜.IncludeSubdirectories = true;
    this.퓬픜.Created += new FileSystemEventHandler(this.퓏);
    this.퓬픜.Changed += new FileSystemEventHandler(this.퓬);
    this.퓬픜.Deleted += new FileSystemEventHandler(this.핇);
    this.퓬픜.EnableRaisingEvents = true;
  }

  private void 퓏([In] List<TypeWrapper> obj0, [In] ScriptCreationType obj1)
  {
    if (obj0 == null)
      return;
    string scriptsFolderPath = this.GetScriptsFolderPath(obj1);
    foreach (TypeWrapper typeWrapper in obj0)
    {
      try
      {
        ConstructorInfo constructor = typeWrapper.Type.GetConstructor(Array.Empty<Type>());
        string directoryName = Path.GetDirectoryName(ScriptManager<TScriptInfo, TScript>.퓏(typeWrapper.AssemblyLocation, scriptsFolderPath));
        TScriptInfo scriptInfo = this.CreateScriptInfo(constructor, obj1, directoryName, typeWrapper.Type.Assembly.GetName().Name);
        if (!(scriptInfo.Key == new ScriptKey()))
          this.퓏(scriptInfo, typeWrapper.AssemblyLocation);
      }
      catch (Exception ex)
      {
        Core.Instance.Loggers.Log(ex);
      }
    }
  }

  protected abstract string GetScriptsFolderPath(ScriptCreationType scriptCreationType);

  protected abstract TScriptInfo CreateScriptInfo(
    ConstructorInfo ctor,
    ScriptCreationType scriptCreationType,
    string relativePath,
    string assemblyName);

  protected ScriptKey SearchScriptKey(
    string scriptName,
    string assemblyName,
    string relativePath,
    ScriptCreationType scriptCreationType = ScriptCreationType.Default)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ScriptManager<TScriptInfo, TScript>.퓏\u00602 퓏 = new ScriptManager<TScriptInfo, TScript>.퓏\u00602();
    // ISSUE: reference to a compiler-generated field
    퓏.퓍픺 = scriptCreationType;
    // ISSUE: reference to a compiler-generated field
    퓏.퓍핃 = relativePath;
    // ISSUE: reference to a compiler-generated field
    퓏.퓍퓫 = assemblyName;
    List<ScriptKey> scriptKeyList;
    if (!this.퓬퓥.TryGetValue(scriptName, out scriptKeyList))
      return new ScriptKey();
    if (!scriptKeyList.Any<ScriptKey>())
      return new ScriptKey();
    // ISSUE: reference to a compiler-generated method
    List<ScriptKey> list = new List<ScriptKey>((IEnumerable<ScriptKey>) scriptKeyList).Where<ScriptKey>(new Func<ScriptKey, bool>(퓏.퓏)).ToList<ScriptKey>();
    // ISSUE: reference to a compiler-generated field
    if (!string.IsNullOrEmpty(퓏.퓍핃))
    {
      // ISSUE: reference to a compiler-generated method
      list = list.Where<ScriptKey>(new Func<ScriptKey, bool>(퓏.퓬)).ToList<ScriptKey>();
    }
    // ISSUE: reference to a compiler-generated field
    if (!string.IsNullOrEmpty(퓏.퓍퓫))
    {
      // ISSUE: reference to a compiler-generated method
      list = list.Where<ScriptKey>(new Func<ScriptKey, bool>(퓏.핇)).ToList<ScriptKey>();
    }
    return list.FirstOrDefault<ScriptKey>();
  }

  private static string 퓏([In] string obj0, [In] string obj1)
  {
    Uri uri = new Uri(obj0);
    if (!obj1.EndsWith(Path.DirectorySeparatorChar.ToString()))
    {
      ReadOnlySpan<char> readOnlySpan1 = (ReadOnlySpan<char>) obj1;
      char directorySeparatorChar = Path.DirectorySeparatorChar;
      ReadOnlySpan<char> readOnlySpan2 = new ReadOnlySpan<char>(ref directorySeparatorChar);
      obj1 = readOnlySpan1.ToString() + readOnlySpan2;
    }
    return Uri.UnescapeDataString(new Uri(obj1).MakeRelativeUri(uri).ToString().Replace('/', Path.DirectorySeparatorChar));
  }

  public virtual void Dispose()
  {
    this.퓬픜.Created -= new FileSystemEventHandler(this.퓏);
    this.퓬픜.Changed -= new FileSystemEventHandler(this.퓬);
    this.퓬픜.Deleted -= new FileSystemEventHandler(this.핇);
    this.퓬픜.EnableRaisingEvents = false;
    this.퓬픜.Dispose();
    this.scriptsInfoCache?.Clear();
    this.퓬퓥?.Clear();
  }

  private void 퓏([In] object obj0, [In] FileSystemEventArgs obj1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ScriptManager<TScriptInfo, TScript>.퓬\u00602 퓬 = new ScriptManager<TScriptInfo, TScript>.퓬\u00602();
    // ISSUE: reference to a compiler-generated field
    퓬.퓍핌 = this;
    // ISSUE: reference to a compiler-generated field
    퓬.퓍퓩 = obj1;
    // ISSUE: reference to a compiler-generated field
    if (ScriptManager<TScriptInfo, TScript>.퓬(퓬.퓍퓩.FullPath))
      return;
    // ISSUE: reference to a compiler-generated field
    this.퓬퓑.Remove(퓬.퓍퓩.FullPath);
    // ISSUE: reference to a compiler-generated method
    Task.Delay(1000).ContinueWith(new Action<Task>(퓬.퓏));
  }

  private void 퓬([In] object obj0, [In] FileSystemEventArgs obj1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ScriptManager<TScriptInfo, TScript>.핇\u00602 핇 = new ScriptManager<TScriptInfo, TScript>.핇\u00602();
    // ISSUE: reference to a compiler-generated field
    핇.퓍퓨 = this;
    // ISSUE: reference to a compiler-generated field
    핇.퓍퓱 = obj1;
    // ISSUE: reference to a compiler-generated field
    if (ScriptManager<TScriptInfo, TScript>.퓬(핇.퓍퓱.FullPath))
      return;
    // ISSUE: reference to a compiler-generated method
    Task.Delay(1000).ContinueWith(new Action<Task>(핇.퓏));
  }

  private void 핇([In] object obj0, [In] FileSystemEventArgs obj1)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ScriptManager<TScriptInfo, TScript>.퓲\u00602 퓲 = new ScriptManager<TScriptInfo, TScript>.퓲\u00602();
    // ISSUE: reference to a compiler-generated field
    퓲.퓍픹 = this;
    // ISSUE: reference to a compiler-generated field
    퓲.퓍퓺 = new List<string>();
    if (!Path.HasExtension(obj1.FullPath))
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      퓲.퓍퓺.AddRange(this.퓬퓯.Keys.Where<string>(new Func<string, bool>(new ScriptManager<TScriptInfo, TScript>.핂\u00602()
      {
        퓍픊 = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓧() + ScriptManager<TScriptInfo, TScript>.MakeRelativePath(this.CustomScriptsPath, obj1.FullPath) + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓧()
      }.퓏)));
    }
    else if (Path.GetExtension(obj1.FullPath) == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픰())
    {
      // ISSUE: reference to a compiler-generated field
      퓲.퓍퓺.Add(obj1.FullPath);
    }
    // ISSUE: reference to a compiler-generated field
    if (퓲.퓍퓺.Count == 0)
      return;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    퓲.퓍퓺.ForEach(new Action<string>(퓲.퓏));
    // ISSUE: reference to a compiler-generated method
    Task.Delay(2000).ContinueWith(new Action<Task>(퓲.퓏));
  }

  private void 퓏([In] ScriptInfo obj0)
  {
    // ISSUE: reference to a compiler-generated field
    ScriptInfoEventHandler 퓬퓗 = this.퓬퓗;
    if (퓬퓗 == null)
      return;
    퓬퓗(obj0, new ScriptInfoEventArgs());
  }

  protected virtual void OnScriptUpdated(ScriptInfo scriptInfo)
  {
    // ISSUE: reference to a compiler-generated field
    ScriptInfoEventHandler 퓬픎 = this.퓬픎;
    if (퓬픎 == null)
      return;
    퓬픎(scriptInfo, new ScriptInfoEventArgs());
  }

  private void 퓬([In] ScriptInfo obj0)
  {
    // ISSUE: reference to a compiler-generated field
    ScriptInfoEventHandler 퓬퓠 = this.퓬퓠;
    if (퓬퓠 == null)
      return;
    퓬퓠(obj0, new ScriptInfoEventArgs());
  }

  private void 퓏([In] TScriptInfo obj0, [In] string obj1)
  {
    ScriptKey key = obj0.Key;
    this.scriptsInfoCache.Add(key, obj0);
    List<ScriptKey> scriptKeyList;
    if (!this.퓬퓥.TryGetValue(key.ScriptName, out scriptKeyList))
    {
      scriptKeyList = new List<ScriptKey>();
      this.퓬퓥.Add(key.ScriptName, scriptKeyList);
    }
    scriptKeyList.Add(key);
    List<TScriptInfo> scriptInfoList;
    if (!this.퓬퓯.TryGetValue(obj1, out scriptInfoList))
    {
      scriptInfoList = new List<TScriptInfo>();
      this.퓬퓯.Add(obj1, scriptInfoList);
    }
    scriptInfoList.Add(obj0);
  }

  private void 퓬([In] TScriptInfo obj0, [In] string obj1)
  {
    ScriptKey key = obj0.Key;
    this.scriptsInfoCache.Remove(key);
    List<ScriptKey> scriptKeyList;
    if (this.퓬퓥.TryGetValue(key.ScriptName, out scriptKeyList))
      scriptKeyList.Remove(key);
    List<TScriptInfo> source;
    if (this.퓬퓯.TryGetValue(obj1, out source))
      source.Remove(obj0);
    if (source.Any<TScriptInfo>())
      return;
    this.퓬퓯.Remove(obj1);
  }

  private bool 퓏([In] string obj0, [In] DateTime obj1)
  {
    DateTime dateTime;
    return this.퓬핋.TryGetValue(obj0, out dateTime) && dateTime == obj1;
  }

  private void 퓏([In] string obj0)
  {
    try
    {
      lock (this.퓬퓞)
      {
        DateTime lastWriteTimeUtc = File.GetLastWriteTimeUtc(obj0);
        int num = this.퓏(obj0, lastWriteTimeUtc) ? 1 : 0;
        this.퓬핋[obj0] = lastWriteTimeUtc;
        if (num != 0)
          return;
      }
      string scriptsFolderPath = this.GetScriptsFolderPath(ScriptCreationType.Custom);
      foreach (TypeWrapper typeWrapper in AssemblyLoader.퓏(obj0, typeof (TScript), true, true))
      {
        try
        {
          TScriptInfo scriptInfo = this.CreateScriptInfo(typeWrapper.Type.GetConstructor(Array.Empty<Type>()), ScriptCreationType.Custom, Path.GetDirectoryName(ScriptManager<TScriptInfo, TScript>.퓏(typeWrapper.AssemblyLocation, scriptsFolderPath)), typeWrapper.Type.Assembly.GetName().Name);
          if (!(scriptInfo.Key == new ScriptKey()))
          {
            ScriptKey key = scriptInfo.Key;
            if (this.scriptsInfoCache.ContainsKey(key))
            {
              this.scriptsInfoCache[key] = scriptInfo;
              this.OnScriptUpdated((ScriptInfo) scriptInfo);
            }
            else
            {
              this.퓏(scriptInfo, obj0);
              this.퓏((ScriptInfo) scriptInfo);
            }
          }
        }
        catch (Exception ex)
        {
          Core.Instance.Loggers.Log(ex);
        }
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  private static bool 퓬([In] string obj0)
  {
    return !Path.HasExtension(obj0) || Path.GetExtension(obj0) != \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픰();
  }

  public static string MakeRelativePath(string fromPath, string toPath)
  {
    if (string.IsNullOrEmpty(fromPath))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬퓢());
    if (string.IsNullOrEmpty(toPath))
      throw new ArgumentNullException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픫());
    Uri uri1 = new Uri(fromPath);
    Uri uri2 = new Uri(toPath);
    if (uri1.Scheme != uri2.Scheme)
      return toPath;
    string str = Uri.UnescapeDataString(uri1.MakeRelativeUri(uri2).ToString());
    if (uri2.Scheme.Equals(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓬픯(), StringComparison.InvariantCultureIgnoreCase))
      str = str.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
    return str;
  }
}
