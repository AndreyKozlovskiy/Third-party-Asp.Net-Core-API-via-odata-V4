using Newtonsoft.Json;
namespace CRM_Core.Models
{
    public class Contact
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("OwnerId")]
        public string OwnerId { get; set; }
        [JsonProperty("CreatedOn")]
        public string CreatedOn { get; set; }
        [JsonProperty("CreatedById")]
        public string CreatedById { get; set; }
        [JsonProperty("ModifiedOn")]
        public string ModifiedOn { get; set; }
        [JsonProperty("ModifiedById")]
        public string ModifiedById { get; set; }
        [JsonProperty("ProcessListeners")]
        public int ProcessListeners { get; set; }
        [JsonProperty("Dear")]
        public string Dear { get; set; }
        [JsonProperty("SalutationTypeId")]
        public string SalutationTypeId { get; set; }
        [JsonProperty("GenderId")]
        public string GenderId { get; set; }
        [JsonProperty("AccountId")]
        public string AccountId { get; set; }
        [JsonProperty("DecisionRoleId")]
        public string DecisionRoleId { get; set; }
        [JsonProperty("TypeId")]
        public string TypeId { get; set; }
        [JsonProperty("JobId")]
        public string JobId { get; set; }
        [JsonProperty("JobTitle")]
        public string JobTitle { get; set; }
        [JsonProperty("DepartmentId")]
        public string DepartmentId { get; set; }
        [JsonProperty("BirthDate")]
        public string BirthDate { get; set; }
        [JsonProperty("Phone")]
        public string Phone { get; set; }
        [JsonProperty("MobilePhone")]
        public string MobilePhone { get; set; }
        [JsonProperty("HomePhone")]
        public string HomePhone { get; set; }
        [JsonProperty("Skype")]
        public string Skype { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("AddressTypeId")]
        public string AddressTypeId { get; set; }
        [JsonProperty("Address")]
        public string Address { get; set; }
        [JsonProperty("CityId")]
        public string CityId { get; set; }
        [JsonProperty("RegionId")]
        public string RegionId { get; set; }
        [JsonProperty("Zip")]
        public string Zip { get; set; }
        [JsonProperty("CountryId")]
        public string CountryId { get; set; }
        [JsonProperty("DoNotUseEmail")]
        public bool DoNotUseEmail { get; set; }
        [JsonProperty("DoNotUseCall")]
        public bool DoNotUseCall { get; set; }
        [JsonProperty("DoNotUseFax")]
        public bool DoNotUseFax { get; set; }
        [JsonProperty("DoNotUseSms")]
        public bool DoNotUseSms { get; set; }
        [JsonProperty("DoNotUseMail")]
        public bool DoNotUseMail { get; set; }
        [JsonProperty("Notes")]
        public string Notes { get; set; }
        [JsonProperty("Facebook")]
        public string Facebook { get; set; }
        [JsonProperty("LinkedIn")]
        public string LinkedIn { get; set; }
        [JsonProperty("Twitter")]
        public string Twitter { get; set; }
        [JsonProperty("FacebookId")]
        public string FacebookId { get; set; }
        [JsonProperty("LinkedInId")]
        public string LinkedInId { get; set; }
        [JsonProperty("TwitterId")]
        public string TwitterId { get; set; }
        [JsonProperty("ContactPhoto@odata.mediaEditLink")]
        public string ContactPhotoEditLink { get; set; }
        [JsonProperty("ContactPhoto@odata.mediaReadLink")]
        public string ContactPhotoReadLink { get; set; }
        [JsonProperty("ContactPhoto@odata.mediaContentType")]
        public string ContactPhotoContentType { get; set; }
        [JsonProperty("TwitterAFDAId")]
        public string TwitterAFDAId { get; set; }
        [JsonProperty("FacebookAFDAId")]
        public string FacebookAFDAId { get; set; }
        [JsonProperty("LinkedInAFDAId")]
        public string LinkedInAFDAId { get; set; }
        [JsonProperty("PhotoId")]
        public string PhotoId { get; set; }
        [JsonProperty("GPSN")]
        public string GPSN { get; set; }
        [JsonProperty("GPSE")]
        public string GPSE { get; set; }
        [JsonProperty("Surname")]
        public string Surname { get; set; }
        [JsonProperty("GivenName")]
        public string GivenName { get; set; }
        [JsonProperty("MiddleName")]
        public string MiddleName { get; set; }
        [JsonProperty("Confirmed")]
        public bool Confirmed { get; set; }
        [JsonProperty("IsNonActualEmail")]
        public bool IsNonActualEmail { get; set; }
        [JsonProperty("Completeness")]
        public int Completeness { get; set; }
        [JsonProperty("DistrictId")]
        public string DistrictId { get; set; }
        [JsonProperty("Street")]
        public string Street { get; set; }
        [JsonProperty("Building1")]
        public string Building1 { get; set; }
        [JsonProperty("Building2")]
        public string Building2 { get; set; }
        [JsonProperty("AptOffice")]
        public string AptOffice { get; set; }
        [JsonProperty("LanguageId")]
        public string LanguageId { get; set; }
        [JsonProperty("ServiceLevelId")]
        public string ServiceLevelId { get; set; }
        [JsonProperty("SocialStatusId")]
        public string SocialStatusId { get; set; }
        [JsonProperty("INN")]
        public string INN { get; set; }
        [JsonProperty("IsAgreePersonalDataProcessing")]
        public bool IsAgreePersonalDataProcessing { get; set; }
        [JsonProperty("IsInBlackList")]
        public bool IsInBlackList { get; set; }
        [JsonProperty("BlackListDate")]
        public string BlackListDate { get; set; }
        [JsonProperty("BlackListReason")]
        public string BlackListReason { get; set; }
        [JsonProperty("BranchId")]
        public string BranchId { get; set; }
        [JsonProperty("CitizenshipId")]
        public string CitizenshipId { get; set; }
        [JsonProperty("Passport")]
        public string Passport { get; set; }
        [JsonProperty("PlaceOfBirth")]
        public string PlaceOfBirth { get; set; }
        [JsonProperty("EducationId")]
        public string EducationId { get; set; }
        [JsonProperty("MaritalStatusId")]
        public string MaritalStatusId { get; set; }
        [JsonProperty("SpouseId")]
        public string SpouseId { get; set; }
        [JsonProperty("NumberOfFamilyMembers")]
        public int NumberOfFamilyMembers { get; set; }
        [JsonProperty("NumberOfChildren")]
        public int NumberOfChildren { get; set; }
        [JsonProperty("IsDeceased")]
        public bool IsDeceased { get; set; }
        [JsonProperty("DeceasedNotes")]
        public string DeceasedNotes { get; set; }
        [JsonProperty("EmploymentTypeId")]
        public string EmploymentTypeId { get; set; }
        [JsonProperty("ClientTypeId")]
        public string ClientTypeId { get; set; }
        [JsonProperty("IsAgreePrivateDataVerification")]
        public bool IsAgreePrivateDataVerification { get; set; }
        [JsonProperty("Age")]
        public int Age { get; set; }
        [JsonProperty("BSDNotificationRecipient")]
        public string BSDNotificationRecipient { get; set; }
        [JsonProperty("BSDNotificatioChannelId")]
        public string BSDNotificatioChannelId { get; set; }
        [JsonProperty("BSDNotificationSent")]
        public string BSDNotificationSent { get; set; }
        [JsonProperty("BSDNotificationText")]
        public string BSDNotificationText { get; set; }
        [JsonProperty("BSDCandidateAge")]
        public int BSDCandidateAge { get; set; }
        [JsonProperty("FacebookProfileId")]
        public string FacebookProfileId { get; set; }
    }
}