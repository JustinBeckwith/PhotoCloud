using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.Configuration;

/// <summary>
/// a simple class to get our photo container
/// </summary>
public class StorageHelper
{
    public static CloudBlobContainer getPhotoContainer() {
        StorageCredentialsAccountAndKey cred = new StorageCredentialsAccountAndKey(ConfigurationManager.AppSettings["storageName"], ConfigurationManager.AppSettings["storageKey"]);    
        CloudStorageAccount storageAccount = new CloudStorageAccount(cred, false);            
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference("myphotos");
        container.CreateIfNotExist();
        container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
        return container;
    }
}
