using DiamondShopSystem.Business.Base;
using DiamondShopSystem.Common;
using DiamondShopSystem.Data;
using DiamondShopSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShopSystem.Business
{
    public interface IRequestDetailsBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(string id);
        Task<IBusinessResult> Save(RequestDetail requestDetails);
        Task<IBusinessResult> Update(RequestDetail requestDetails);
        Task<IBusinessResult> DeleteById(string id);
    }
    public class RequestDetailsBusiness : IRequestDetailsBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public RequestDetailsBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAll()
        {
            try
            {
                var requestDetails = await _unitOfWork.RequestDetailRepository.GetAllAsync();
                if (requestDetails != null)
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, requestDetails);
                }
                else
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> GetById(string id)
        {
            try
            {
                var requestDetails = await _unitOfWork.RequestDetailRepository.GetByIdAsync(id);
                if (requestDetails == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, requestDetails);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Save(RequestDetail requestDetails)
        {
            try
            {
                var requestDetail = await _unitOfWork.RequestDetailRepository.CreateAsync(requestDetails);
                if (requestDetail != null)
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, requestDetail);
                }
                else
                {
                    return new BusinessResult(Const.ERROR_EXCEPTION, Const.FAIL_CREATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Update(RequestDetail requestDetails)
        {
            try
            {
                var requestDetail = await _unitOfWork.RequestDetailRepository.UpdateAsync(requestDetails);
                if (requestDetail != null)
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, requestDetail);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> DeleteById(string id)
        {
            try
            {
                var requestDetail = await _unitOfWork.RequestDetailRepository.GetByIdAsync(id);
                if (requestDetail == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    var result = await _unitOfWork.RequestDetailRepository.RemoveAsync(requestDetail);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG);
                    }
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
    } 
}
    