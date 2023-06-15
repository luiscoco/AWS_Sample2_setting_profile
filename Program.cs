using System;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Set your AWS access key, secret key, and profile name
        string accessKey = "";
        string secretKey = "";
        string profileName = "default"; //default or second_user

        // Create an instance of the AWSCredentials object
        AWSCredentials credentials;

        if (!string.IsNullOrEmpty(profileName))
        {
            // Set the profile-based credentials
            credentials = new StoredProfileAWSCredentials(profileName);
        }
        else
        {
            // Set the access key and secret key directly
            credentials = new BasicAWSCredentials(accessKey, secretKey);
        }

        // Create an instance of the AmazonS3Config object and set the region
        var s3Config = new AmazonS3Config
        {
            RegionEndpoint = RegionEndpoint.EUWest3 // Replace with your desired region
        };

        // Create an instance of the AmazonS3Client with the specified credentials and configuration
        var s3Client = new AmazonS3Client(credentials, s3Config);

        // Use the AmazonS3Client object for further operations
        // For example, list all the S3 buckets
        var response = await s3Client.ListBucketsAsync();

        foreach (var bucket in response.Buckets)
        {
            Console.WriteLine($"Bucket Name: {bucket.BucketName}");
        }

        // Remember to dispose of the AmazonS3Client object when you're done
        s3Client.Dispose();
    }
}
