using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Entities.AwsModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Services.Contracts;

public class S3Service : IS3Service
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;

    public S3Service(IOptions<AwsSettings> awsOptions)
    {
        var awsSettings = awsOptions.Value;
        var config = new AmazonS3Config
        {
            ServiceURL = awsSettings.ServiceURL, // LocalStack URL
            // RegionEndpoint = RegionEndpoint.GetBySystemName(awsSettings.Region),
            ForcePathStyle = true
        };

        _s3Client = new AmazonS3Client(awsSettings.AccessKey, awsSettings.SecretKey, config);
        _bucketName = awsSettings.BucketName;
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

        using var stream = file.OpenReadStream();
        var uploadRequest = new TransferUtilityUploadRequest
        {
            InputStream = stream,
            Key = fileName,
            BucketName = _bucketName,
            ContentType = file.ContentType
        };

        var fileTransferUtility = new TransferUtility(_s3Client);
        await fileTransferUtility.UploadAsync(uploadRequest);

        return $"http://localhost:4566/{_bucketName}/{fileName}";
    }
}