using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApp.Logic
{
    public static class Configuration
    {
        public static readonly string sr_AppID = "1089225541443714";
        public static readonly string[] sr_UserPermissions =
            {
                "public_profile", "user_gender", "user_birthday", "user_hometown", "user_age_range", "user_likes",
                "user_photos","user_posts", "user_friends", "user_location", "user_tagged_places",
                "publish_to_groups", "groups_access_member_info", "publish_pages"
            };
        public const int k_MaxPostsShown = 15;
    }
}
