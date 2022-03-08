using ewms.common.models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ewms.common.Helpers
{
    public class LangHelper
    {
        ResourceManager _rm;
        public string default_lang = "";

        public LangHelper()
        {
            _rm = new ResourceManager("ewms.common.App_GlobalResources.ewms.Resource", Assembly.GetExecutingAssembly());
        }


        public DateTime ParseToDate(string value)
        {
            DateTime date;
            CultureInfo provider = CultureInfo.CreateSpecificCulture("es");

            if (!string.IsNullOrEmpty(value))
            {
                date = DateTime.Parse(value, provider);

            }
            else
            {
                date = DateTime.Now;
            }


            return date;
        }

        public string GetString(string ResourceName, string defaultText = "")
        {
            string ResourceString = "";
            try
            {
                ResourceString = _rm.GetString(ResourceName, Thread.CurrentThread.CurrentUICulture);
                //ResourceString = _rm.GetString(ResourceName, new System.Globalization.CultureInfo("es"));

                /*
                if (default_lang == "")
                    ResourceString = _rm.GetString(ResourceName, new System.Globalization.CultureInfo("es"));
                else
                    ResourceString = _rm.GetString(ResourceName, Thread.CurrentThread.CurrentCulture);
                */
            }
            catch (Exception ex)
            {
                ResourceString = "_" + defaultText;
            }
            return ResourceString;
        }


        public class TranslationVM
        {
            public string translation { get; set; }
        }

        public bcgResult GetStrings(string SelectedLang)
        {
            var result = new bcgResult();
            List<string> Ltranslations_T = new List<string>();
            List<TranslationVM> LAllTranslations = new List<TranslationVM>();
            ResourceManager rm_T;
            CultureInfo Ci;
            try
            {
                if (!string.IsNullOrEmpty(SelectedLang))
                {
                    rm_T = new ResourceManager("ewms.common.App_GlobalResources.ewms.mobile.Resource", Assembly.GetExecutingAssembly());
                    if (SelectedLang == "EN")
                    {
                        //get english translations
                        Ci = new CultureInfo("en", false);
                    }
                    else
                    {
                        //get spanish translations
                        Ci = new CultureInfo("es", false);

                    }

                    if (rm_T != null) // Translations
                    {
                        ResourceSet rSet = rm_T.GetResourceSet(Ci, true, true);
                        foreach (DictionaryEntry item in rSet)
                        {
                            string resourceKey = "";
                            object resourceValue = "";

                            resourceKey = item.Key.ToString();
                            resourceValue = item.Value;

                            if (!string.IsNullOrEmpty(resourceKey) && !string.IsNullOrEmpty(resourceValue.ToString()))
                            {
                                string nuevo = "";
                                nuevo = resourceKey + " ^ " + resourceValue.ToString() + " " + Environment.NewLine;
                                Ltranslations_T.Add(nuevo);
                            }
                        }
                    }


                    var LcompleteTrans = Ltranslations_T;
                    //create new TranslationVM list data
                    foreach (var item in LcompleteTrans)
                    {
                        var nuevo = new TranslationVM();
                        nuevo.translation = item;
                        LAllTranslations.Add(nuevo);
                    }

                    result.success = true;
                    result.related_data = LAllTranslations;

                }
                else
                {
                    result = result.notify(false, "LangHelper.GetStrings()", "No Langage was selected.", "LangHelper.GetStrings()");
                    return result;
                }
            } catch (Exception ex)
            {
                result = result.notify(false, "LangHelper.GetStrings()", ex.Message, "LangHelper.GetStrings()");
            }
            return result;
        }
    }
  
}