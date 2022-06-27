using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BirlesikOdeme.Database;
using BirlesikOdeme.Library.DTO;
using BirlesikOdeme.Library.MyException;
using static BirlesikOdeme.Library.Constant;
using BBirlesikOdeme.Database.Repo;

namespace BirlesikOdeme.Business
{
    public class customerDAL
    {
        private static customerDAL _instance;
        static MapperBL mapper;
        private static readonly MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<customer, customerDTO>();
            cfg.CreateMap<customer, customerDTO>().ReverseMap();
        });
        public static customerDAL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new customerDAL();
                mapper = new MapperBL(mapperConfig);
            }

            return _instance;
        }

        public List<customerDTO> GetAll()
        {
            try
            {
                using (UnitOfWork worker = new UnitOfWork())
                {
                    var item = worker.RepositoryCUSTOMER.Select().ToList();
                    List<customerDTO> dto = mapper.Map<List<customerDTO>>(item);
                    return dto.OrderByDescending(p => p.ID).ToList();
                }
            }
            catch (Exception ex)
            {
                LoggerBL.GetInstance().Error(ErrorCodes.ISLEM_HATALI.ToString(), ex);
                throw new MyException(ErrorCodes.ISLEM_HATALI, ex);
            }
        }

        public List<customerDTO> GetAllUnverifieds()
        {
            try
            {
                using (UnitOfWork worker = new UnitOfWork())
                {
                    var item = worker.RepositoryCUSTOMER.Select(p => p.IDENTITYNOVERIFIED == YESNO.HAYIR).ToList();
                    List<customerDTO> dto = mapper.Map<List<customerDTO>>(item);
                    return dto.OrderByDescending(p => p.ID).ToList();
                }
            }
            catch (Exception ex)
            {
                LoggerBL.GetInstance().Error(ErrorCodes.ISLEM_HATALI.ToString(), ex);
                throw new MyException(ErrorCodes.ISLEM_HATALI, ex);
            }
        }

        public customerDTO GetById(int id)
        {
            try
            {
                using (UnitOfWork worker = new UnitOfWork())
                {
                    var item = worker.RepositoryCUSTOMER.Select(p => p.ID == id).FirstOrDefault();
                    customerDTO dto = mapper.Map<customerDTO>(item);
                    return dto;
                }
            }
            catch (Exception ex)
            {
                LoggerBL.GetInstance().Error(ErrorCodes.ISLEM_HATALI.ToString(), ex);
                throw new MyException(ErrorCodes.ISLEM_HATALI, ex);
            }
        }

        public customerDTO GetByIdIncluded(int id)
        {
            List<string> includedList = new List<string>();
            includedList.Add("MUSTERI.MUSTERI"); // FOR EXAMPLE
            try
            {
                using (UnitOfWork worker = new UnitOfWork())
                {
                    var item = worker.RepositoryCUSTOMER.Select(p => p.ID == id, includedList).FirstOrDefault();
                    customerDTO dto = mapper.Map<customerDTO>(item);
                    return dto;
                }
            }
            catch (Exception ex)
            {
                LoggerBL.GetInstance().Error(ErrorCodes.ISLEM_HATALI.ToString(), ex);
                throw new MyException(ErrorCodes.ISLEM_HATALI, ex);
            }
        }

        public customerDTO AddNew(customerDTO dto)
        {
            try
            {
                using (UnitOfWork worker = new UnitOfWork())
                {
                    customer item = mapper.Map<customer>(dto);
                    worker.RepositoryCUSTOMER.Insert(item);
                    worker.Save();
                    customerDTO val = mapper.Map<customerDTO>(item);
                    return val;
                }
            }
            catch (Exception ex)
            {
                LoggerBL.GetInstance().Error(ErrorCodes.ISLEM_HATALI.ToString(), ex);
                throw new MyException(ErrorCodes.ISLEM_HATALI, ex);
            }
        }

        public List<customerDTO> AddNewList(List<customerDTO> dto)
        {
            try
            {
                using (UnitOfWork worker = new UnitOfWork())
                {
                    List<customer> itemList = mapper.Map<List<customer>>(dto);
                    worker.RepositoryCUSTOMER.InsertList(itemList);
                    worker.Save();
                    List<customerDTO> val = mapper.Map<List<customerDTO>>(itemList);
                    return val;
                }
            }
            catch (Exception ex)
            {
                LoggerBL.GetInstance().Error(ErrorCodes.ISLEM_HATALI.ToString(), ex);
                throw new MyException(ErrorCodes.ISLEM_HATALI, ex);
            }
        }

        public customerDTO Update(customerDTO dto)
        {
            try
            {
                using (UnitOfWork worker = new UnitOfWork())
                {
                    customer item = mapper.Map<customer>(dto);
                    worker.RepositoryCUSTOMER.Update(item);
                    worker.Save();
                    customerDTO val = mapper.Map<customerDTO>(item);
                    return val;
                }
            }
            catch (Exception ex)
            {
                LoggerBL.GetInstance().Error(ErrorCodes.ISLEM_HATALI.ToString(), ex);
                throw new MyException(ErrorCodes.ISLEM_HATALI, ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (UnitOfWork worker = new UnitOfWork())
                {
                    worker.RepositoryCUSTOMER.Delete(id);
                    worker.Save();
                }
            }
            catch (Exception ex)
            {
                LoggerBL.GetInstance().Error(ErrorCodes.ISLEM_HATALI.ToString(), ex);
                throw new MyException(ErrorCodes.ISLEM_HATALI, ex);
            }
        }

        public void Delete(customerDTO dto)
        {
            Delete(dto.ID);
        }
    }
}