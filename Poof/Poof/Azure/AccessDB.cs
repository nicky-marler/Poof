using System;
using System.Collections.Generic;
using System.Text;

namespace Poof.Azure
{
    class AccessDB
    {
        public static readonly string EndpointUri = "https://poof.documents.azure.com:443/";
        //Never have a Master key in application use. This is for testing purposes only
        public static readonly string MasterKey = "D0v8jp0VWQoVjWmbDh9Ddq13j6gbkgqUXEdl1fxKR1PbbfKZgZM4FvsMeWRinZSBl1VyKP53WNiOKcKB9I4H9w==";
        public static readonly string Database = "poof";
        public static readonly string Collection = "poof";
    }
}
