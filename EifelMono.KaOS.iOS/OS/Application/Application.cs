﻿using System;
using EifelMono.Core;
using Foundation;
using UIKit;

namespace EifelMono.KaOS.Implementation.OSx
{
    public partial class Application : IApplication
    {
        public bool IsAvailable => true;

        private First BadgeRegister = new First();

        private void RegisterBadge()
        {
            if (BadgeRegister.IsFirst)
            {
                var settings = UIUserNotificationSettings.GetSettingsForTypes(
                     UIUserNotificationType.Badge,
                     new NSSet());
                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }
        }

        public int Badge
        {
            get
            {
                return (int)UIApplication.SharedApplication.ApplicationIconBadgeNumber;
            }
            set
            {
                RegisterBadge();
                UIApplication.SharedApplication.ApplicationIconBadgeNumber = value;
            }
        }

        private First<StatusBarStyle> _StatusBarStyle = new First<StatusBarStyle>(StatusBarStyle.Normal);

        public StatusBarStyle StatusBarStyle { get => _StatusBarStyle.Value; set => SetStatusBarStyle(value, false); }

        public void SetStatusBarStyle(StatusBarStyle statusBarStyle, bool animated)
        {
            if (_StatusBarStyle.IsFirstOrChanged(statusBarStyle))
                switch (statusBarStyle)
                {
                    case StatusBarStyle.Normal:
                        UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.Default, animated);
                        break;
                    case StatusBarStyle.Light:
                        UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, animated);
                        break;
                    case StatusBarStyle.Dark:
                        UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.BlackOpaque, animated);
                        break;
                    case StatusBarStyle.Translucent:
                        UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.BlackTranslucent, animated);
                        break;
                }
        }

        private First<Visibility> _SetStatusBarVisibility = new First<Visibility>(Visibility.Visible);

        public Visibility StatusBarVisibility { get => _SetStatusBarVisibility.Value; set => SetStatusBarVisibility(value, false); }

        public void SetStatusBarVisibility(Visibility visibility, bool animated)
        {
            if (_SetStatusBarVisibility.IsFirstOrChanged(visibility))
                switch (visibility)
                {
                    case Visibility.Visible:
                        UIApplication.SharedApplication.SetStatusBarHidden(false, animated);
                        break;
                    case Visibility.Hidden:
                        UIApplication.SharedApplication.SetStatusBarHidden(true, animated); UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, animated);
                        break;
                    case Visibility.Disabled:
                        break;
                }
        }
    }
}