using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace FrejaClient.Dto.SignatureService
{
    /// <summary>
    /// Request object for initiating a signature
    /// </summary>
    public class InitSignatureRequest
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public InitSignatureRequest(InitSignatureRequestData data)
        {
            Data = data;
        }

        /// <summary>
        /// Data for the request object
        /// </summary>
        [JsonPropertyName("initSignRequest")]
        public InitSignatureRequestData Data { get; }
    }

    public class InitSignatureRequestData
    {
        public InitSignatureRequestData(
            UserInfoTypeDto userInfoType,
            string userInfo,
            RegistrationLevelDto minRegistrationLevel,
            UserConfirmationMethodDto userConfirmationMethod,
            string title,
            PushNotificationDto pushNotification,
            long expiry,
            DataToSignTypeDto dataToSignType,
            DataToSignDto dataToSign,
            SignatureTypeDto signatureType,
            IReadOnlyCollection<AttributesToReturnDto> attributesToReturn
            )
        {
            UserInfoType = userInfoType;
            UserInfo = userInfo;
            MinRegistrationLevel = minRegistrationLevel;
            UserConfirmationMethod = userConfirmationMethod;
            Title = title;
            PushNotification = pushNotification;
            Expiry = expiry;
            DataToSignType = dataToSignType;
            DataToSign = dataToSign;
            SignatureType = signatureType;
            AttributesToReturn = attributesToReturn;
        }

        /// <summary>
        /// Describes the type of user information supplied to identify the end user. 
        /// </summary>
        [JsonPropertyName("userInfoType")]
        public UserInfoTypeDto UserInfoType { get; }

        /// <summary>
        /// 256 characters maximum. If userInfoType is EMAIL or PHONE, interpreted as a string value of the email or telephone number of the end user, respectively. If userInfoType is SSN, then it must be a Base64 encoding of the ssnuserinfo JSON structure described below. If userInfoType is INFERRED, then userInfo must be set to: "N/A" because there is no data for the user to enter.
        ///
        /// Mandatory
        /// </summary>
        [JsonPropertyName("userInfo")]
        public string UserInfo { get; }

        /// <summary>
        /// Minimum required registration level of a user in order to approve/decline signing transaction. 
        /// </summary>
        [JsonPropertyName("minRegistrationLevel")]
        public RegistrationLevelDto MinRegistrationLevel { get; }

        /// <summary>
        /// Used to specify the method by which the user's identity is confirmed when performing an action
        /// </summary>
        [JsonPropertyName("userConfirmationMethod")]
        public UserConfirmationMethodDto UserConfirmationMethod { get; }

        /// <summary>
        /// The title to display in the transaction list if presented to the user on the mobile device. The title will be presented regardless of the confidentiality setting (see below). If not present, a system default text will be presented.
        ///
        /// Optional, 128 characters maximum. 
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; }

        /// <summary>
        /// The title and the text of the notification sent to the mobile device to alert the user of a signature request. The character limit for the push notification title and text is 256 characters for each. If not present, a system default title and text will be presented.
        ///
        /// How much text the user sees in the push notification depends on the device's screen size.
        /// </summary>
        [JsonPropertyName("pushNotification")]
        public PushNotificationDto PushNotification { get; }

        /// <summary>
        /// Describes the time until which the Relying Party is ready to wait for the user to confirm the signature request. Expressed in milliseconds since January 1, 1970, 00:00 UTC. Min value is current time +2 minutes, max value is current time +30 days. If not present, defaults to current time +2 minutes. 
        ///
        /// Maximum expiry time for transactions with user info type INFERRED is current time +30 minutes.If not present, defaults to current time +2 minutes.
        /// </summary>
        [JsonPropertyName("expiry")]
        public long Expiry { get; }

        /// <summary>
        /// Describes the type of data to be signed. 
        /// </summary>
        [JsonPropertyName("dataToSignType")]
        public DataToSignTypeDto DataToSignType { get; }

        /// <summary>
        /// Subject to dataToSignType; If SIMPLE_UTF8_TEXT, then all of dataToSign will be displayed to the user prior to asking for signature approval. If EXTENDED_UTF8_TEXT, then one part will be displayed to the user prior to asking for signature approval, while the binaryData part of dataToSign will not.
        /// </summary>
        [JsonPropertyName("dataToSign")]
        public DataToSignDto DataToSign { get; }

        /// <summary>
        /// The type of signature that is requested. Currently, SIMPLE, EXTENDED and XML_MINAMEDDELANDEN are supported and must match the dataToSignType parameter. SIMPLE signature type supports SIMPLE_UTF8_TEXT data to sign type, EXTENDED signature type supports EXTENDED_UTF8_TEXT data to sign type and XML_MINAMEDDELANDEN supports SIMPLE_UTF8_TEXT data to sign type.
        /// </summary>
        [JsonPropertyName("signatureType")]
        public SignatureTypeDto SignatureType { get; }

        /// <summary>
        /// When retrieving results, additional information about the user can be returned based on the type of attributes required through this parameter. Each object should contain one attribute.
        /// </summary>
        [JsonPropertyName("attributesToReturn")]
        public IReadOnlyCollection<AttributesToReturnDto> AttributesToReturn { get; }
    }

    public enum UserInfoTypeDto
    {
        [EnumMember(Value = "PHONE")] // (end user's telephone number)
        Phone,

        [EnumMember(Value = "EMAIL")] // (end user's email)
        Email,

        [EnumMember(Value = "SSN")] // (end user's social security number)
        Ssn,

        [EnumMember(Value = "INFERRED")] // (for QR code signature transactions)
        Inferred
    }

    public class SsnUserInfoDto
    {
        public SsnUserInfoDto(string country, string ssn)
        {
            switch (country)
            {
                case "SE" :
                    if (!Regex.IsMatch(ssn, "^[0-9]{12}$"))
                        throw new System.ArgumentException("SSN must be numeric for Sweden", nameof(ssn));
                    break;
                case "NO":
                    if (!Regex.IsMatch(ssn, "^[0-9]{11}$"))
                        throw new System.ArgumentException("SSN must be numeric for Norway", nameof(ssn));
                    break;
                case "FI":
                    if (!Regex.IsMatch(ssn, "^[0-9]{6}[-A][0-9]{3}T$"))
                        throw new System.ArgumentException("SSN must be numeric for Finland", nameof(ssn));
                    break;
                case "DK":
                    if (!Regex.IsMatch(ssn, "^[0-9]{10}$"))
                        throw new System.ArgumentException("SSN must be numeric for Denmark", nameof(ssn));
                    break;
                default:
                    throw new System.ArgumentException("Country must be one of SE, NO, FI, DK", nameof(country));
            }

            Country = country;
            Ssn = ssn;
        }

        [JsonPropertyName("country")]
        public string Country { get; }

        [JsonPropertyName("ssn")]
        public string Ssn { get; }
    }

    public enum RegistrationLevelDto
    {
        [EnumMember(Value = "BASIC")]
        Basic,

        [EnumMember(Value = "EXTENDED")]
        Extended,

        [EnumMember(Value = "PLUS")]
        Plus
    }

    public enum UserConfirmationMethodDto
    {
        [EnumMember(Value = "DEFAULT")]
        Default,

        [EnumMember(Value = "DEFAULT_AND_FACE")]
        DefaultAndFace,
    }

    public class PushNotificationDto
    {
        public PushNotificationDto(string title, string text)
        {
            if (title.Length > 256)
                throw new System.ArgumentException("Title must be less than 256 characters", nameof(title));

            if (text.Length > 256)
                throw new System.ArgumentException("Text must be less than 256 characters", nameof(text));

            Title = title;
            Text = text;
        }
        [JsonPropertyName("title")]
        public string Title { get; }

        [JsonPropertyName("text")]
        public string Text { get; }
    }

    public enum DataToSignTypeDto
    {
        [EnumMember(Value = "SIMPLE_UTF8_TEXT")]
        SimpleUtf8Text,

        [EnumMember(Value = "EXTENDED_UTF8_TEXT")]
        ExtendedUtf8Text,
    }

    public class DataToSignDto
    {
        public DataToSignDto(string text, string binaryData) 
        {
            Text = text;
            BinaryData = binaryData;
        }

        /// <summary>
        /// 4096 plain text characters maximum prior to Base64 encoding. The text that will be shown in the mobile application and signed by the end user. The content of the Base64 string are bytes representing a UTF-8 encoding of the text to be displayed to and signed by the user.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; }

        /// <summary>
        /// 5 MB maximum prior to Base64 encoding. This is not shown to the user in the mobile application but is, nonetheless included in the signature.
        /// </summary>
        [JsonPropertyName("binaryData")]
        public string BinaryData { get; }
    }

    public enum SignatureTypeDto
    {
        /// <summary>
        /// The Simple signature type allows signing of UTF-8 text. Upon completion of the signature by the user, the Relying Party receives a JWS structure containing the data that was presented to the user, as well as evidence that the Freja eID infrastructure has validated the signature.
        /// </summary>
        [EnumMember(Value = "SIMPLE")]
        Simple,

        /// <summary>
        /// The Extended signature type allows signing of UTF-8 text (presented to the user) alongside binary data (not presented to the user). Upon completion of the signature by the user, the Relying Party receives a JWS structure containing the data that was presented to the user and the supplied binary data, as well as evidence that the Freja eID infrastructure has validated the signature.
        /// </summary>
        [EnumMember(Value = "EXTENDED")]
        Extended,

        /// <summary>
        /// The Advanced signature type XML_MINAMEDDELANDEN allows signing of UTF-8 text. Upon completion of the signature by the user, the Relying Party receives a JWS structure containing the data that was presented to the user, advancedSignature as well as evidence that the Freja eID infrastructure has validated the signature. The XML signature contains the transaction text displayed to the user, the time of signing and evidence of end-user approval in a format suitable for integration with Tekniska tjänstekontrakt-API Mina meddelanden.
        /// </summary>
        [EnumMember(Value = "XML_MINAMEDDELANDEN")]
        XmlMinameddelanden
    }

    public class AttributesToReturnDto
    {
        public AttributesToReturnDto(string attribute)
        {
            Attribute = attribute;
        }

        [JsonPropertyName("attribute")]
        public string Attribute { get; }
    }

    public enum AttributeTypes
    {
        /// <summary>
        /// User's basic information (name and surname)
        /// </summary>
        [EnumMember(Value = "BASIC_USER_INFO")]
        BasicUserInfo,

        /// <summary>
        /// User's primary email address
        ///
        /// If you would prefer an email with a specific email domain please get in touch with partnersupport@frejaeid.com.
        /// </summary>
        [EnumMember(Value = "EMAIL_ADDRESS")]
        EmailAddress,

        /// <summary>
        /// All user's email addresses
        /// </summary>
        [EnumMember(Value = "ALL_EMAIL_ADDRESSES")]
        AllEmailAddresses,

        /// <summary>
        /// All user's phone numbers
        /// </summary>
        [EnumMember(Value = "ALL_PHONE_NUMBERS")]
        AllPhoneNumbers,

        /// <summary>
        /// User's date of birth
        /// </summary>
        [EnumMember(Value = "DATE_OF_BIRTH")]
        DateOfBirth,

        /// <summary>
        /// User's age based on their date of birth
        /// </summary>
        [EnumMember(Value = "AGE")]
        Age,

        /// <summary>
        /// User's photo, Base64 encoded JPEG bytes.
        /// </summary>
        [EnumMember(Value = "PHOTO")]
        Photo,

        /// <summary>
        /// User's current addresses
        /// </summary>
        [EnumMember(Value = "ADDRESSES")]
        Addresses,

        /// <summary>
        /// User's social security number and country
        /// </summary>
        [EnumMember(Value = "SSN")]
        Ssn,

        /// <summary>
        /// data of the document used for registration
        /// </summary>
        [EnumMember(Value = "DOCUMENT")]
        Document,

        /// <summary>
        /// User's document photo, Base64 encoded JPEG bytes
        /// </summary>
        [EnumMember(Value = "DOCUMENT_PHOTO")]
        DocumentPhoto,

        /// <summary>
        /// User's registration level in Freja eID
        /// </summary>
        [EnumMember(Value = "REGISTRATION_LEVEL")]
        RegistrationLevel,

        /// <summary>
        /// User's unique personal identifier in Freja eID
        ///
        /// In order to be able to request this attribute, you must first get in touch with partnersupport@frejaeid.com.
        /// </summary>
        [EnumMember(Value = "UNIQUE_PERSONAL_IDENTIFIER")]
        UniquePersonalIdentifier,

        /// <summary>
        /// User's level of assurance
        ///
        /// In order to be able to request this attribute, you must first get in touch with partnersupport@frejaeid.com.
        /// </summary>
        [EnumMember(Value = "LOA_LEVEL")]
        LoaLevel,

        /// <summary>
        /// A unique, user-specific value that allows the Relying Party to identify the same user across multiple sessions
        /// </summary>
        [EnumMember(Value = "RELYING_PARTY_USER_ID")]
        RelyingPartyUserId,

        /// <summary>
        /// A unique, user-specific value that allows the Integrator to identify the same user across multiple sessions regardless of the Integrated Relying Party service that the user is using. For more info, see the section about Integrator Relying Party Management
        /// </summary>
        [EnumMember(Value = "INTEGRATOR_SPECIFIC_USER_ID")]
        IntegratorSpecificUserId,

        /// <summary>
        /// A unique, Relying Party-specific, user identifier, set by the Relying Party through the Custom Identifier Management
        ///
        /// In order to be able to request this attribute, you must first get in touch with partnersupport @frejaeid.com.
        /// </summary>
        [EnumMember(Value = "CUSTOM_IDENTIFIER")]
        CustomIdentifier
    }
}