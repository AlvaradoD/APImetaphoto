using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ewmsAPI.ViewModels
{
    public class GeneralVM
    {







    }

    //----------------------------------SERVER INFO
    public class ServerDataVM
    {
        public string Environment { get; set; }
        public string Owner { get; set; }
        public string Dataserver { get; set; }
        public string Database { get; set; }
        public string ServerName { get; set; }
    }

    //-----------------------------------------------ALL INFO VM


    //-----------------------------------------------PHOTOS VM
    public class photosJSONVM
    {
        public string albumId { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string thumbnailUrl { get; set; }

    }


    //------------------------------------------------ALBUN VM
    public class albumsJSONVM
    {
        public string userId { get; set; }
        public string id { get; set; }
        public string title { get; set; }

    }


    //------------------------------------------------USER VM

    public class CompanyVM
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }

    }


    public class GeoVM
    {
        public string lat { get; set; }
        public string lng { get; set; }
     
    }



    public class AddressVM
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public GeoVM geo { get; set; }
    }




    public class UserJSONVM
    {
        public string id { get; set; }
        public string name { get; set; }
        public string username { get; set; }

        public string email { get; set; }

        public AddressVM address { get; set; }

        public string phone { get; set; }

        public string website { get; set; }

        public CompanyVM company { get; set; }

    }


}