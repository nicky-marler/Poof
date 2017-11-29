using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poof.Azure
{
    public class QueryManager
    {
        static private Uri collectionLink = UriFactory.CreateDocumentCollectionUri(AccessDB.Database, AccessDB.Collection);
        static private DocumentClient Client = new DocumentClient(new Uri(AccessDB.EndpointUri), AccessDB.MasterKey);

        static public IDocumentQuery<Model.Document> Set_Query()
        {
            return Client.CreateDocumentQuery<Model.Document>(collectionLink)
                   .Take(25)
                    .AsDocumentQuery();
        }
    }
}