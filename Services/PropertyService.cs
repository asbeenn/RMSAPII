using AutoMapper;
using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Models.PropertyModel;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PropertyService : IPropertyService
    {
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly string _imageDirectory;
        private readonly IMapper _mapper;
        public PropertyService(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork,IWebHostEnvironment env,IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _env = env;
            _mapper = mapper;
            _imageDirectory = env.WebRootPath + @"\Images\Properties";
        }

        public async Task<GetPropertyDto> GetPropertyById(int id)
        {
            return await _unitOfWork.PropertyRepository.GetPropertyById(id);
        }

        public async Task<bool> AddProperty(PropertyDto propertyDto)
        {

            if (!Directory.Exists(_imageDirectory))
            {
                Directory.CreateDirectory(_imageDirectory);
            }
            FileInfo _fileInfo = new FileInfo(propertyDto.PropertyImage.FileName);
            string filename = _fileInfo.Name.Replace(_fileInfo.Extension, "") + "_" + DateTime.Now.Ticks.ToString() + _fileInfo.Extension;
            var _filePath = $"{_imageDirectory}\\{filename}";
            using (var _fileStream = new FileStream(_filePath, FileMode.Create))
            {
                await propertyDto.PropertyImage.CopyToAsync(_fileStream);
            }
            string _urlPath = _filePath.Replace('\\', '/').Split("wwwroot").Last();
            var property = _mapper.Map<DataLayer.Entities.Property>(propertyDto);
            property.PropertyImage = _urlPath;
            await _unitOfWork.PropertyRepository.AddProperty(property);
            //await _unitOfWork.SaveChangesAsync();
            return true;
           // return await _unitOfWork.PropertyRepository.AddProperty(model);
        }

        public async Task<List<GetPropertyDto>> GetAllProperty()
        {
            return await _unitOfWork.PropertyRepository.GetAllProperty();
        }

        public async Task<PropertyDto> UpdateProperty(UpdatePropertyDto updatePropertyDto)
        {
            return await _unitOfWork.PropertyRepository.UpdateProperty(updatePropertyDto);
        }

        public async Task<List<PropertyDto>> GetPropertiesByUserId(int userId)
        {
            return await _unitOfWork.PropertyRepository.GetPropertiesByUserId(userId);
        }
    }
}
