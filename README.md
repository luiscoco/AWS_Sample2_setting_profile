# AWS_Sample2_setting_profile

This code demonstrates how to use the AWS SDK for .NET to interact with Amazon S3 (Simple Storage Service) and list all the S3 buckets in a specified region. Let's go through the code step by step:

The code imports the necessary namespaces from the AWS SDK and System.Threading.Tasks.

The Program class is defined, which contains the entry point method Main.

The Main method is declared with the async keyword, indicating that it can use await to perform asynchronous operations.

The AWS access key, secret key, and profile name are declared as strings. These credentials are required to authenticate with AWS.

An instance of the AWSCredentials object is created. The AWSCredentials class represents the AWS credentials used for authentication.

The code checks if a profile name is provided. If a profile name is provided, the StoredProfileAWSCredentials class is used to set profile-based credentials. Otherwise, the BasicAWSCredentials class is used to set the access key and secret key directly.

An instance of the AmazonS3Config object is created. This object is used to configure the Amazon S3 client, such as setting the desired region.

An instance of the AmazonS3Client class is created, passing the AWSCredentials object and the AmazonS3Config object as parameters. This creates a client for interacting with Amazon S3 using the specified credentials and configuration.

The ListBucketsAsync method is called on the s3Client object to asynchronously retrieve the list of S3 buckets in the specified region. The method returns a response object.

The code then iterates over the response.Buckets collection, which contains information about each bucket, and prints the name of each bucket using Console.WriteLine.

After the bucket listing is complete, the Dispose method is called on the s3Client object to release any resources associated with it.

Overall, this code sets up the AWS credentials, configures the S3 client, lists the S3 buckets in a specified region, and prints their names to the console.

```csharp
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
```
