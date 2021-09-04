using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult UploadCarImage(IFormFile imageFile, CarImage carImage)
        {

            var result = BusinessRules.Run(CheckIfImageLimitExceded(carImage.CarId));
            if(result != null)
            {
                return result;
            }


            string filePath = ImageFileHelper.Upload(imageFile);
            carImage.ImagePath = filePath;
            carImage.Date = DateTime.Now;
            // return new SuccessDataResult<CarImage>(carImage);
            return this.Add(carImage);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = ImageFileHelper.Delete(carImage.ImagePath);
            //return result;
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(b => b.Id == carImageId), Messages.CarImageGot);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if(result >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceded);
            }
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> getCarImagesByCarId(int carId)
        {
            List<CarImage> carImages = _carImageDal.GetAll(c => c.CarId == carId);
            if(carImages.Count == 0)
            {
                carImages.Add(new CarImage
                {
                    Id = 0,
                    CarId = carId,
                    ImagePath = ImageFileHelper.GetDefaultCarImagePath(),
                });
            }
            return new SuccessDataResult<List<CarImage>>(carImages, Messages.CarImagesGetByCar);
        }
    }
}
