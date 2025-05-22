// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.GlobalVariables.GlobalVariablesManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TradingPlatform.BusinessLayer.Utils;

#nullable disable
namespace TradingPlatform.BusinessLayer.GlobalVariables;

[Obsolete("Should be removed at future releases")]
public static class GlobalVariablesManager
{
  private const string 핇픦 = "GlobalVariables.dat";
  private const int 핇픍 = 100000;
  private static readonly ConcurrentDictionary<string, 퓏.퓑> 핇픆 = new ConcurrentDictionary<string, 퓏.퓑>();

  static GlobalVariablesManager() => GlobalVariablesManager.퓏();

  /// <summary>Sets variable value to a global storage</summary>
  /// <example>
  ///  <span id="Example 1">
  ///  <code>
  /// using System;
  /// using System.Text;
  /// using PTLRuntime.NETScript;
  /// 
  /// namespace GlobalVariablesManager
  /// {
  ///      public class GlobalVariablesManager : NETIndicator
  ///      {
  ///          GlobalVariablesManager(){
  ///               base.ProjectName = "GlobalVariablesManager";
  ///               base.Password=GetHashedPassword(ProjectName);
  ///          }
  /// 
  ///         [InputParameter("Period", 0, 1, 9999)]
  ///          public int period = 5;
  /// 
  ///          public override void OnQuote()
  ///          {
  ///               //Simplified way to store a global variable
  /// 
  ///               GlobalVariablesManager.SetValue("global_variable_period", period, VariableLifetime.SaveSession);
  /// 
  ///               //However, to indicate any variable belongs to certain indicator/strategy and to avoid unexpected erasing of data the best practice is to provide to a key holder multiple details such as name, params, hashed password etc.
  /// 
  ///               GlobalVariablesManager.SetValue("global_variable_period" +Symbols.Current.Name+period+Password, period, VariableLifetime.SaveSession);
  ///          }
  ///      }
  /// }
  ///  </code>
  ///  </span>
  ///  </example>
  /// <param name="name">Variable name</param>
  /// <param name="value">New value</param>
  /// <param name="lifetime">Variable lifetime</param>
  public static void SetValue(string name, object value, VariableLifetime lifetime = VariableLifetime.SaveSession)
  {
    if (!GlobalVariablesManager.퓏(value))
      throw new NonSerializableObjectException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픛());
    if (!GlobalVariablesManager.핇픆.TryGetValue(name, out 퓏.퓑 _))
    {
      GlobalVariable globalVariable = new GlobalVariable(name, value);
      GlobalVariablesManager.핇픆.TryAdd(name, new 퓏.퓑(globalVariable));
    }
    GlobalVariablesManager.핇픆[name].Lifetime = lifetime;
    퓏.핋 핋 = GlobalVariablesManager.퓏(value, lifetime == VariableLifetime.SaveFile);
    GlobalVariablesManager.핇픆[name].Variable.Value = 핋.핇픱;
    GlobalVariablesManager.핇픆[name].ObjectBytes = 핋.핇픕;
  }

  /// <summary>Removes specified variable from global storage</summary>
  /// <example>
  ///  <span id="Example 1">
  ///  <code>
  /// using System;
  /// using System.Text;
  /// using PTLRuntime.NETScript;
  /// 
  /// namespace GlobalVariablesManager
  /// {
  ///      public class GlobalVariablesManager : NETIndicator
  ///      {
  ///          public override void Init()
  ///          {
  ///               //Simplified way to remove a global variable
  /// 
  ///               GlobalVariablesManager.Remove("global_variable_period");
  /// 
  ///               //However, to remove certain variable, which belongs to indicator/strategy and to avoid unexpected erasing of data the best practice is to provide to a key holder multiple details such as name, params, hashed password etc. Follow SetValue() example.
  ///          }
  ///      }
  /// }
  ///  </code>
  ///  </span>
  ///  </example>
  /// <param name="name">Variable name</param>
  public static bool Remove(string name) => GlobalVariablesManager.핇픆.TryRemove(name, out 퓏.퓑 _);

  /// <summary>Returns variables' count in global storage</summary>
  /// <example>
  ///  <span id="Example 1">
  ///  <code>
  /// using System;
  /// using System.Text;
  /// using PTLRuntime.NETScript;
  /// 
  /// namespace GlobalVariablesManager
  /// {
  ///      public class GlobalVariablesManager : NETIndicator
  ///      {
  ///          public override void Init()
  ///          {
  ///              if(GlobalVariablesManager.Count()&gt;0)
  ///              {
  ///                  Print("Your session obtains "+GlobalVariablesManager.Count()+" global variables");
  ///              }
  ///          }
  ///      }
  /// }
  ///  </code>
  ///  </span>
  ///  </example>
  /// <returns></returns>
  public static int Count() => GlobalVariablesManager.핇픆.Count;

  /// <summary>Removes all variables from global storage</summary>
  /// <example>
  ///  <span id="Example 1">
  ///  <code>
  /// using System;
  /// using System.Text;
  /// using PTLRuntime.NETScript;
  /// 
  /// namespace GlobalVariablesManager
  /// {
  ///      public class GlobalVariablesManager : NETIndicator
  ///      {
  ///          public override void Init()
  ///          {
  ///              GlobalVariablesManager.RemoveAll();
  /// 
  ///              if(GlobalVariablesManager.Count()==0)
  ///              {
  ///                  Print("Your session does not have any global variables");
  ///              }
  ///          }
  ///      }
  /// }
  ///  </code>
  ///  </span>
  ///  </example>
  public static void RemoveAll() => GlobalVariablesManager.핇픆.Clear();

  /// <summary>
  /// Check if variable with specified name exists in global storage
  /// </summary>
  /// <example>
  ///  <span id="Example 1">
  ///  <code>
  /// using System;
  /// using System.Text;
  /// using PTLRuntime.NETScript;
  /// 
  /// namespace GlobalVariablesManager
  /// {
  ///      public class GlobalVariablesManager : NETIndicator
  ///      {
  ///          public override void Init()
  ///          {
  ///               //Simplified way to check an existance of a global variable
  /// 
  ///               if(GlobalVariablesManager.Exists("global_variable_period"))
  ///                  Print("Your session has this global variable");
  ///               else
  ///                  GlobalVariablesManager.SetValue("global_variable_period");
  /// 
  ///               //However, to obtain certain variable, which belongs to indicator/strategy and to avoid unexpected erasing of data the best practice is to provide to a key holder multiple details such as name, params, hashed password etc. Follow SetValue() example.
  ///          }
  ///      }
  /// }
  ///  </code>
  ///  </span>
  ///  </example>
  /// <param name="name">Variable name</param>
  /// <returns></returns>
  public static bool Exists(string name) => GlobalVariablesManager.핇픆.ContainsKey(name);

  /// <summary>Returns variable value by name</summary>
  /// <example>
  ///  <span id="Example 1">
  ///  <code>
  /// using System;
  /// using System.Text;
  /// using PTLRuntime.NETScript;
  /// 
  /// namespace GlobalVariablesManager
  /// {
  ///      public class GlobalVariablesManager : NETIndicator
  ///      {
  ///          public override void Init()
  ///          {
  ///              //Simplified way to retrieve global variable value
  /// 
  ///               if(GlobalVariablesManager.Exists("global_variable_period"))
  ///                  //Always perform a type casting before assigning any variable from global storage
  ///                  period = (int)GlobalVariablesManager.GetValue("global_variable_period");
  /// 
  ///              //However, to obtain certain variable, which belongs to indicator/strategy and to avoid unexpected erasing of data the best practice is to provide to a key holder multiple details such as name, params, hashed password etc. Follow SetValue() example.
  ///          }
  ///      }
  /// }
  ///  </code>
  ///  </span>
  ///  </example>
  /// <param name="name">Variable name</param>
  /// <returns>Variable value</returns>
  public static object GetValue(string name)
  {
    퓏.퓑 퓑;
    if (!GlobalVariablesManager.핇픆.TryGetValue(name, out 퓑))
      throw new VariableNotExistsException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓜(), name);
    return 퓑.Variable.Value;
  }

  /// <summary>
  /// Performs a variable assigning from a global storage if such name exists in a scope
  /// </summary>
  /// <example>
  ///  <span id="Example 1">
  ///  <code>
  /// using System;
  /// using System.Text;
  /// using PTLRuntime.NETScript;
  /// 
  /// namespace GlobalVariablesManager
  /// {
  ///      public class GlobalVariablesManager : NETIndicator
  ///      {
  ///          public override void Init()
  ///          {
  ///               int new_period;
  /// 
  ///               //Simplified way to retrieve global variable value
  /// 
  ///               if(GlobalVariablesManager.TryGetValue("global_variable_period"))
  ///                  Print("New variable is assigned from globals: " + new_period);
  ///               if(new_period==period)
  ///                  Print("Matching, no need to re-assign globals: ");
  ///               else
  ///                  GlobalVariablesManager.SetValue("global_variable_period", period, VariableLifetime.SaveSession);
  /// 
  ///               //However, to obtain certain variable, which belongs to indicator/strategy and to avoid unexpected erasing of data the best practice is to provide to a key holder multiple details such as name, params, hashed password etc. Follow SetValue() example.
  ///          }
  ///      }
  /// }
  ///  </code>
  ///  </span>
  ///  </example>
  /// <param name="name">Variable name</param>
  /// <param name="obj">Variable value</param>
  /// <returns>True if variable exists</returns>
  public static bool TryGetValue(string name, out object obj)
  {
    퓏.퓑 퓑;
    if (GlobalVariablesManager.핇픆.TryGetValue(name, out 퓑))
    {
      obj = 퓑.Variable.Value;
      return true;
    }
    obj = (object) null;
    return false;
  }

  /// <summary>Saves all serializable variables to disk</summary>
  /// <example>
  ///  <span id="Example 1">
  ///  <code>
  /// using System;
  /// using System.Text;
  /// using PTLRuntime.NETScript;
  /// 
  /// namespace GlobalVariablesManager
  /// {
  ///      public class GlobalVariablesManager : NETIndicator
  ///      {
  ///          Connection myConnection = Connection.CurrentConnection;
  ///          public override void OnQuote()
  ///          {
  ///               if(myConnection.Status==Disconnected)
  ///                  GlobalVariablesManager.Flush();
  ///          }
  ///      }
  /// }
  ///  </code>
  ///  </span>
  ///  </example>
  public static void Flush()
  {
    try
    {
      XmlDocument xmlDocument = new XmlDocument();
      XmlElement element1 = xmlDocument.CreateElement(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픺());
      foreach (KeyValuePair<string, 퓏.퓑> keyValuePair in GlobalVariablesManager.핇픆)
      {
        퓏.퓑 퓑 = keyValuePair.Value;
        if (퓑.Lifetime == VariableLifetime.SaveFile)
        {
          XmlElement element2 = xmlDocument.CreateElement(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핃());
          element2.SetAttribute(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓫(), 퓑.Variable.Name);
          element2.SetAttribute(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핌(), GlobalVariablesManager.퓏(퓑.ObjectBytes));
          element2.SetAttribute(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓩(), (퓑.Variable.Value == null).ToString());
          element1.AppendChild((XmlNode) element2);
        }
      }
      xmlDocument.AppendChild((XmlNode) element1);
      using (XmlTextWriter w = new XmlTextWriter(GlobalVariablesManager.PathToGlobalVariablesFile, Encoding.UTF8))
      {
        w.Formatting = Formatting.Indented;
        xmlDocument.WriteContentTo((XmlWriter) w);
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  /// <summary>Returns all global variables as list</summary>
  /// <example>
  ///  <span id="Example 1">
  ///  <code>
  /// using System;
  /// using System.Text;
  /// using PTLRuntime.NETScript;
  /// 
  /// namespace GlobalVariablesManager
  /// {
  ///      public class GlobalVariablesManager : NETIndicator
  ///      {
  ///          List &lt;GlobalVariable&gt;global_List=new List&lt;GlobalVariable&gt;();
  ///          public override void Init()
  ///          {
  ///               if(GlobalVariablesManager.Count()&gt;0)
  ///                  global_List=GlobalVariablesManager.GetGlobalVariablesList();
  /// 
  ///               foreach (var el in global_List)
  ///               {
  ///                  Print(el.Name);
  ///               }
  ///          }
  ///      }
  /// }
  ///  </code>
  ///  </span>
  ///  </example>
  /// <returns>Collection of global variables</returns>
  public static List<GlobalVariable> GetGlobalVariablesList()
  {
    return GlobalVariablesManager.핇픆.Values.Select<퓏.퓑, GlobalVariable>((Func<퓏.퓑, GlobalVariable>) (([In] obj0) => obj0.Variable)).ToList<GlobalVariable>();
  }

  private static string PathToGlobalVariablesFile
  {
    get
    {
      return Path.Combine(Const.EXECUTING_FOLDER, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓨());
    }
  }

  private static void 퓏()
  {
    try
    {
      if (!File.Exists(GlobalVariablesManager.PathToGlobalVariablesFile))
        return;
      using (XmlReader reader = XmlReader.Create(GlobalVariablesManager.PathToGlobalVariablesFile))
      {
        int content = (int) reader.MoveToContent();
        reader.Read();
        while (!reader.EOF && reader.ReadState == ReadState.Interactive)
        {
          if (reader.NodeType == XmlNodeType.Element)
          {
            if (reader.Name.Equals(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핃()))
            {
              try
              {
                if (XNode.ReadFrom(reader) is XElement xelement)
                {
                  string name = xelement.Attribute((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓫()).Value;
                  string str = xelement.Attribute((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓩()).Value;
                  if (str != null && str.Equals(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓱()))
                  {
                    GlobalVariablesManager.SetValue(name, (object) null, VariableLifetime.SaveFile);
                    continue;
                  }
                  byte[] buffer = Convert.FromBase64String(xelement.Attribute((XName) \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇핌()).Value);
                  using (MemoryStream serializationStream = new MemoryStream())
                  {
                    serializationStream.Write(buffer, 0, buffer.Length);
                    serializationStream.Position = 0L;
                    object obj = new BinaryFormatter().Deserialize((Stream) serializationStream);
                    GlobalVariablesManager.SetValue(name, obj, VariableLifetime.SaveFile);
                    continue;
                  }
                }
                continue;
              }
              catch (Exception ex)
              {
                Core.Instance.Loggers.Log(ex);
                continue;
              }
            }
          }
          reader.Read();
        }
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  private static bool 퓏([In] object obj0)
  {
    return obj0 == null || obj0 is ISerializable || Attribute.IsDefined((MemberInfo) obj0.GetType(), typeof (SerializableAttribute));
  }

  private static 퓏.핋 퓏([In] object obj0, [In] bool obj1)
  {
    퓏.핋 핋 = new 퓏.핋();
    if (obj0 == null)
      return 핋;
    using (MemoryStream serializationStream = new MemoryStream())
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      binaryFormatter.Serialize((Stream) serializationStream, obj0);
      long length = serializationStream.Length;
      if (obj1 && length > 100000L)
        throw new TooBigObjectException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픹());
      serializationStream.Position = 0L;
      byte[] buffer = new byte[serializationStream.Length];
      serializationStream.Read(buffer, 0, (int) serializationStream.Length);
      serializationStream.Position = 0L;
      object obj = binaryFormatter.Deserialize((Stream) serializationStream);
      핋.핇픕 = buffer;
      핋.핇픱 = obj;
      return 핋;
    }
  }

  private static string 퓏([In] byte[] obj0)
  {
    return Convert.ToBase64String(obj0, Base64FormattingOptions.None);
  }
}
