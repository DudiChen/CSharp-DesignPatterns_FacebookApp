using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApp.Logic
{
    public class PostMetaData
    {
        public DateTime PostCreationTime { get; set; }

        public uint PostNumberOfLikes { get; set; }

        public uint PostLength { get; set; }

        public PostMetaData(DateTime i_PostCreateDateTime, uint i_PostNumberOfLikes, uint i_PostLength)
        {
            PostCreationTime = i_PostCreateDateTime;
            PostLength = i_PostLength;
            PostNumberOfLikes = i_PostNumberOfLikes;
        }
    }
}
