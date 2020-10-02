using System;
using System.IO;
using System.Text.Json;

namespace JsonCreater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start create...");
           
            string CriptKey = "CryptKeyTest";
            Console.WriteLine("Compile file...");
           
            RepositoryDB.ConnectBuilderJson ConnectionObj = new RepositoryDB.ConnectBuilderJson();
            ConnectionObj.DataSource = RepositoryDB.StringCipher.Encrypt("SqlServerName", CriptKey);
            ConnectionObj.InitialCatalog = "BaseName";
            ConnectionObj.UserID = RepositoryDB.StringCipher.Encrypt("LoginName", CriptKey);
            ConnectionObj.Password = RepositoryDB.StringCipher.Encrypt("Password", CriptKey);
            string jsonString;
            jsonString = JsonSerializer.Serialize(ConnectionObj);
            File.WriteAllText(@"D:\ConnectJson.json", jsonString);
            Console.Write("Pres and key.");
            Console.ReadKey();
            string jsonString2;
            Console.WriteLine("Read file...");
            jsonString2 = File.ReadAllText(@"D:\ConnectJson.json");
            RepositoryDB.ConnectBuilderJson ConnectionObj2 = new RepositoryDB.ConnectBuilderJson();
            ConnectionObj2 = JsonSerializer.Deserialize<RepositoryDB.ConnectBuilderJson>(jsonString2);           
            Console.WriteLine(RepositoryDB.StringCipher.Decrypt(ConnectionObj2.DataSource,CriptKey));
            Console.WriteLine(ConnectionObj2.InitialCatalog);
            Console.WriteLine(RepositoryDB.StringCipher.Decrypt(ConnectionObj2.UserID, CriptKey));
            Console.WriteLine(RepositoryDB.StringCipher.Decrypt(ConnectionObj2.Password, CriptKey));
            Console.Write("Pres and key.");
            Console.ReadKey();
        }
       
    }
}
