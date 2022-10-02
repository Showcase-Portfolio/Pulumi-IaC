using Pulumi;
using Pulumi.Aws.S3;
using Pulumi.Aws.Sns;
using Pulumi.Aws.DynamoDB;
using System.Collections.Generic;
using System.Text.Json;

return await Deployment.RunAsync(() =>
{
    var config = new Pulumi.Config();
    var services = config.GetObject<AwsServices>("awsServices")!;

    var deployed = new Dictionary<string, object?>();

    if (services.S3)
    {
        var bucket = new Bucket("sample-bucket");
        deployed.Add("bucketName", bucket.Id);
    }

    if (services.Sns)
    {
        var sns = new Topic("sample-topic");
        deployed.Add("snsName", sns.Id);
    }

    return deployed;
});
