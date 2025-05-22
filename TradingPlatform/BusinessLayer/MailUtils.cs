// Decompiled with JetBrains decompiler
// Type: TradingPlatform.BusinessLayer.MailUtils
// Assembly: TradingPlatform.BusinessLayer, Version=1.142.20.0, Culture=neutral, PublicKeyToken=null
// MVID: FCE39EF5-70B0-4A01-B15C-1BAA5F852BD2
// Assembly location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.dll
// XML documentation location: C:\Users\willi\Desktop\Quantower\TradingPlatform\v1.142.20\bin\TradingPlatform.BusinessLayer.xml

using \u003CPrivateImplementationDetails\u003E\u007B36B4871F\u002D2D92\u002D4DBB\u002DA9AF\u002D52BA9631B7AF\u007D;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace TradingPlatform.BusinessLayer;

public class MailUtils : ICustomizable
{
  public bool MailUseSSLConnection { get; [param: In] private set; }

  public string MailLogin { get; [param: In] private set; }

  public string MailPassword { get; [param: In] private set; }

  public int MailSMTPServerTimeout { get; [param: In] private set; }

  public string MailSMTPServer { get; [param: In] private set; }

  public int MailSMTPPort { get; [param: In] private set; }

  private void 퓏([In] EmailParameters obj0)
  {
    EmailSendCompletedResult result = new EmailSendCompletedResult();
    MailMessage message = new MailMessage();
    SmtpClient smtpClient = (SmtpClient) null;
    try
    {
      message.From = !string.IsNullOrEmpty(this.MailLogin) ? new MailAddress(this.MailLogin) : throw new ArgumentException(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픹());
      message.Subject = obj0.subject;
      if (obj0.address != null)
      {
        foreach (string addresses in obj0.address)
          message.To.Add(addresses);
      }
      AlternateView alternateViewFromString1 = AlternateView.CreateAlternateViewFromString(obj0.text, (Encoding) null, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓺());
      string content1 = obj0.text;
      if (content1 != null)
        content1 = content1.Replace(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핇픭(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픊()).Replace(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픈(), \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픊());
      if (obj0.fileNames != null)
      {
        if (!obj0.asFile)
        {
          string content2 = content1 + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓒();
          for (int index = 0; index < obj0.fileNames.Length; ++index)
            content2 = content2 + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓚() + index.ToString() + \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픃();
          AlternateView alternateViewFromString2 = AlternateView.CreateAlternateViewFromString(content2, (Encoding) null, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓎());
          for (int index = 0; index < obj0.fileNames.Length; ++index)
          {
            if (obj0.fileNames[index] != null)
            {
              LinkedResource linkedResource = new LinkedResource(obj0.fileNames[index]);
              linkedResource.ContentId = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞피() + index.ToString();
              alternateViewFromString2.LinkedResources.Add(linkedResource);
            }
          }
          message.AlternateViews.Add(alternateViewFromString1);
          message.AlternateViews.Add(alternateViewFromString2);
        }
        else
        {
          message.AlternateViews.Add(alternateViewFromString1);
          foreach (string fileName in obj0.fileNames)
            message.Attachments.Add(new Attachment(fileName));
        }
      }
      else
      {
        AlternateView alternateViewFromString3 = AlternateView.CreateAlternateViewFromString(content1, (Encoding) null, \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓎());
        message.AlternateViews.Add(alternateViewFromString1);
        message.AlternateViews.Add(alternateViewFromString3);
      }
      smtpClient = new SmtpClient(this.MailSMTPServer)
      {
        Credentials = (ICredentialsByHost) new NetworkCredential(message.From.Address, this.MailPassword),
        EnableSsl = this.MailUseSSLConnection,
        Port = this.MailSMTPPort,
        Timeout = this.MailSMTPServerTimeout
      };
      smtpClient.Send(message);
      result.Status = EmailSendCompletedStatus.Success;
    }
    catch (Exception ex)
    {
      result.SetError(ex);
    }
    finally
    {
      message?.Dispose();
      smtpClient?.Dispose();
      SendMailCallbackDelegate callBack = obj0.callBack;
      if (callBack != null)
        callBack(result);
    }
  }

  /// <summary>Отправит сообщение по E-mail</summary>
  public void SendAsync(EmailParameters parameters)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    Task.Factory.StartNew(new Action(new MailUtils.퓏()
    {
      픜핊 = this,
      픜픛 = parameters
    }.퓏));
  }

  public IList<SettingItem> Settings
  {
    get
    {
      List<SettingItem> settings = new List<SettingItem>();
      List<SettingItem> settingItemList1 = settings;
      SettingItemBoolean settingItemBoolean = new SettingItemBoolean(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓸(), this.MailUseSSLConnection);
      settingItemBoolean.Text = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓦();
      settingItemBoolean.SortIndex = 10;
      settingItemList1.Add((SettingItem) settingItemBoolean);
      if (this.MailLogin != null)
      {
        List<SettingItem> settingItemList2 = settings;
        SettingItemString settingItemString = new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픋(), this.MailLogin);
        settingItemString.Text = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞핀();
        settingItemString.SortIndex = 30;
        settingItemList2.Add((SettingItem) settingItemString);
      }
      if (this.MailPassword != null)
      {
        List<SettingItem> settingItemList3 = settings;
        SettingItemPassword settingItemPassword = new SettingItemPassword(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픲(), new PasswordHolder(this.MailPassword, recoverUrl: \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.퓥()));
        settingItemPassword.Text = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픽();
        settingItemPassword.SortIndex = 40;
        settingItemList3.Add((SettingItem) settingItemPassword);
      }
      List<SettingItem> settingItemList4 = settings;
      SettingItemInteger settingItemInteger1 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓏(), this.MailSMTPServerTimeout);
      settingItemInteger1.Text = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓬();
      settingItemInteger1.SortIndex = 50;
      settingItemInteger1.Minimum = 0;
      settingItemInteger1.Maximum = int.MaxValue;
      settingItemInteger1.Increment = 1;
      settingItemList4.Add((SettingItem) settingItemInteger1);
      if (this.MailSMTPServer != null)
      {
        List<SettingItem> settingItemList5 = settings;
        SettingItemString settingItemString = new SettingItemString(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핇(), this.MailSMTPServer);
        settingItemString.Text = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓲();
        settingItemString.SortIndex = 70;
        settingItemList5.Add((SettingItem) settingItemString);
      }
      List<SettingItem> settingItemList6 = settings;
      SettingItemInteger settingItemInteger2 = new SettingItemInteger(\u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핂(), this.MailSMTPPort);
      settingItemInteger2.Text = \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁픂();
      settingItemInteger2.SortIndex = 80 /*0x50*/;
      settingItemInteger2.Minimum = 0;
      settingItemInteger2.Maximum = int.MaxValue;
      settingItemInteger2.Increment = 1;
      settingItemList6.Add((SettingItem) settingItemInteger2);
      return (IList<SettingItem>) settings;
    }
    set
    {
      if (value == null)
        return;
      foreach (SettingItem settingItem in new SettingsHolder(value).Values)
      {
        string name = settingItem.Name;
        if (!(name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞퓸()))
        {
          if (!(name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픋()))
          {
            if (!(name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.픞픲()))
            {
              if (!(name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁퓏()))
              {
                if (!(name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핇()))
                {
                  if (name == \u00307C3E6A3\u002DEEDE\u002D4239\u002DAF49\u002D17D6CE9EDE09.핁핂())
                    this.MailSMTPPort = (int) settingItem.Value;
                }
                else
                  this.MailSMTPServer = (string) settingItem.Value;
              }
              else
                this.MailSMTPServerTimeout = (int) settingItem.Value;
            }
            else
              this.MailPassword = (settingItem.Value as PasswordHolder).Password;
          }
          else
            this.MailLogin = (string) settingItem.Value;
        }
        else
          this.MailUseSSLConnection = (bool) settingItem.Value;
      }
    }
  }

  internal void 퓏()
  {
  }
}
