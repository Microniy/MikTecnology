using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RepositoryDB
{
    public class ConnectBuilderJson
    {
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        [JsonPropertyName("Property4")]
        public string UserID { get; set; }
        [JsonPropertyName("Property3")]
        public string Password { get; set; }
    }
}
