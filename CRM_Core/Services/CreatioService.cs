using CRM_Core.Models;
using CRM_Core.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CRM_Core.Services
{
    public class CreatioService
    {
        private readonly string _appUrl;
        private CookieContainer _authCookie;
        private readonly string _authServiceUrl;
        private readonly string _userName;
        private readonly string _userPassword;

        public CreatioService(string appUrl, string userName, string userPassword)
        {
            _appUrl = appUrl;
            _authServiceUrl = _appUrl + @"/ServiceModel/AuthService.svc/Login";
            _userName = userName;
            _userPassword = userPassword;
        }

        public CookieContainer TryLogin()
        {
            var authData = @"{
                    ""UserName"":""" + _userName + @""",
                    ""UserPassword"":""" + _userPassword + @"""
                }";

            var request = RequestCreation.CreateRequest
                (url: _authServiceUrl,
                method: "POST",
                contentType: "application/json",
                isKeepAlive: true,
                requestData: authData,
                null
                );

            _authCookie = new CookieContainer();
            request.CookieContainer = _authCookie;
            AddCsrfToken(request);

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {

                        var responseMessage = reader.ReadToEnd();
                        Console.WriteLine(responseMessage);
                        if (responseMessage.Contains("\"Code\":1"))
                        {
                            throw new UnauthorizedAccessException($"Unauthorized {_userName} for {_appUrl}");
                        }
                    }

                    foreach (Cookie cookie in response.Cookies)
                    {
                        _authCookie.Add(new Uri(_appUrl), new Cookie(cookie.Name, cookie.Value));
                    }
                }
            }

            return _authCookie;
        }

        public HttpWebRequest AddCsrfToken(HttpWebRequest request)
        {
            var cookie = request.CookieContainer.GetCookies(new Uri(_appUrl))["BPMCSRF"];
            if (cookie != null)
            {
                request.Headers.Add("BPMCSRF", cookie.Value);
            }

            return request;
        }

        public bool Delete(string id)
        {
            var isSuccess = false;
            var request = RequestCreation.CreateRequest(url: $"https://cto-creatio.beesender.com/0/odata/Contact({id})",
                method: "DELETE",
                contentType: null,
                isKeepAlive: true,
                requestData: null,
                cookies: _authCookie
                );

            AddCsrfToken(request);

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    isSuccess = true;
                }
            };

            return isSuccess;
        }

        public bool AddContact(ContactViewModel contact)
        {
            var isSuccess = false;

            var jsonDateSettings = new JsonSerializerSettings { DateFormatString = "yyyy-MM-ddTHH:mm:ss.ffffffZ" };
            var contactData = @"{
                    ""Name"":""" + contact.Name + @""",
                    ""Dear"":""" + contact.Dear + @""",
                    ""JobTitle"":""" + contact.JobTitle + @""",
                    ""MobilePhone"":""" + contact.MobilePhone + @""",
                    ""BirthDate"":" + JsonConvert.SerializeObject(contact.BirthDate, jsonDateSettings) + @"
                }";
         
            var request = RequestCreation.CreateRequest(url: "https://cto-creatio.beesender.com/0/odata/Contact",
               method: "POST",
               contentType: "application/json",
               isKeepAlive: true,
               requestData: contactData,
               cookies: _authCookie
               );
            request.Accept = "*/*";
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            AddCsrfToken(request);

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    isSuccess = true;
                }
            };

            return isSuccess;
        }

        public ContactViewModel GetContact(string id)
        {
            var request = RequestCreation.CreateRequest(url: $"https://cto-creatio.beesender.com/0/odata/Contact({id})",
               method: "GET",
               contentType: "application/json",
               isKeepAlive: true,
               requestData: null,
               cookies: _authCookie
               );
            AddCsrfToken(request);

            var contact = new ContactViewModel();
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var responseMessage = reader.ReadToEnd();
                        var jsonContact = JsonConvert.DeserializeObject<Contact>(responseMessage);

                        contact.Name = jsonContact.Name;
                        contact.Id = jsonContact.Id;
                        contact.JobTitle = jsonContact.JobTitle;
                        contact.MobilePhone = jsonContact.MobilePhone;
                        contact.Dear = jsonContact.Dear;
                        contact.BirthDate = DateTime.Parse(jsonContact.BirthDate);

                    }
                }
            }
            return contact;
        }

        public List<ContactViewModel> GetContacts()
        {
            var contacts = new List<ContactViewModel>();
            var request = RequestCreation.CreateRequest(url: "https://cto-creatio.beesender.com/0/odata/Contact",
                method: "GET",
                contentType: "application/json",
                isKeepAlive: true,
                requestData: null,
                cookies: _authCookie
                );

            var cookie = _authCookie.GetCookies(new Uri("https://cto-creatio.beesender.com"))["BPMCSRF"];
            if (cookie != null)
            {
                request.Headers.Add("BPMCSRF", cookie.Value);

            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var responseMessage = reader.ReadToEnd();
                        var jsonObject = JsonConvert.DeserializeObject<OdataContext>(responseMessage);
                        foreach (var jsonContact in jsonObject.Contacts)
                        {
                            var contact = new ContactViewModel();
                            contact.Name = jsonContact.Name;
                            contact.Id = jsonContact.Id;
                            contact.JobTitle = jsonContact.JobTitle;
                            contact.MobilePhone = jsonContact.MobilePhone;

                            contacts.Add(contact);
                        }
                    }
                }
            }

            return contacts;
        }
        public bool ChangeConctact(ContactViewModel contact)
        {
            var isSuccess = false;
            var jsonDateSettings = new JsonSerializerSettings { DateFormatString = "yyyy-MM-ddTHH:mm:ss.ffffffZ" };
            var contactData = @"{
                    ""Name"":""" + contact.Name + @""",
                    ""Dear"":""" + contact.Dear + @""",
                    ""JobTitle"":""" + contact.JobTitle + @""",
                    ""MobilePhone"":""" + contact.MobilePhone + @""",
                    ""BirthDate"":" + JsonConvert.SerializeObject(contact.BirthDate, jsonDateSettings) + @"
                }";

            var request = RequestCreation.CreateRequest(url: $"https://cto-creatio.beesender.com/0/odata/Contact({contact.Id})",
               method: "PATCH",
               contentType: "application/json",
               isKeepAlive: true,
               requestData: contactData,
               cookies: _authCookie
               );
            AddCsrfToken(request);

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    isSuccess = true;
                }
            }

            return isSuccess;
        }
    }
}
