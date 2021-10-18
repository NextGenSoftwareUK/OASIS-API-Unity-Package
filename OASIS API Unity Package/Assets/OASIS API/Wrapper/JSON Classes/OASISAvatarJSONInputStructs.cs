namespace OASIS.AVATAR.JSON
{
    public class OASISAvatarJSONInputStructs
    {
        public struct Upload2DAvatarImage
        {
            public string avatarId;
            public string imageBase64;
        }
        public struct Authenticate
        {
            public string email;
            public string password;
        }
        public struct Register
        {
            public string title;
            public string firstName;
            public string lastName;
            public string avatarType;
            public string email;
            public string password;
            public string confirmPassword;
            public string createdOASISType;
            public bool acceptTerms;
        }
        public struct VerifyEmail
        {
            public string token;
        }
        public struct ForgetPassword
        {
            public string email;
        }
        public struct ValidateResetToken
        {
            public string token;
        }
        public struct ResetPassword
        {
            public string token;
            public string password;
            public string confirmPassword;
        }
        public struct CreateModel
        {
            public string title;
            public string firstName;
            public string lastName;
            public string avatarType;
            public string email;
            public string password;
            public string confirmPassword;
            public string createdOASISType;
        }
        public struct AddKarmaToAvatar
        {
            public string karmaType;
            public string karmaSourceType;
            public string karamSourceTitle;
            public string karmaSourceDesc;
        }
        public struct RemoveKarmaFromAvatar
        {
            public string karmaType;
            public string karmaSourceType;
            public string karamSourceTitle;
            public string karmaSourceDesc;
        }
        public struct UpdateAvatar
        {
            public string title;
            public string firstName;
            public string lastName;
            public string avatarType;
            public string email;
            public string password;
            public string confirmPassword;
        }
    }
}
