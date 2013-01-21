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
    protected static CloudStorageAccount getStorageAccount() {       
        StorageCredentialsAccountAndKey cred = new StorageCredentialsAccountAndKey("photocloud", "HwLFWaK3sc6wWndHLTdUp+eLwfv3/zheJJGIyXJUGzlc3OifKhS//bVnwvn7C8PWiut257G31dEXEEutwxaC5g==");    
        CloudStorageAccount storageAccount = new CloudStorageAccount(cred, 
            new Uri("http://photocloud.blob.core.windows-int.net/"), 
            new Uri("http://photocloud.queue.core.windows-int.net/"), 
            new Uri("http://photocloud.table.core.windows-int.net/"));
        return storageAccount;
    }

    public static CloudBlobContainer getPhotoContainer() {        
        CloudStorageAccount storageAccount = getStorageAccount();
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference("myphotos");
        container.CreateIfNotExist();
        container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
        return container;
    }

    //public static CloudTableClient getTableClient() {
    //    var storageAccount = getStorageAccount();
    //    var tableClient = storageAccount.CreateCloudTableClient();
    //    tableClient.CreateTableIfNotExist("photocloud");
    //}

}
