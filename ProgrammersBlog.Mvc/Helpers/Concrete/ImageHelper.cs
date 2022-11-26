using ProgrammersBlog.Entities.ComplexTypes;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System.Text.RegularExpressions;

namespace ProgrammersBlog.Mvc.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;
        private readonly string _imgFolder = "img";
        private const string userImagesFolder = "userImages";
        private const string postImagesFolder = "postImages";
        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath;
        }

        public IDataResult<ImageDeletedDto> Delete(string pictureName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{_imgFolder}/", pictureName);
            if (System.IO.File.Exists(fileToDelete))
            {
                var fileInfo = new FileInfo(fileToDelete);
                var imageDeletedDto = new ImageDeletedDto
                {
                    FullName = pictureName,
                    Extension = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileToDelete);
                return new DataResult<ImageDeletedDto>(ResultStatus.Success, imageDeletedDto);
            }
            else
            {
                return new DataResult<ImageDeletedDto>(ResultStatus.Error, "Boyle bir resim bulunamadi.", null);
            }
        }

        public async Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile, PictureType pictureType, string folderName = null)
        {
            folderName ??= pictureType == PictureType.User ? userImagesFolder : postImagesFolder;

            if (!Directory.Exists($"{_wwwroot}/{_imgFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{_wwwroot}/{_imgFolder}/{folderName}");
            }

            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);
            string fileExtension = Path.GetExtension(pictureFile.FileName);

            Regex regex = new Regex("[*'\",._&#^@]");
            name = regex.Replace(name, string.Empty);

            DateTime dateTime = DateTime.Now;
            string newFileName = $"{name}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";
            var path = Path.Combine($"{_wwwroot}/{_imgFolder}/{folderName}", newFileName);

            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
            }

            string message = pictureType == PictureType.User 
                ? $"{name} adli kullanicinin resmi basariyla yuklenmistir." 
                : $"{name} adli makalenin resmi basariyla yuklenmistir.";

            return new DataResult<ImageUploadedDto>(ResultStatus.Success, message, new ImageUploadedDto
            {
                FullName = $"{folderName}/{newFileName}",
                OldName = oldFileName,
                Extension = fileExtension,
                FolderName = folderName,
                Path = path,
                Size = pictureFile.Length
            });
        }
    }
}
