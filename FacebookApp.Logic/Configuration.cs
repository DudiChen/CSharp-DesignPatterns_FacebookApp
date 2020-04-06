using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApp.Logic
{
    internal static class Configuration
    {
        public static readonly string sr_AppID = "1089225541443714";
        public static readonly string[] sr_UserPermissions =
            {
                "public_profile", "user_gender", "user_birthday", "user_age_range", "user_likes", "user_photos",
                "user_posts", "user_friends", "user_location", "user_tagged_places"
            };

        //public string AppID
        //{
        //    get
        //    {
        //        return sr_AppID;
        //    }
        //}

        //public string[] UserPermissions
        //{
        //    get
        //    {
        //        return sr_UserPermissions;
        //    }
        //}
    }
}
