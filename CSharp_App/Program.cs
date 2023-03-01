// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var db = new RedisContext("localhost, password=admin_key");
if (!db.IsConnected) {
    Console.WriteLine("REDIS is not connected");
} else {
    Console.WriteLine("REDIS is connected");
    while (true) { Thread.Sleep(500); }
}

