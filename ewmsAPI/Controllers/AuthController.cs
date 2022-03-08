using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ewmsAPI.Models.ViewModels;
using ewms.common.Helpers;

using System.Web.Http.Description;
using Newtonsoft.Json;
using ewmsAPI.ViewModels;

namespace ewmsAPI.Controllers
{
    public class AuthController : ApiController
    {
        //LoginBL blLogin = new LoginBL();
        

        // GET: api/login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


      


        [ActionName("LogInApp")]
        [Route("api/Auth/LogInApp")]   
        [HttpPost]
        public bcgResult LogInApp([FromBody] loginInfo value)
        {
            
           
            bcgResult iResult = new bcgResult();
           
          
            UserJSONVM usuario = GetUserInfo(value.username.ToUpper());
            if (usuario == null)
            {
                iResult.success = false;
                iResult.message = "This user does not exist please verify";
                iResult.error_code = "500X";
            }
            else {

                List<albumsJSONVM> AlbumsXUser  = GetalbumsInfo(usuario.id);
                var NoAlbums = AlbumsXUser.Count();


                List<photosJSONVM> PhotosXUser = GetphotosInfo(AlbumsXUser);
                var NoPhotos = PhotosXUser.Count();


                UserVM node = new UserVM
                {
                    LASTNAME = usuario.name,
                    FIRSTNAME = usuario.email,
                    STATUS = "1",
                    COD_USER = usuario.username,
                    USER_ID = usuario.id,

                    UserNoPhotos = NoPhotos.ToString(),
                    UserNoAlbums = NoAlbums.ToString(),
                    UserName = usuario.name,
                    UserUsername = usuario.username,
                    UserEmail = usuario.email,
                    UserPhotos = PhotosXUser,
                    UserAlbums = AlbumsXUser,


                };

                iResult.related_data = node;
                iResult.message = "";
                iResult.success = true;

            }

            return iResult;


        }




        public UserJSONVM GetUserInfo(string UserOrEmail)
        {

            UserJSONVM iResult = new UserJSONVM();
            string urlService = "";

            try
            {             
                using (var client = new HttpClient())
                {

                    client.Timeout = TimeSpan.FromMinutes(3);                  
                    urlService = "https://jsonplaceholder.typicode.com/users";
                    
                    var e = client.GetAsync(urlService);
                    var rs = e.Result;

                    if (rs.IsSuccessStatusCode)
                    {
                        string result = rs.Content.ReadAsStringAsync().Result;
                        var errors = new List<string>();
                        var theResult = JsonConvert.DeserializeObject<List<UserJSONVM>>(result);

                        var user = theResult.Where(m=> m.email.ToUpper() == UserOrEmail || m.username.ToUpper() == UserOrEmail).FirstOrDefault();        
                        iResult = user;

                 
                    }
                    else
                    {
                        string sErrorMessage = "";
                        sErrorMessage = rs.StatusCode.ToString();
                        iResult = null;                        
                    }
                }

            }
            catch (Exception ex)
            {               
                iResult = null;
            }

            return iResult;
        }



        public List<albumsJSONVM> GetalbumsInfo(string userId)
        {

            List < albumsJSONVM> iResult = new List<albumsJSONVM>();
            string urlService = "";

            try
            {
                using (var client = new HttpClient())
                {

                    client.Timeout = TimeSpan.FromMinutes(3);
                    urlService = "https://jsonplaceholder.typicode.com/albums";

                    var e = client.GetAsync(urlService);
                    var rs = e.Result;

                    if (rs.IsSuccessStatusCode)
                    {
                        string result = rs.Content.ReadAsStringAsync().Result;
                        var errors = new List<string>();
                        var theResult = JsonConvert.DeserializeObject<List<albumsJSONVM>>(result);

                        var valbums = theResult.Where(m => m.userId.ToUpper() == userId ).OrderBy(n=>n.id).ToList();
                        iResult = valbums;
                    }
                    else
                    {
                        string sErrorMessage = "";
                        sErrorMessage = rs.StatusCode.ToString();
                        iResult = null;
                    }
                }

            }
            catch (Exception ex)
            {
                iResult = null;
            }

            return iResult;
        }





        public List<photosJSONVM> GetphotosInfo( List<albumsJSONVM> valbunes)
        {

            List<photosJSONVM> iResult = new List<photosJSONVM>();
            string urlService = "";

            try
            {
                using (var client = new HttpClient())
                {

                    client.Timeout = TimeSpan.FromMinutes(3);
                    urlService = "https://jsonplaceholder.typicode.com/photos";

                    var e = client.GetAsync(urlService);
                    var rs = e.Result;

                    if (rs.IsSuccessStatusCode)
                    {
                        string result = rs.Content.ReadAsStringAsync().Result;
                        var errors = new List<string>();
                        var theResult = JsonConvert.DeserializeObject<List<photosJSONVM>>(result);


                       // var results = MyTable.Where(x => myInClause.Contains(x.SomeColumn));

                        var vphotos = theResult.Where(m =>valbunes.Select(f=> f.id).Contains(m.albumId)).OrderBy(n => n.id).ToList();
                        iResult = vphotos;
                    }
                    else
                    {
                        string sErrorMessage = "";
                        sErrorMessage = rs.StatusCode.ToString();
                        iResult = null;
                    }
                }

            }
            catch (Exception ex)
            {
                iResult = null;
            }

            return iResult;
        }





        [ActionName("LogOutApp")]
        [Route("api/Auth/LogOutApp")]
        [HttpGet]        
        public bool LogOutApp(string dc, string truck)
        {
            return true;


            //if (blLogin.logOutApp(dc,truck))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        



        [HttpGet]
        [Route("api/Auth/Encrypt")]
        [ResponseType(typeof(bcgResult))]
        public bcgResult Encrypt(string sText)
        {
            var encryptbl = new EncryptionService();
            var result = new bcgResult();
            result.data = encryptbl.Encriptar(sText);
            return result;

        }
        [HttpGet]
        [Route("api/Auth/Decrypt")]
        [ResponseType(typeof(bcgResult))]
        public bcgResult Decrypt(string sText)
        {
            var encryptbl = new EncryptionService();
            var result = new bcgResult();
            result.data = encryptbl.Desencriptar(sText);
            return result;

        }
        [HttpGet]
        [Route("api/Auth/AuthorizeDevice")]
        [ResponseType(typeof(bcgResult))]
        public bcgResult AuthorizeDevice(string deviceId,string code_DC)
        {


            bcgResult result = new bcgResult();
            result.success = true;

            return result;

            //var authbl = new AuthBL();
            //return authbl.Authorize_device(deviceId, code_DC);

        }
      

        // POST: api/login
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/login/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/login/5
        public void Delete(int id)
        {

        }

    }
}
