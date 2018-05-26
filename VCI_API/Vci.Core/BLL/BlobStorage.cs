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

        public Uri SaveCandidateFoto(Candidate Candidate)
        {
            if (string.IsNullOrEmpty(Candidate.ProfileFotoBase64) || string.IsNullOrEmpty(Candidate.ProfileFotoFormat))
            {
                return null;
            }
            CloudBlobContainer CandidateContainer;
            CloudBlockBlob blob;
            Uri result = null;

            CandidateContainer = BlobClient.GetContainerReference(Candidate.Identification);

            if (!CandidateContainer.Exists())
            {
                CandidateContainer.Create();
                CandidateContainer.SetPermissions(
                new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }

            if (Candidate.ProfileFotoFormat.Equals("png") || Candidate.ProfileFotoFormat.Equals("jpg") || Candidate.ProfileFotoFormat.Equals("jpeg"))
            {
                byte[] Image = Convert.FromBase64String(Candidate.ProfileFotoBase64);
                using (MemoryStream stream = new MemoryStream(Image))
                {
                    blob = CandidateContainer.GetBlockBlobReference(
                        string.Format("{0}_profileFoto.{1}", Candidate.Identification, Candidate.ProfileFotoFormat)
                    );

                    blob.UploadFromStream(stream);
                    result = blob.Uri;
                }
            }
            return result;
        }
    }
}

