//using Common;
//using DataLayer.Interfaces;
//using Microsoft.Extensions.Options;
//using Models.Property;
//using Services.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Services
//{
//    public class PropertyService : IPropertyService
//    {
//        private readonly AppSettings _appSettings;
//        private readonly IUnitOfWork _unitOfWork;
//        public PropertyService(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork)
//        {
//            _appSettings = appSettings.Value;
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<PropertyDto> GetPropertyById(int id)
//        {
//           return await _unitOfWork.PropertyRepository.GetPropertyById(id);
//        }
//        public async Task<PropertyDto> AddProperty(PropertyDto model)
//        {
//            return await _unitOfWork.PropertyRepository.AddProperty(model);
//        }

       
//    }
//}
