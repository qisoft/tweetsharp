using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TweetSharp
{
    [Serializable]
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterSearchMetaData
    {
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual long SinceId { get; set; }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual long MaxId { get; set; }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string RefreshUrl { get; set; }
        
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string NextPage { get; set; }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string PreviousPage { get; set; }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual double CompletedIn { get; set; }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string Query { get; set; }

#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual string Warning { get; set; }
        
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual int Total { get; set; }
    }


#if !SILVERLIGHT
    /// <summary>
    /// The results of a request to the Search API.
    /// </summary>
    [Serializable]
#endif
#if !Smartphone && !NET20
    [DataContract]
    [DebuggerDisplay("{ResultsPerPage} results on page {Page} from {Source}")]
#endif
    [JsonObject(MemberSerialization.OptIn)]
    public class TwitterSearchResult : ITwitterModel
    {
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual IEnumerable<TwitterSearchStatus> Statuses { get; set; }
        
#if !Smartphone && !NET20
        [DataMember]
#endif
        public virtual TwitterSearchMetaData SearchMetadata { get; set; }
        


#if !Smartphone && !NET20
        /// <summary>
        /// The source content used to deserialize the model entity instance.
        /// Can be XML or JSON, depending on the endpoint used.
        /// </summary>
        [DataMember]
#endif
        public virtual string RawSource { get; set; }
    }


}