// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.Licence.LicencesManager
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using IdentityModel.Client;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using IdentityModel.OidcClient.Results;
using Platform.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using 퓏;

#nullable enable
namespace TradingPlatform.BusinessLayer.Licence;

/// <summary>User licences info store</summary>
public sealed class LicencesManager : IDisposable, ICustomizable
{
  private const 
  #nullable disable
  string 픣퓥 = "https://gateway.accounts.quantower.com/";
  private const string 픣퓯 = "refresh_token";
  private ConnectionState 픣퓞;
  private IDictionary<string, LicenceItem> 픣퓳;
  private HttpClient 픣핆;
  private HttpClient 픣픷;
  private Timer 픣퓻;
  private string 픣픸;
  private string 픣프;
  private string 픣픴;
  private string 픣픑;
  private LicenceItem 픣픿;
  private LicenceItem 픣퓔;
  private LicenceItem 픣픢;
  private LicenceItem 픣퓝;
  private LicenceItem 픣퓶;
  private LicenceItem 픣퓽;
  private LicenceItem 픣픘;
  private LicenceItem 픣픨;
  private LicenceItem 픣퓪;

  public event EventHandler<LicenseManagerEventArgs> StateChanged;

  public event Action LicenceRulesUpdated;

  public event Action<string, string> LicenceCheckError;

  /// <summary>Current state of connection to licence server</summary>
  public ConnectionState State
  {
    get => this.픣퓞;
    [param: In] private set
    {
      if (this.픣퓞 == value)
        return;
      LicenseManagerEventArgs managerEventArgs = new LicenseManagerEventArgs(this.픣퓞, value);
      this.픣퓞 = value;
      EventHandler<LicenseManagerEventArgs> 픣픜 = this.픣픜;
      if (픣픜 == null)
        return;
      픣픜.InvokeSafely((object) this, (object) managerEventArgs);
    }
  }

  public string LastErrorText { get; [param: In] private set; }

  /// <summary>Current connected user info</summary>
  public UserInfo CurrentUser { get; [param: In] private set; }

  public string AccessToken { get; [param: In] private set; }

  public IList<SettingItem> Settings
  {
    get
    {
      return (IList<SettingItem>) new List<SettingItem>()
      {
        (SettingItem) new SettingItemPassword(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핋(), new PasswordHolder(this.픣픴, recoverUrl: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥()))
      };
    }
    set
    {
      foreach (SettingItem settingItem in (IEnumerable<SettingItem>) value)
      {
        if (settingItem.Name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁핋())
        {
          Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픊(), LoggingLevel.Verbose);
          string password = settingItem.Value is PasswordHolder passwordHolder1 ? passwordHolder1.Password : (string) null;
          this.픣픴 = password;
          if (!string.IsNullOrEmpty(password))
            Task.Factory.StartNew((Action) (() =>
            {
              if (this.State != ConnectionState.Disconnected || string.IsNullOrEmpty(this.픣픴))
                return;
              this.State = ConnectionState.Connecting;
              this.퓲();
            })).Wait();
          else if (settingItem.Value is PasswordHolder passwordHolder2 && passwordHolder2.FailedToRestorePassword)
          {
            this.LastErrorText = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픈();
            Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓒(), LoggingLevel.Error);
            this.State = ConnectionState.Disconnected;
          }
          Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓚(), LoggingLevel.Verbose);
        }
      }
    }
  }

  /// <summary>All active licences that user have</summary>
  public IEnumerable<LicenceItem> AllLicenceItems => (IEnumerable<LicenceItem>) this.픣퓳.Values;

  internal LicencesManager()
  {
    this.픣퓞 = ConnectionState.Disconnected;
    this.픣픿 = new LicenceItem()
    {
      LicenceKey = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓠(),
      StartDate = DateTime.UtcNow.AddDays(-10.0),
      EndDate = DateTime.UtcNow.AddYears(100)
    };
    this.픣퓔 = new LicenceItem()
    {
      LicenceKey = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓓(),
      StartDate = DateTime.UtcNow.AddDays(-10.0),
      EndDate = DateTime.UtcNow.AddYears(100)
    };
    this.픣픢 = new LicenceItem()
    {
      LicenceKey = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픕(),
      StartDate = DateTime.UtcNow.AddDays(-10.0),
      EndDate = DateTime.UtcNow.AddYears(100)
    };
    this.픣퓝 = new LicenceItem()
    {
      LicenceKey = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓰(),
      StartDate = DateTime.UtcNow.AddDays(-10.0),
      EndDate = DateTime.UtcNow.AddYears(100)
    };
    this.픣퓶 = new LicenceItem()
    {
      LicenceKey = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲픗(),
      StartDate = DateTime.UtcNow.AddDays(-10.0),
      EndDate = DateTime.UtcNow.AddYears(100)
    };
    this.픣퓽 = new LicenceItem()
    {
      LicenceKey = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓹(),
      StartDate = DateTime.UtcNow.AddDays(-10.0),
      EndDate = DateTime.UtcNow.AddYears(100)
    };
    this.픣픘 = new LicenceItem()
    {
      LicenceKey = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픠(),
      StartDate = DateTime.UtcNow.AddDays(-10.0),
      EndDate = DateTime.UtcNow.AddYears(100)
    };
    this.픣픨 = new LicenceItem()
    {
      LicenceKey = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓡(),
      StartDate = DateTime.UtcNow.AddDays(-10.0),
      EndDate = DateTime.UtcNow.AddYears(100)
    };
    this.픣퓪 = new LicenceItem()
    {
      LicenceKey = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇퓮(),
      StartDate = DateTime.UtcNow.AddDays(-10.0),
      EndDate = DateTime.UtcNow.AddYears(100)
    };
  }

  internal void 퓏()
  {
    this.픣퓳 = (IDictionary<string, LicenceItem>) new ReadOnlyDictionary<string, LicenceItem>((IDictionary<string, LicenceItem>) new Dictionary<string, LicenceItem>());
    this.픣핆 = new HttpClient((HttpMessageHandler) new HttpClientHandler()
    {
      ServerCertificateCustomValidationCallback = new Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool>(this.퓏)
    });
    this.픣픷 = new HttpClient((HttpMessageHandler) new HttpClientHandler()
    {
      ServerCertificateCustomValidationCallback = new Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool>(this.퓏)
    });
  }

  public void Dispose()
  {
    this.퓍();
    if (this.픣핆 != null)
    {
      this.픣핆.Dispose();
      this.픣핆 = (HttpClient) null;
    }
    if (this.픣픷 == null)
      return;
    this.픣픷.Dispose();
    this.픣픷 = (HttpClient) null;
  }

  public void ConnectToAuthServer()
  {
    if (this.State != ConnectionState.Disconnected)
      return;
    this.LastErrorText = (string) null;
    try
    {
      this.픣픸 = this.핂();
      if (string.IsNullOrEmpty(this.픣픸))
        throw new Exception(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픃());
      this.AccessToken = string.Empty;
      this.픣픴 = string.Empty;
      this.픣픑 = string.Empty;
      IdentityModel.OidcClient.OidcClient oidcClient = this.픞();
      LoginRequest request = new LoginRequest()
      {
        BrowserDisplayMode = DisplayMode.Visible,
        BrowserTimeout = 300
      };
      LoginResult result1 = oidcClient.LoginAsync(request).Result;
      this.State = ConnectionState.Connecting;
      this.AccessToken = result1.AccessToken;
      this.픣픴 = result1.RefreshToken;
      this.픣픑 = result1.IdentityToken;
      if (result1.IsError)
      {
        Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓎() + result1.Error, LoggingLevel.Error);
        this.State = ConnectionState.Disconnected;
      }
      else
      {
        UserInfoResult result2 = oidcClient.GetUserInfoAsync(this.AccessToken).Result;
        if (result2.IsError)
          Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁피() + result2.Error, LoggingLevel.Error);
        else
          this.CurrentUser = new UserInfo(result2.Claims);
        this.픣프 = this.픂();
        if (string.IsNullOrEmpty(this.픣프))
          throw new Exception(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓸());
        this.핇();
        this.퓬();
        this.State = ConnectionState.Connected;
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
      this.LastErrorText = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓦() + ex.Message;
      this.State = ConnectionState.Disconnected;
    }
  }

  public void Disconnect()
  {
    if (this.State != ConnectionState.Connected)
      return;
    this.State = ConnectionState.Disconnecting;
    try
    {
      this.픞().LogoutAsync(new LogoutRequest()
      {
        IdTokenHint = this.픣픑
      }).Wait();
      this.퓍();
      this.픣픴 = (string) null;
      this.LastErrorText = (string) null;
      this.State = ConnectionState.Disconnected;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
      this.State = ConnectionState.Disconnected;
    }
  }

  /// <summary>Check that user have licence</summary>
  public LicenceItem GetLicenceRuleItem(string itemKey)
  {
    if (Encryptor.UnicDeviceId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픋() || Encryptor.UnicDeviceId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핀() || Encryptor.UnicDeviceId == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픲())
      return this.픣픿;
    LicenceItem licenceRuleItem;
    this.픣퓳.TryGetValue(itemKey, out licenceRuleItem);
    return licenceRuleItem;
  }

  public void OnLicenceCheckError(string errorText, string licenceItemKey)
  {
    // ISSUE: reference to a compiler-generated field
    this.픣핋.InvokeSafely((object) errorText, (object) licenceItemKey);
  }

  private void 퓬()
  {
    if (this.픣퓻 != null)
      return;
    this.픣퓻 = new Timer(new TimerCallback(this.퓏));
    this.픣퓻.Change(TimeSpan.Zero, TimeSpan.FromMinutes(2.0));
  }

  private void 퓏([In] object obj0)
  {
    try
    {
      this.핇();
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex);
    }
  }

  private void 핇()
  {
    ImmutableDictionary<string, LicenceItem> immutableDictionary = this.픾().Where<LicenceItem>((Func<LicenceItem, bool>) (([In] obj0) => obj0.LicenceKey != \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓗픙())).ToImmutableDictionary<LicenceItem, string>((Func<LicenceItem, string>) (([In] obj0) => obj0.LicenceKey));
    if (!LicencesManager.퓏(this.픣퓳, (IDictionary<string, LicenceItem>) immutableDictionary))
      return;
    this.픣퓳 = (IDictionary<string, LicenceItem>) new ReadOnlyDictionary<string, LicenceItem>((IDictionary<string, LicenceItem>) immutableDictionary);
    // ISSUE: reference to a compiler-generated field
    Action 픣퓑 = this.픣퓑;
    if (픣퓑 == null)
      return;
    픣퓑();
  }

  private void 퓲()
  {
    this.LastErrorText = (string) null;
    try
    {
      this.AccessToken = string.Empty;
      this.픣픑 = string.Empty;
      this.픣픸 = this.핂();
      IdentityModel.OidcClient.OidcClient oidcClient = this.픞();
      RefreshTokenResult result1 = oidcClient.RefreshTokenAsync(this.픣픴).Result;
      if (result1.IsError)
      {
        this.LastErrorText = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픈();
        Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픽() + result1.Error, LoggingLevel.Error);
        this.퓍();
        this.State = ConnectionState.Disconnected;
      }
      else
      {
        this.AccessToken = result1.AccessToken;
        this.픣픴 = result1.RefreshToken;
        this.픣픑 = result1.IdentityToken;
        UserInfoResult result2 = oidcClient.GetUserInfoAsync(this.AccessToken).Result;
        if (result2.IsError)
          Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁피() + result2.Error, LoggingLevel.Error);
        else
          this.CurrentUser = new UserInfo(result2.Claims);
        this.픣프 = this.픂();
        this.핇();
        this.퓬();
        this.State = ConnectionState.Connected;
      }
    }
    catch (Exception ex)
    {
      WebException webException = ex.GetInnerExceptionsRecursive().OfType<WebException>().FirstOrDefault<WebException>();
      if (webException != null && webException.Status == WebExceptionStatus.ConnectFailure)
        Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓏());
      else
        this.퓍();
      this.LastErrorText = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓬() + ex.Message;
      Core.Instance.Loggers.Log(ex);
      this.State = ConnectionState.Disconnected;
    }
  }

  private string 핂()
  {
    try
    {
      UriBuilder uriBuilder = new UriBuilder(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핇())
      {
        Path = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓲()
      };
      if (((IEnumerable<IPAddress>) Dns.GetHostAddresses(uriBuilder.Host)).Contains<IPAddress>(IPAddress.Loopback))
        throw new Exception(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핂());
      HttpResponseMessage result1 = this.픣핆.GetAsync(uriBuilder.Uri).Result;
      if (result1.IsSuccessStatusCode)
      {
        픷<string> result2 = result1.Content.ReadFromJsonAsync<픷<string>>().Result;
        if (result2.IsSuccess)
          return result2.Value;
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, loggingLevel: LoggingLevel.Verbose);
    }
    return (string) null;
  }

  private string 픂()
  {
    try
    {
      UriBuilder uriBuilder = new UriBuilder(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핇())
      {
        Path = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픂()
      };
      if (((IEnumerable<IPAddress>) Dns.GetHostAddresses(uriBuilder.Host)).Contains<IPAddress>(IPAddress.Loopback))
        throw new Exception(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픾());
      HttpResponseMessage result1 = this.픣핆.GetAsync(uriBuilder.Uri).Result;
      if (result1.IsSuccessStatusCode)
      {
        픷<Dictionary<string, string>> result2 = result1.Content.ReadFromJsonAsync<픷<Dictionary<string, string>>>().Result;
        string str;
        return !result2.IsSuccess || !result2.Value.TryGetValue(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓍(), out str) ? (string) null : str;
      }
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, loggingLevel: LoggingLevel.Verbose);
    }
    return (string) null;
  }

  private IEnumerable<LicenceItem> 픾()
  {
    try
    {
      UriBuilder uriBuilder = new UriBuilder(this.픣프)
      {
        Path = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픁()
      };
      if (((IEnumerable<IPAddress>) Dns.GetHostAddresses(uriBuilder.Host)).Contains<IPAddress>(IPAddress.Loopback))
        throw new Exception(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픞());
      this.픣픷.SetBearerToken(this.AccessToken);
      HttpResponseMessage result1 = this.픣픷.GetAsync(uriBuilder.Uri).Result;
      if (result1.IsSuccessStatusCode)
      {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.Converters.Add((JsonConverter) new 퓏.핆());
        return (IEnumerable<LicenceItem>) result1.Content.ReadFromJsonAsync<LicenceItem[]>(options).Result;
      }
      if (result1.StatusCode == HttpStatusCode.Unauthorized)
      {
        HttpResponseMessage result2 = this.픣핆.GetAsync(new UriBuilder(this.픣픸)
        {
          Path = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핁()
        }.Uri).Result;
        if (!result2.IsSuccessStatusCode)
        {
          DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
          interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픇());
          interpolatedStringHandler.AppendFormatted<HttpStatusCode>(result2.StatusCode);
          throw new Exception(interpolatedStringHandler.ToStringAndClear());
        }
        Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픣());
        if (this.State == ConnectionState.Connected)
        {
          this.픁();
          this.퓲();
        }
      }
      else if (result1.StatusCode == HttpStatusCode.NotFound)
        throw new Exception(HttpStatusCode.NotFound.ToString());
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓙() + ex.Message, LoggingLevel.Error);
    }
    IDictionary<string, LicenceItem> 픣퓳 = this.픣퓳;
    return (픣퓳 != null ? (IEnumerable<LicenceItem>) 픣퓳.Values.Where<LicenceItem>((Func<LicenceItem, bool>) (([In] obj0) => obj0.EndDate >= Core.Instance.TimeUtils.DateTimeUtcNow)).ToArray<LicenceItem>() : (IEnumerable<LicenceItem>) (LicenceItem[]) null) ?? (IEnumerable<LicenceItem>) Array.Empty<LicenceItem>();
  }

  private void 퓍()
  {
    this.AccessToken = (string) null;
    this.CurrentUser = (UserInfo) null;
    this.픣퓳 = (IDictionary<string, LicenceItem>) new ReadOnlyDictionary<string, LicenceItem>((IDictionary<string, LicenceItem>) new Dictionary<string, LicenceItem>());
    // ISSUE: reference to a compiler-generated field
    Action 픣퓑 = this.픣퓑;
    if (픣퓑 != null)
      픣퓑();
    this.픁();
  }

  private void 픁()
  {
    if (this.픣퓻 == null)
      return;
    this.픣퓻.Dispose();
    this.픣퓻 = (Timer) null;
  }

  private IdentityModel.OidcClient.OidcClient 픞()
  {
    int num = 55650;
    try
    {
      num = TcpIpHelper.GetRandomUnusedPort;
    }
    catch (Exception ex)
    {
      Core.Instance.Loggers.Log(ex, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓠());
    }
    LoggerManager loggers = Core.Instance.Loggers;
    DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(31 /*0x1F*/, 1);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓗());
    interpolatedStringHandler.AppendFormatted<int>(num);
    string stringAndClear1 = interpolatedStringHandler.ToStringAndClear();
    loggers.Log(stringAndClear1, LoggingLevel.Verbose);
    interpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
    interpolatedStringHandler.AppendLiteral(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픁퓥());
    interpolatedStringHandler.AppendFormatted<int>(num);
    string stringAndClear2 = interpolatedStringHandler.ToStringAndClear();
    string[] strArray = new string[5]
    {
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픎(),
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓠(),
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓲퓖(),
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓥(),
      \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓯()
    };
    return new IdentityModel.OidcClient.OidcClient(new OidcClientOptions()
    {
      Authority = this.픣픸,
      ClientId = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇픜(),
      ClientSecret = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇퓑(),
      RedirectUri = stringAndClear2,
      PostLogoutRedirectUri = stringAndClear2,
      Scope = string.Join(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇프(), strArray),
      Browser = (IBrowser) new 퓏.퓻(false, new int?(num))
      {
        퓲픶 = Core.Instance.OAuthBrowserCreator
      },
      ClockSkew = TimeSpan.FromMinutes(5.0) + (Core.Instance.TimeUtils.DateTimeUtcNow - DateTime.UtcNow).Duration()
    });
  }

  private bool 퓏(
    [In] HttpRequestMessage obj0,
    [In] X509Certificate2 obj1,
    [In] X509Chain obj2,
    [In] SslPolicyErrors obj3)
  {
    if (!(obj1.Issuer == obj1.Subject))
      return obj3 == SslPolicyErrors.None;
    Core.Instance.Loggers.Log(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픇핋(), LoggingLevel.Verbose);
    return false;
  }

  private static bool 퓏(
    [In] IDictionary<string, LicenceItem> obj0,
    [In] IDictionary<string, LicenceItem> obj1)
  {
    if (obj0.Count != obj1.Count)
      return true;
    foreach (string key in (IEnumerable<string>) obj0.Keys)
    {
      LicenceItem licenceItem1;
      LicenceItem licenceItem2;
      if (!obj0.TryGetValue(key, out licenceItem1) || !obj1.TryGetValue(key, out licenceItem2) || licenceItem1.StartDate != licenceItem2.StartDate || licenceItem1.EndDate != licenceItem2.EndDate || licenceItem1.Value != licenceItem2.Value)
        return true;
    }
    return false;
  }
}
