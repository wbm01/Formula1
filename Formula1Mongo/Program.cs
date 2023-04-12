using Formula1Mongo;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
internal class Program
{
    private static void Main(string[] args)
    {
        MongoClient mongo = new MongoClient("mongodb://localhost:27017");

        /*var listabancos = mongo.ListDatabaseNames().ToList();

        foreach(var banco in listabancos)
        {
            Console.WriteLine(banco);
        }*/

        var basededados = mongo.GetDatabase("Formula1");
        var collection = basededados.GetCollection<BsonDocument>("Pilotos");
        var document = collection.Find(new  BsonDocument()).ToList();

        //SELECT
        /*Console.Write("\nInforme o nome do piloto: ");
        var nome = Console.ReadLine();

        var filtro = Builders<BsonDocument>.Filter.Regex("Driver", nome);

        var piloto = collection.Find(filtro).FirstOrDefault();

        var p = BsonSerializer.Deserialize<Driver>(piloto);

        Console.WriteLine(p.ToString());*/

        /*foreach(var documents in document)
        {
            Console.WriteLine(documents.ToString());
            Console.ReadLine();
        }*/


        /*var filtro = Builders<BsonDocument>.Filter.Regex("Driver", nome);

        var piloto = collection.Find(filtro).FirstOrDefault();

        Console.WriteLine(piloto);

        Console.Write("\nInforme o nome da equipe: ");
        var equipe = Console.ReadLine();

        filtro = Builders<BsonDocument>.Filter.Regex("Team", equipe);

        var pilotos = collection.Find(filtro).ToList();

        foreach(var driver in pilotos)
        {
            Console.WriteLine(driver);
        }*/

        //INSERT
        /*Console.Write("\nNome: ");
        var n = Console.ReadLine();

        Console.Write("\nAbreviação: ");
        var a = Console.ReadLine();

        Console.Write("\nNúmero: ");
        var nu = int.Parse(Console.ReadLine());

        Console.Write("\nEquipe: ");
        var e = Console.ReadLine();

        Console.Write("\nPaís: ");
        var p = Console.ReadLine();

        Console.Write("\nData de Nascimento: ");
        var d = Console.ReadLine();

        Driver driver = new Driver(n,a,nu,e,p,d);

        Console.WriteLine(driver.ToString());

        var dr = new BsonDocument
        {
            {"Driver", driver.Name},
            {"Abbreviation", driver.Abbreviation},
            {"No", driver.Number},
            {"Team", driver.Team},
            {"Country", driver.Country},
            {"Date of Birth", driver.BirthDate}
        };

        Console.WriteLine(dr);

        collection.InsertOne(dr);*/

        //UPDATE
        Console.Write("\nInforme o nome do piloto: ");
        string n = Console.ReadLine();

        var p = collection.Find(Builders<BsonDocument>.Filter.Regex("Driver", n)).First();

        var driver = BsonSerializer.Deserialize<Driver>(p);

        //Console.Write("\nInforme o novo número: ");
        //int numero = int.Parse(Console.ReadLine());


        //collection.UpdateOne(Builders<BsonDocument>.Filter.Regex("Driver", n), Builders<BsonDocument>.Update.Set("No", numero));

        //DELETE
        collection.FindOneAndDelete(p);
    }
}