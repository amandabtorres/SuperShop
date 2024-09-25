using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SuperShop.Prism.Helpers;
using SuperShop.Prism.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(SuperShop.Prism.Droid.Implementations.Localize))]
namespace SuperShop.Prism.Droid.Implementations
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            string netLanguage = "en";
            Java.Util.Locale androidLocale = Java.Util.Locale.Default;
            netLanguage = AndroidToDotnetLanguage(androidLocale.ToString().Replace("_", "-"));
                       

            CultureInfo ci = null;
            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException)
            {
                try
                {
                    string fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                    ci = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException)
                {
                    ci = new CultureInfo("en");
                }
            }
            return ci;
        }     
        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        private string AndroidToDotnetLanguage(string androidLanguage)
        {
            string netLanguage = androidLanguage;

            switch (androidLanguage)
            {
                case "ms-BN":
                case "ms-MY":
                case "ms-SG":
                    netLanguage = "ms";
                    break;
                case "in-ID":
                    netLanguage = "id-ID";
                    break;
                case "gsw-CH":
                    netLanguage = "de-CH";
                    break;
            }
            return netLanguage;
        }

        private string ToDotnetFallbackLanguage(PlatformCulture platformCulture)
        {
            string netLanguage = platformCulture.LanguageCode;
            switch (platformCulture.LanguageCode)
            {                
                case "gsw":
                    netLanguage = "de-CH";
                    break;
            }
            return netLanguage;
        }

        
    }
}