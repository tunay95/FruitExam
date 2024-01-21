namespace FruitMVC.Helpers
{
	public static class FileManager
	{
		public static string Upload(this IFormFile File, string envpath, string folderName)
		{
			string filename = File.FileName;
			filename = Guid.NewGuid().ToString() + filename;
			string path = envpath + folderName + filename;
			using (FileStream stream = new FileStream(path, FileMode.Create))
			{
				File.CopyTo(stream);

			}
			return filename;
		}

		public static bool CheckContent(this IFormFile File, string content)
		{
			return File.ContentType.Contains(content);
		}

		public static bool CheckLength(this IFormFile File, int length)
		{
			return File.Length <= length / 1024 / 1024;
		}
	}
}
