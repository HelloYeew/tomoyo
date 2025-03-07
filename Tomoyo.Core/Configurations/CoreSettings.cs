using Tomoyo.Core.Services;

namespace Tomoyo.Core.Configurations;

public static class CoreSettings
{
    public static StorageType? ProfileStorageType
    {
        get
        {
            string? value = Environment.GetEnvironmentVariable("PROFILE_STORAGE_TYPE");

            if (!Enum.TryParse(value, true, out StorageType storageType) || !Enum.IsDefined(storageType))
                return null;
            
            Console.WriteLine($"Storage Type: {storageType}");
            
            return storageType;
        }
    }
    
    public static string ProfileStorageBaseDirectory
    {
        get
        {
            string? value = Environment.GetEnvironmentVariable("PROFILE_STORAGE_BASE_DIRECTORY");

            if (string.IsNullOrWhiteSpace(value))
                return "profiles";
            
            Console.WriteLine($"Storage Base Directory: {value}");
            
            return value;
        }
    }
}