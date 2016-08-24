using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
    public class ImageController : Controller
    {
        public async Task<ActionResult> CreateImage(string fmt, string id)
        {
			try
			{
				var path = Server.MapPath($"~/App_Data/covers/{id}.jpg");
				var img = new WebImage(await GetBytes(path));

				switch (fmt.ToLower())
				{
					case "thumb":
						img.Resize(100, 1000).Write();
						break;

					case "medium":
						img
							.Resize(300, 3000)
							.AddTextWatermark("Ingars Movie Database", "Black", padding: 5)
							.AddTextWatermark("Ingars Movie Database", "White", padding: 7)
							.Write();
						break;

					default:
						return HttpNotFound();
				}

				return new EmptyResult();

			}
			catch (Exception)
			{
				return HttpNotFound();
			}
		}

		private async Task<byte[]> GetBytes(string path)
		{
			byte[] buffer;
			using (FileStream stream = System.IO.File.Open(path, FileMode.Open))
			{
				buffer = new byte[stream.Length];
				await stream.ReadAsync(buffer, 0, (int)stream.Length);
			}
			return buffer;
		}
	}
}