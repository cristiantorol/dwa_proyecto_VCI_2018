using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.IO;
using System;
using System.Threading;
using System.Configuration;
using VCI.DTO.Request;

namespace VCI.BLL
{
    public class BlobStorageBLL
    {
        private CloudStorageAccount StorageAccount;
        private CloudBlobClient BlobClient;

        public BlobStorageBLL()
        {
            StorageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            BlobClient = StorageAccount.CreateCloudBlobClient();
        }

        public Uri SaveFile(string folder, FileBase64 file)
        {
            CloudBlobContainer CandidateContainer;
            CloudBlockBlob blob;
            Uri result = null;

            CandidateContainer = BlobClient.GetContainerReference(folder);

            if (!CandidateContainer.Exists())
            {
                CandidateContainer.Create();
                CandidateContainer.SetPermissions(
                new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            byte[] Image = Convert.FromBase64String(file.Base64);
            using (MemoryStream stream = new MemoryStream(Image))
            {
                blob = CandidateContainer.GetBlockBlobReference(
                    string.Format("{0}.{1}", file.Name, file.Format)
                );

                blob.UploadFromStream(stream);
                result = blob.Uri;
            }
            return result;
        }
    }
}

