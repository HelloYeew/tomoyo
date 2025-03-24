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
                return StorageType.Local;
            
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
            
            return value;
        }
    }

    public static StorageType? PhotoStorageType
    {
        get
        {
            string? value = Environment.GetEnvironmentVariable("PHOTO_STORAGE_TYPE");

            if (!Enum.TryParse(value, true, out StorageType storageType) || !Enum.IsDefined(storageType))
                return StorageType.Local;
            
            return storageType;
        }
    }
    
    public static string PhotoStorageBaseDirectory
    {
        get
        {
            string? value = Environment.GetEnvironmentVariable("PHOTO_STORAGE_BASE_DIRECTORY");

            if (string.IsNullOrWhiteSpace(value))
                return "photos";
            
            return value;
        }
    }
}