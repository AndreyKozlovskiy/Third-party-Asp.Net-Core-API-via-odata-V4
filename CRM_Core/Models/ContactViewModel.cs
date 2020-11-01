using System;

namespace CRM_Core.Models
{
    public class ContactViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MobilePhone { get; set; }
        public string JobTitle { get; set; }
        public string Dear { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
