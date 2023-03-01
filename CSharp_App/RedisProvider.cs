using StackExchange.Redis;

public class RedisContext {
    private ConnectionMultiplexer conn = null;
    public RedisContext(string connectionString) {
        var config = ConfigurationOptions.Parse(connectionString);
        config.AbortOnConnectFail = false;
        // config.ChannelPrefix = "Sample_";
        config.AllowAdmin = true;
        
        try {
            conn = ConnectionMultiplexer.Connect(config);

            conn.GetServer(conn.GetEndPoints().Single())
                .ConfigSet("notify-keyspace-events", "KEA");

            conn.GetSubscriber()
                .Subscribe("__key*__:*", (channel, message) =>
                    Console.WriteLine($"received {message}"));
 
            Task.Run(() => {Thread.Sleep(2000); Console.WriteLine("waiting!");});

        } catch (Exception exp) {
            Console.WriteLine($"Exception: RedisContext {exp.Message}");
        }
    }

    public bool IsConnected => conn != null && conn.IsConnected;
}

public interface IRedisConnection {

}