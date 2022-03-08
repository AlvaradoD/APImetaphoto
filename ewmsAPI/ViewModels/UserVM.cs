using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ewmsAPI.ViewModels
{
    public class UserVM
    {

        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public string STATUS { get; set; }
        public string COD_USER { get; set; }
       
        public string USER_ID { get; set; }


        //Nuevos
        public string UserNoPhotos { get; set; }
        public string UserNoAlbums { get; set; }
        public string UserName { get; set; }

        public string UserUsername { get; set; }

        public string UserEmail { get; set; }

        public List<albumsJSONVM> UserAlbums { get; set; }

        public List<photosJSONVM> UserPhotos { get; set; }

    }
}