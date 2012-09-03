using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

/// <summary>
/// a simple class to get our photo container
/// </summary>
public class StorageHelper
{
    public static CloudBlobContainer getPhotoContainer() {
        StorageCredentialsAccountAndKey cred = new StorageCredentialsAccountAndKey("YOUR PREVIEW STORAGE NAME HERE", "YOUR STORAGE KEY RIGHT HERE");    
        CloudStorageAccount storageAccount = new CloudStorageAccount(cred, 
            new Uri("http://YOUR PREVIEW STORAGE NAME.blob.core.azure-preview.com/"), 
            new Uri("http://YOUR PREVIEW STORAGE NAME.table.core.azure-preview.com/"), 
            new Uri("http://YOUR PREVIEW STORAGE NAME.queue.core.azure-preview.com/"));
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference("myphotos");
        container.CreateIfNotExist();
        container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
        return container;
    }
}
