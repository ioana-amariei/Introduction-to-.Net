using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace ComputerVisionFunction
{
	public static class HttpTrigger
	{
		[FunctionName("HttpTrigger")]
		public async static Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
	{
			log.Info("Function invoked");

			// We only support POST requests
			if (req.Method == "GET")
				return new BadRequestResult();
			
			// grab the key and URI from the portal config
			var visionKey = "dfa6c21fa1204079ac21ab269c03ca49";
			var visionEndpoint = "https://westcentralus.api.cognitive.microsoft.com/";

			// create a client and request Tags for the image submitted
			var vsc = new ComputerVisionClient(new ApiKeyServiceClientCredentials(visionKey))
			{
				Endpoint = visionEndpoint
			};

			ImageDescription result = null;

			// We read the content as a byte array and assume it's an image
			if (req.Method == "POST")
			{
				try
				{
					result = await vsc.DescribeImageInStreamAsync(req.Body);
				}
				catch(Exception ex) { }
			}

			// if we didn't get a result from the service, return a 400
			if (result == null)
				return new BadRequestResult();

            var formatedResult = LogDescriptionResults(result);
            var finalResult = LogAnalysisResult(formatedResult);

            return new OkObjectResult(finalResult
                ?? "I'm at a loss for words... I can't describe this image!");
		}

        private static ImageAnalysis LogDescriptionResults(ImageDescription result)
        {
            ImageAnalysis analysisResult = new ImageAnalysis
            {
                Metadata = result.Metadata,
                Description = new ImageDescriptionDetails
                {
                    Captions = result.Captions,
                    Tags = result.Tags
                }
            };
            return analysisResult;
            
        }

        private static string LogAnalysisResult(ImageAnalysis result)
        {
            string text = string.Empty;
            if (result == null)
            {
                text += Log("null");
                return null;
            }

            if (result.Metadata != null)
            {
                text += Log("Metadata : ");
                text += Log("   Image Format : " + result.Metadata.Format);
                text += Log("   Image Dimensions : " + result.Metadata.Width + " x " + result.Metadata.Height);
            }

            if (result.ImageType != null)
            {
                text += Log("Image Type : ");
                string clipArtType;
                switch (result.ImageType.ClipArtType)
                {
                    case 0:
                        clipArtType = "0 Non-clipart";
                        break;
                    case 1:
                        clipArtType = "1 ambiguous";
                        break;
                    case 2:
                        clipArtType = "2 normal-clipart";
                        break;
                    case 3:
                        clipArtType = "3 good-clipart";
                        break;
                    default:
                        clipArtType = "Unknown";
                        break;
                }
                text += Log("   Clip Art Type : " + clipArtType);

                string lineDrawingType;
                switch (result.ImageType.LineDrawingType)
                {
                    case 0:
                        lineDrawingType = "0 Non-LineDrawing";
                        break;
                    case 1:
                        lineDrawingType = "1 LineDrawing";
                        break;
                    default:
                        lineDrawingType = "Unknown";
                        break;
                }
                text += Log("   Line Drawing Type : " + lineDrawingType);
            }

            if (result.Adult != null)
            {
                text += Log("Adult : ");
                text += Log("   Is Adult Content : " + result.Adult.IsAdultContent);
                text += Log("   Adult Score : " + result.Adult.AdultScore);
                text += Log("   Is Racy Content : " + result.Adult.IsRacyContent);
                text += Log("   Racy Score : " + result.Adult.RacyScore);
            }

            if (result.Categories != null && result.Categories.Count > 0)
            {
                text += Log("Categories : ");
                foreach (var category in result.Categories)
                {
                    text += Log("   Name : " + category.Name + "; Score : " + category.Score);
                }
            }

            if (result.Faces != null && result.Faces.Count > 0)
            {
                text += Log("Faces : ");
                foreach (var face in result.Faces)
                {
                    text += Log("   Age : " + face.Age + "; Gender : " + face.Gender);
                }
            }

            if (result.Color != null)
            {
                text += Log("Color : ");
                text += Log("   AccentColor : " + result.Color.AccentColor);
                text += Log("   Dominant Color Background : " + result.Color.DominantColorBackground);
                text += Log("   Dominant Color Foreground : " + result.Color.DominantColorForeground);

                if (result.Color.DominantColors != null && result.Color.DominantColors.Count > 0)
                {
                    string colors = "Dominant Colors : ";
                    foreach (var color in result.Color.DominantColors)
                    {
                        colors += color + " ";
                    }
                    text += Log(colors);
                }
            }

            if (result.Description != null)
            {
                text += Log("Description : ");
                foreach (var caption in result.Description.Captions)
                {
                    text += Log("   Caption : " + caption.Text + "; Confidence : " + caption.Confidence);
                }
                string tags = "   Tags : ";
                foreach (var tag in result.Description.Tags)
                {
                    tags += tag + ", ";
                }
                text += Log(tags);

            }

            if (result.Tags != null)
            {
                text += Log("Tags : ");
                foreach (var tag in result.Tags)
                {
                    text += Log("   Name : " + tag.Name + "; Confidence : " + tag.Confidence + ((string.IsNullOrEmpty(tag.Hint) ? "" : ("; Hint : " + tag.Hint))));
                }
            }

            return text;
        }

        private static string Log(string logMessage)
        {
            var result = string.Empty;
            if (String.IsNullOrEmpty(logMessage) || logMessage == "\n")
            {
                result += "\n";
            }
            else
            {
                string timeStr = DateTime.Now.ToString("HH:mm:ss.ffffff");
                string messaage = "[" + timeStr + "]: " + logMessage + "\n";
                result += messaage;
            }
            return result;
        }
    }
}