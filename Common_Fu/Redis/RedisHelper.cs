using ServiceStack.Redis;
using System.Collections.Concurrent;

namespace Common_Fu.Redis;

public class RedisHelper
{
    public static RedisClient redisClient = null!;

    public RedisHelper(CustomRedisConfig config)
    {
        redisClient = new RedisClient(config.Host, config.Port);
    }
    public T Get<T>(string name)
    {
        return redisClient.Get<T>(name);
    }
    public bool Set<T>((string Name, T Data) dictionaries)
    {
        return redisClient.Set<T>(dictionaries.Name, dictionaries.Data);
    }
}
